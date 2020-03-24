using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeTaskSamples.TaskSample
{
    class TaskInstantiation
    {
        public void TaskInstantiationDemo()
        {
            // 声明一个委托类型action ，其中接受一个参数obj
            Action<Object> action = obj =>
            {
                Console.WriteLine("Task = {0}, obj = {1}, Thread = {2}", Task.CurrentId, obj, Thread.CurrentThread.ManagedThreadId);
            };

            // 创建一个task但是不是马上让它执行
            Task t1 = new Task(action, "alpha");

            // 创建一个task并且立马执行
            Task t2 = Task.Factory.StartNew(action, "beta");
            // 阻塞主线程，让t2得到执行
            t2.Wait();

            // t2执行完之后执行t1
            t1.Start();
            Console.WriteLine("task t1 已经得到执行，主线程 = {0}", Thread.CurrentThread.ManagedThreadId);
            // 等待t1结束
            t1.Wait();

            //使用Task.Run构造并且运行一个task
            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("Task = {0}, obj = {1}, Thread = {2}", Task.CurrentId, "delta", Thread.CurrentThread.ManagedThreadId);
            });

            t3.Wait();


            // 构造一个task并且同步执行
            Task t4 = new Task(action, "gamma");
            // 同步执行
            t4.RunSynchronously();
            t4.Wait();
        }

        // 创建并且执行task
        // 1. task的实例化方法有很多种，最常见的方法就是使用Run(),该方法使用默认的参数，并且不需要额外的参数设置便可以运行
        public static async Task LoopNum()
        {
            await Task.Run(() =>
            {
                // 直接循环
                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                { 
                    // do nothing
                }
                Console.WriteLine("Finished {0} loop iterations", ctr);
            });
        }

        // 2. 使用Task.StartNew方法创建并执行Task,该方法允许我们传入特定的参数
        public static void StartNew()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                {
                    // do nothing
                }
                Console.WriteLine("Finished {0} loop iterations", ctr);
            });

            t.Wait();
        }
    }
}

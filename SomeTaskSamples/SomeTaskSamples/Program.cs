using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeTaskSamples.TaskSample;

namespace SomeTaskSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskInstantiation taskInstantiation = new TaskInstantiation();
            taskInstantiation.TaskInstantiationDemo();
            TaskInstantiation.StartNew();
            Console.ReadKey();
        }
    }
}

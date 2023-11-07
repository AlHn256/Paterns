using System;

namespace Adapter2
{
    class Program
    {
        class Worker
        {
            public string doSms()
            {
                string text = "Worker doSms";
                Console.WriteLine(text);
                return text;
            }
        }

        public interface TypeWork
        {
            void doSmsElse();
        }

        class Adapter : Worker, TypeWork
        {
            public void doSmsElse()
            {
                Console.WriteLine(this.doSms() + "and CoWorker doSmsElse");
            }
        }

        class Adapter2 : TypeWork
        {
            Worker worker = new Worker();
            public void doSmsElse()
            {
                string text = "Adapter2 doSmsElse and " + worker.doSms();
                Console.Write(text);
            }
        }

        static void Main()
        {
            Adapter coWorker = new Adapter();
            coWorker.doSmsElse();

            Adapter2 adapter = new Adapter2();
            adapter.doSmsElse();
        }
    }
}

using System;

namespace Strategy
{
    class Worker
    {
        public void DoWork(IJob job )
        {
            if (job != null)
            {
                job.DoJob();
            }
        }
    }

    public interface IJob
    {
        void DoJob();
    }

    class FootJob:IJob
    {
        public void DoJob()
        {
            Console.WriteLine("Foot Job");
        }
    }
    class HandJob:IJob
    {
        public void DoJob()
        {
            Console.WriteLine("Hand Job");
        }
    }

    class BrainJob : IJob
    {
        public void DoJob()
        {
            Console.WriteLine("Hand Brain");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            Random random = new Random();

            int rand = random.Next(0, 30);

            if (rand > 0 && rand <10)worker.DoWork(new HandJob());
            else if (rand > 10 && rand < 20) worker.DoWork(new FootJob());
            else worker.DoWork(new BrainJob());
        }
    }
}
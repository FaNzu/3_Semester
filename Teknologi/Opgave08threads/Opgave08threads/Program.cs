namespace Opgave08threads
{
    internal class Program
    {
        public static int mainsum = 0;
        public static int checksum = 0;

        static Random rand = new Random();
        static Object mylock = new Object();

        static void Main(string[] args)
        {
            Console.WriteLine("Starting main method");

            var t1 = new Thread(new ThreadStart(doWork));
            t1.Name = "thread 1";
            t1.Start();

            var t2 = new Thread(new ThreadStart(doWork));
            t2.Name = "thread 2";
            t2.Start();

            var t3 = new Thread(new ThreadStart(doWork));
            t3.Name = "thread 3";
            t3.Start();

            var t4 = new Thread(new ThreadStart(dominusWork));
            t4.Name = "thread 1";
            t4.Start();

            var t5 = new Thread(new ThreadStart(dominusWork));
            t5.Name = "thread 2";
            t5.Start();

            var t6 = new Thread(new ThreadStart(dominusWork));
            t6.Name = "thread 3";
            t6.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();


            Console.WriteLine($"mainsum: {mainsum}");
            Console.WriteLine($"checksum: {checksum}");
            Console.ReadLine();
        }

        private static void doWork()
        {
            int mysum = 0;
            for (int i = 0; i < 300; i++)
            {
                Thread.Sleep(rand.Next(1, 30));
                int randomval = rand.Next(0, 9);
                lock (mylock)
                {
                    mysum += randomval;
                    mainsum += randomval;
                    checksum += randomval;
                }

            }
            Console.WriteLine($"{Thread.CurrentThread.Name} - {mysum}");
        }

        private static void dominusWork()
        {
            int mysum = 0;
            for (int i = 0; i < 300; i++)
            {
                Thread.Sleep(rand.Next(1, 30));
                int randomval = rand.Next(0, 9);
                lock (mylock)
                {
                    mysum -= randomval;
                    mainsum -= randomval;
                    checksum -= randomval;
                }

            }
            Console.WriteLine($"{Thread.CurrentThread.Name} - {mysum}");
        }
    }
}
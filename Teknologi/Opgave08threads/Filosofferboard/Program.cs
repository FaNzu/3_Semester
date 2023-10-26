namespace Filosofferboard
{
    class PhilosopherDiningProblem
    {
        private static int NUM_PHILOSOPHERS = 5;

        private static Mutex[] spoons = new Mutex[NUM_PHILOSOPHERS];

        static void Main(string[] args)
        {
            for (int i = 0; i < NUM_PHILOSOPHERS; i++)
            {
                spoons[i] = new Mutex();
            }

            Thread[] philosophers = new Thread[NUM_PHILOSOPHERS];

            for (int i = 0; i < NUM_PHILOSOPHERS; i++)
            {
                philosophers[i] = new Thread(PhilosopherThread);
                philosophers[i].Start(i);
            }

            foreach (Thread philosopher in philosophers)
            {
                philosopher.Join();
            }
        }

        static void PhilosopherThread(object indexObj)
        {
            int index = (int)indexObj;
            Mutex leftSpoon = spoons[index];
            Mutex rightSpoon = spoons[(index + 1) % NUM_PHILOSOPHERS];

            while (true)
            {
                Console.WriteLine($"Filosof {index} er sulten og forsøger at få spisepindene.");

                leftSpoon.WaitOne();
                rightSpoon.WaitOne();

                Console.WriteLine($"Filosof {index} spiser.");

                Thread.Sleep(TimeSpan.FromSeconds(2)); // Filosofen spiser i 2 sekunder

                leftSpoon.ReleaseMutex();
                rightSpoon.ReleaseMutex();

                Console.WriteLine($"Filosof {index} lægger spisepindene fra sig og sover.");

                Thread.Sleep(TimeSpan.FromSeconds(2)); // Filosofen sover i 2 sekunder
            }
        }
    }
}
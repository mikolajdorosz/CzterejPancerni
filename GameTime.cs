using System;

namespace CzterejPancerni
{
    internal class GameTime
    {
        public static int CurrentTime { get; private set; } = 0;
        private static Random random = new Random();

        public static void Add(int min, int max)
        {
            CurrentTime += GenerateRandomNumber(min, max);
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}

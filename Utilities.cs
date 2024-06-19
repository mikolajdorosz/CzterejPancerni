using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CzterejPancerni
{
    internal class Utilities
    {
        public static void OnSpacebar()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.Spacebar) key = Console.ReadKey(true).Key;
        }

        public static async Task<ConsoleKey> GetValidKey(List<ConsoleKey> validKeys)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            while (!validKeys.Contains(key))
            {
                await Utilities.DisplayWarning("Podana wartość jest nieprawidłowa!");
                key = Console.ReadKey(true).Key;
            }
            return key;
        }

        public static async Task DisplayWarning(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            await Task.Delay(1000);

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', message.Length));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}

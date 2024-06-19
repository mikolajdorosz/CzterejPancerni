using System;
using System.Collections.Generic;
using System.Linq;

namespace CzterejPancerni
{
    internal class Events
    {
        public static Dictionary<string, List<string>> Changes = new Dictionary<string, List<string>>()
        {
            { "+Item", new List<string>() },
            { "-Item", new List<string>() },
            { "+Member", new List<string>() },
            { "-Member", new List<string>() },
            { "+Tank", new List<string>() },
            { "-Tank", new List<string>() }
        };

        public static void Add(string e, string name)
        {
            Changes[e].Add(name);
        }
        public static void Display()
        {
            if (Changes["+Item"].Count > 0) Console.Write("Dodano do ekwipunku: {0}  ", string.Join(", ", Changes["+Item"]));
            if (Changes["-Item"].Count > 0) Console.Write("|  Usunięto z ekwipunku: {0}  ", string.Join(", ", Changes["-Item"]));
            if (Changes["+Member"].Count > 0) Console.Write("|  Nowi rekruci: {0}  ", string.Join(", ", Changes["+Member"]));
            if (Changes["-Member"].Count > 0) Console.Write("|  Odeszli: {0}  ", string.Join(", ", Changes["-Member"]));
            if (Changes["+Tank"].Count > 0) Console.Write("|  Przechwycono pojazd  ");
            if (Changes["-Tank"].Count > 0) Console.Write("|  Pozostawiono pojazd");
        }
        public static void Clear()
        {
            foreach (string item in Changes.Keys) Changes[item].Clear();
        }
    }
}

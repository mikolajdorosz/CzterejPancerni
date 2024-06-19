using System;
using System.Linq;

namespace CzterejPancerni
{
    internal class Components
    {
        public static void Title()
        {
            HorizontalLine();
            Console.WriteLine("|                                  Misja: Odbić Szarika!                                      |");
            HorizontalLine();
        }
        public static void Info(string player, Tank tank, Crew crew, Equipment equipment)
        {
            string tankState = tank.Approachable ? "Dostępny" : "Niedostępny";
            Console.WriteLine(
                $"| Dowódca: {Game.Player}  " +
                $"|  Czołg: {tankState}  " +
                $"|  Załoga: ({crew.CrewMembers.Count})  " +
                $"|  Ekwipunek: ({equipment.Items.Count})  " +
                $"|  Czas: {GameTime.CurrentTime} min |");
            HorizontalLine();
        }

        public static void ExpandCrew(Crew crew)
        {
            HorizontalLine();
            Console.WriteLine( $"Załoga: {string.Join(" | ", crew.CrewMembers.Select(i => i.Key.ToString()))}");
            HorizontalLine();
        }
        public static void ExpandEquipment(Equipment equipment)
        {
            Console.WriteLine($"Ekwipunek: {string.Join(" | ", equipment.Items.Select(i => i.Key.ToString()))}");
            HorizontalLine();
        }
        public static void HorizontalLine()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
        }
    }
}

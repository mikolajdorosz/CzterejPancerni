using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CzterejPancerni
{
    internal class Minefield : Obstacle
    {
        private bool gameOver = false;
        public Dictionary<string, ObjectToGather> ToGather { get; private set; }

        public Minefield()
        {
            ToGather = new Dictionary<string, ObjectToGather> {
                { "Karabin snajperski", new Item("Karabin snajperski") },
                { "Mapa okolicy", new Item("Mapa okolicy") }};
        }
        public override bool KeepGoing(Crew crew, Tank tank, Equipment equipment)
        {
            if (crew.CrewMembers.Keys.Contains("Sojuszniczy oddział")) return false;

            DisplayIntro(tank, crew, equipment, Story.MineField("BeforeCheck"));
            ConsoleKey check = Utilities.GetValidKey(new List<ConsoleKey> { ConsoleKey.Q }).Result;
            Components.ExpandCrew(crew);
            Components.ExpandEquipment(equipment);

            Console.Write(Story.MineField("BeforeChoice"), Game.Player);
            ConsoleKey option = Utilities.GetValidKey(UnveilOptions(crew, tank, equipment)).Result;
            switch (option)
            {
                case ConsoleKey.D1: Option1(crew, tank, equipment);
                    break;

                case ConsoleKey.D2: Option2(crew, tank, equipment);
                    break;

                case ConsoleKey.D3: Option3(crew, tank, equipment);
                    break;

                default: Console.Write("Nieprawidłowa wartość!");
                    break;
            }
            return gameOver;
        }
        public override List<ConsoleKey> UnveilOptions(Crew crew, Tank tank, Equipment equipment)
        {
            List<ConsoleKey> keys = new List<ConsoleKey>();
            if (equipment.Items.Keys.Contains("Wykrywacz min")) {
                Console.Write(Story.MineField("Choice1"));
                keys.Add(ConsoleKey.D1);
            }
            if (tank.Approachable && crew.CrewMembers.Keys.Contains("Grigorij"))
            {
                Console.Write(Story.MineField("Choice2"));
                keys.Add(ConsoleKey.D2);
            }
            if (crew.CrewMembers.Keys.Contains("Franek"))
            {
                Console.Write(Story.MineField("Choice3"));
                keys.Add(ConsoleKey.D3);
            }
            return keys;
        }
        public override void Option1(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(30, 60);
            equipment.AddItem(ToGather["Karabin snajperski"] as Item);
            equipment.RemoveItem(equipment.Items["Wykrywacz min"]);

            DisplayOutro(tank, crew, equipment, Story.MineField("Option1"));
        }
        public override void Option2(Crew crew, Tank tank, Equipment equipment)
        {
            DisplayIntro(tank, crew, equipment, Story.MineField("Option2Challange"));
            string solution = Console.ReadLine().Trim().ToLower();
            if (solution == "szarik")
            {
                GameTime.Add(20, 30);
                Console.WriteLine($"Masz tylko jedną próbę.");

                DisplayOutro(tank, crew, equipment, Story.MineField("CorrectAnswer"));
            }
            else
            {
                gameOver = true;
                DisplayOutro(tank, crew, equipment, Story.MineField("WrongAnswer"));
            }
        }
        public override void Option3(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(20, 30);
            equipment.AddItem(ToGather["Mapa okolicy"] as Item);
            crew.Leave(crew.CrewMembers["Franek"]);
            crew.Leave(crew.CrewMembers["Grigorij"]);
            tank.GetOut();

            DisplayOutro(tank, crew, equipment, Story.MineField("Option3"));
        }
    }
}

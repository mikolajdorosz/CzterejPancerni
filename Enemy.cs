using System;
using System.Collections.Generic;
using System.Linq;

namespace CzterejPancerni
{
    internal class Enemy : Obstacle
    {
        private bool gameOver = false;
        public Dictionary<string, ObjectToGather> ToGather { get; private set; }

        public Enemy()
        {
            ToGather = new Dictionary<string, ObjectToGather> {
                { "Strzelba", new Item("Strzelba") },
                { "Niemiecki mundur", new Item("Niemiecki mundur") }};
        }
        public override bool KeepGoing(Crew crew, Tank tank, Equipment equipment)
        {
            DisplayIntro(tank, crew, equipment, Story.Enemy("BeforeCheck"));
            ConsoleKey check = Utilities.GetValidKey(new List<ConsoleKey> { ConsoleKey.Q }).Result;
            Components.ExpandCrew(crew);
            Components.ExpandEquipment(equipment);

            Console.Write(Story.Enemy("BeforeChoice"), Game.Player);
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
            if (!tank.Approachable)
            {
                Console.Write(Story.Enemy("Choice1"));
                keys.Add(ConsoleKey.D1);
            }
            if (tank.Approachable && crew.CrewMembers.Keys.Contains("Grigorij"))
            {
                Console.Write(Story.Enemy("Choice2"));
                keys.Add(ConsoleKey.D2);
            }
            if (!tank.Approachable && equipment.Items.Keys.Contains("Mapa okolicy"))
            {
                Console.Write(Story.Enemy("Choice3"));
                keys.Add(ConsoleKey.D3);
            }
            return keys;
        }
        public override void Option1(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(20, 30);
            equipment.AddItem(ToGather["Strzelba"] as Item);
            equipment.AddItem(ToGather["Niemiecki mundur"] as Item);

            DisplayOutro(tank, crew, equipment, Story.Enemy("Option1"));
        }
        public override void Option2(Crew crew, Tank tank, Equipment equipment)
        {
            DisplayIntro(tank, crew, equipment, Story.Enemy("Option2Challenge"));
            string solution = Console.ReadLine().Trim().ToLower();
            if (solution == "rudy") {
                GameTime.Add(20, 30);
                equipment.RemoveItem(equipment.Items["Karabin"]);
                equipment.RemoveItem(equipment.Items["Pistolet"]);

                DisplayOutro(tank, crew, equipment, Story.Enemy("CorrectAnswer"));
            }
            else {
                gameOver = true;
                DisplayOutro(tank, crew, equipment, Story.Enemy("WrongAnswer"));
            }
        }
        public override void Option3(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(20, 30);
            equipment.RemoveItem(equipment.Items["Mapa okolicy"]);

            DisplayOutro(tank, crew, equipment, Story.Enemy("Option3"));
        }
    }
}

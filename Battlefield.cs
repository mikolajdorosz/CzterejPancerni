using System;
using System.Collections.Generic;
using System.Linq;

namespace CzterejPancerni
{
    internal class Battlefield : Obstacle
    {
        private bool gameOver = false;
        public Dictionary<string, ObjectToGather> ToGather { get; private set; }

        public override bool KeepGoing(Crew crew, Tank tank, Equipment equipment)
        {
            DisplayIntro(tank, crew, equipment, Story.BattleField("BeforeCheck"));
            ConsoleKey check = Utilities.GetValidKey(new List<ConsoleKey> { ConsoleKey.Q }).Result;
            Components.ExpandCrew(crew);
            Components.ExpandEquipment(equipment);

            Console.WriteLine(Story.BattleField("BeforeChoice"), Game.Player);
            ConsoleKey option = Utilities.GetValidKey(UnveilOptions(crew, tank, equipment)).Result;
            switch (option)
            {
                case ConsoleKey.D1:
                    Option1(crew, tank, equipment);
                    break;

                case ConsoleKey.D2:
                    Option2(crew, tank, equipment);
                    break;

                case ConsoleKey.D3:
                    Option3(crew, tank, equipment);
                    break;

                default:
                    Console.Write("Nieprawidłowa wartość!");
                    break;
            }
            return gameOver;
        }
        public override List<ConsoleKey> UnveilOptions(Crew crew, Tank tank, Equipment equipment)
        {
            List<ConsoleKey> keys = new List<ConsoleKey>();
            Console.Write(Story.BattleField("Choice1"));
            keys.Add(ConsoleKey.D1);
            if (!tank.Approachable && equipment.Items.Keys.Contains("Niemiecki mundur"))
            {
                Console.Write(Story.BattleField("Choice2"));
                keys.Add(ConsoleKey.D2);
            }
            Console.Write(Story.BattleField("Choice3"));
            keys.Add(ConsoleKey.D3);
            return keys;
        }
        public override void Option1(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(20, 30);

            DisplayOutro(tank, crew, equipment, Story.BattleField("Option1"));
        }
        public override void Option2(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(20, 30);
            equipment.RemoveItem(equipment.Items["Niemiecki mundur"]);

            DisplayOutro(tank, crew, equipment, Story.BattleField("Option2"));
        }
        public override void Option3(Crew crew, Tank tank, Equipment equipment)
        {
            DisplayIntro(tank, crew, equipment, Story.BattleField("Option3Challenge"));
            string solution = Console.ReadLine().Trim().ToLower();
            if (solution == "w norze" || solution == "nora")
            {
                GameTime.Add(20, 30);

                DisplayOutro(tank, crew, equipment, Story.BattleField("CorrectAnswer"));
            }
            else
            {
                gameOver = true;
                DisplayOutro(tank, crew, equipment, Story.BattleField("WrongAnswer"));
            }
        }
    }
}

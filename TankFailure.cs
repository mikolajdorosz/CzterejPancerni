using System;
using System.Collections.Generic;
using System.Linq;

namespace CzterejPancerni
{
    internal class TankFailure : Obstacle
    {
        private bool gameOver = false;
        public Dictionary<string, ObjectToGather> ToGather { get; private set; }

        public override bool KeepGoing(Crew crew, Tank tank, Equipment equipment)
        {
            if (!tank.Approachable) return false;

            DisplayIntro(tank, crew, equipment, Story.TankFailue("BeforeCheck"));
            ConsoleKey check = Utilities.GetValidKey(new List<ConsoleKey> { ConsoleKey.Q }).Result;
            Components.ExpandCrew(crew);
            Components.ExpandEquipment(equipment);

            Console.Write(Story.TankFailue("BeforeChoice"), Game.Player);
            ConsoleKey option = Utilities.GetValidKey(UnveilOptions(crew, tank, equipment)).Result;
            switch (option)
            {
                case ConsoleKey.D1: Option1(crew, tank, equipment);
                    break;

                case ConsoleKey.D2: Option2(crew, tank, equipment);
                    break;

                default:
                    Console.Write("Nieprawidłowa wartość! Spróbuj ponownie.");
                    break;
            }
            return gameOver;
        }
        public override List<ConsoleKey> UnveilOptions(Crew crew, Tank tank, Equipment equipment)
        {
            List<ConsoleKey> keys = new List<ConsoleKey>();
            if (equipment.Items.Keys.Contains("Zestaw narzędzi") && crew.CrewMembers.Keys.Contains("Grigorij") && tank.Approachable)
            {
                Console.Write(Story.TankFailue("Choice1"));
                keys.Add(ConsoleKey.D1);
                Console.Write(Story.TankFailue("Choice2"));
                keys.Add(ConsoleKey.D2);
            }
            return keys;
        }
        public override void Option1(Crew crew, Tank tank, Equipment equipment)
        {
            DisplayIntro(tank, crew, equipment, Story.TankFailue("Option1Challenge"));
            string solution = Console.ReadLine().Trim().ToLower();
            if (solution == "zawalony most")
            {
                GameTime.Add(30, 60);
                equipment.RemoveItem(equipment.Items["Zestaw narzędzi"]);

                DisplayOutro(tank, crew, equipment, Story.TankFailue("CorrectAnswer"));
            }
            else
            {
                equipment.RemoveItem(equipment.Items["Karabin"]);
                equipment.RemoveItem(equipment.Items["Pistolet"]);
                tank.GetOut();

                DisplayOutro(tank, crew, equipment, Story.TankFailue("WrongAnswer"));
            }
        }
        public override void Option2(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(10, 20);
            equipment.RemoveItem(equipment.Items["Karabin"]);
            equipment.RemoveItem(equipment.Items["Pistolet"]);
            tank.GetOut();

            DisplayOutro(tank, crew, equipment, Story.TankFailue("Option2"));
        }
        public override void Option3(Crew crew, Tank tank, Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}

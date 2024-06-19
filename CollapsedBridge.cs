using System;
using System.Collections.Generic;
using System.Linq;

namespace CzterejPancerni
{
    internal class CollapsedBridge : Obstacle
    {
        private bool gameOver = false;
        public Dictionary<string, ObjectToGather> ToGather { get; private set; }

        public CollapsedBridge() 
        {
            ToGather = new Dictionary<string, ObjectToGather> {
                { "Zestaw narzędzi", new Item("Zestaw narzędzi") },
                { "Wykrywacz min", new Item("Wykrywacz min") },
                { "Franek", new CrewMember("Franek", "Doskonale zna okolicę") },
                { "Sojuszniczy oddział", new CrewMember("Sojuszniczy oddział", "Przygotowani do przejścia przez pole minowe") }};
        }

        public override bool KeepGoing(Crew crew, Tank tank, Equipment equipment)
        {
            DisplayIntro(tank, crew, equipment, Story.CollapsedBridge("BeforeCheck"));
            ConsoleKey check = Utilities.GetValidKey(new List<ConsoleKey> { ConsoleKey.Q }).Result;
            Components.ExpandCrew(crew);
            Components.ExpandEquipment(equipment);

            Console.Write(Story.CollapsedBridge("BeforeChoice"), Game.Player);
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
            if (equipment.Items.Keys.Contains("Łopata"))
            {
                Console.Write(Story.CollapsedBridge("Choice1"));
                keys.Add(ConsoleKey.D1);
            }
            if (equipment.Items.Keys.Contains("Mapa"))
            {
                Console.Write(Story.CollapsedBridge("Choice2"));
                keys.Add(ConsoleKey.D2);
            }
            Console.Write(Story.CollapsedBridge("Choice3"));
            keys.Add(ConsoleKey.D3);
            return keys;
        }
        public override void Option1(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(30, 60);
            crew.Recruit(ToGather["Franek"] as CrewMember);
            equipment.AddItem(ToGather["Zestaw narzędzi"] as Item);
            equipment.RemoveItem(equipment.Items["Łopata"]);

            DisplayOutro(tank, crew, equipment, Story.CollapsedBridge("Option1"));
        }
        public override void Option2(Crew crew, Tank tank, Equipment equipment)
        {
            int attempts = 3;
            bool correctAnswer = false;
            while (attempts > 0) {
                DisplayIntro(tank, crew, equipment, Story.CollapsedBridge("Option2Challenge"));
                Console.WriteLine($"Pozostałe próby: {attempts}");

                string solution = Console.ReadLine().Trim().ToLower();
                if (solution == "czterej pancerni i pies") {
                    GameTime.Add(20, 30);
                    equipment.AddItem(ToGather["Zestaw narzędzi"] as Item);
                    crew.Recruit(ToGather["Sojuszniczy oddział"] as CrewMember);
                    tank.ChangeState();

                    correctAnswer = true;
                    DisplayOutro(tank, crew, equipment, Story.CollapsedBridge("CorrectAnswer"));
                    break;
                }
                attempts--;
            }
            if (!correctAnswer) {
                gameOver = true;
                DisplayOutro(tank, crew, equipment, Story.CollapsedBridge("WrongAnswer"));
            }
        }
        public override void Option3(Crew crew, Tank tank, Equipment equipment)
        {
            GameTime.Add(20, 30);
            equipment.AddItem(ToGather["Wykrywacz min"] as Item);
            equipment.AddItem(ToGather["Zestaw narzędzi"] as Item);
            crew.Leave(crew.CrewMembers["Grigorij"]);
            tank.GetOut();

            DisplayOutro(tank, crew, equipment, Story.CollapsedBridge("Option3"));
        }
        
    }
}

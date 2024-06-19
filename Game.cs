using System;
using System.Collections.Generic;

namespace CzterejPancerni
{
    internal class Game
    {
        public static string Player;
        private Crew crew;
        private Tank tank;
        private Equipment equipment;
        private List<Obstacle> obstacles;
        public bool GameOver { get; set; } = false;
        public bool Win { get; set; } = true;

        public Game()
        {
            crew = new Crew();
            tank = new Tank();
            equipment = new Equipment();
            obstacles = new List<Obstacle>
            {
                new CollapsedBridge(),
                new Minefield(),
                new TankFailure(),
                new Enemy(),
                new Battlefield()
            };
        }

        public void Start()
        {
            Story.Prologue();
            while (true)
            {
                foreach (Obstacle obs in obstacles)
                {
                    Events.Clear();
                    GameOver = obs.KeepGoing(crew, tank, equipment);
                    if (GameOver) Win = false;
                }
                if (Win)
                {
                    Components.Title();
                    Console.Clear();
                    Console.WriteLine("Brawo! Udało ci się! Misja została zakończona powodzeniem." +
                        $"\nPotrzebowałeś {GameTime.CurrentTime} minut, aby dotrzeć do Szarika.");
                    break;
                }
                else
                {
                    Components.Title();
                    Console.Clear();
                    Console.WriteLine("Niestety nie tym razem :(" +
                        "\nWciśnij 1, aby kontynuować lub 2, aby wyjść z gry.");
                    ConsoleKey option = Utilities.GetValidKey(new List<ConsoleKey> { ConsoleKey.D1, ConsoleKey.D2 }).Result;
                    if (option == ConsoleKey.D2) break; 
                }
            }
            
        }
    }
}

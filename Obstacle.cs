using System;
using System.Collections.Generic;

namespace CzterejPancerni
{
    internal abstract class Obstacle
    {
        public abstract List<ConsoleKey> UnveilOptions(Crew crew, Tank tank, Equipment equipment);
        public abstract bool KeepGoing(Crew crew, Tank tank, Equipment equipment);
        public abstract void Option1(Crew crew, Tank tank, Equipment equipment);
        public abstract void Option2(Crew crew, Tank tank, Equipment equipment);
        public abstract void Option3(Crew crew, Tank tank, Equipment equipment);

        public void DisplayIntro(Tank tank, Crew crew, Equipment equipment, string story)
        {
            Console.Clear();
            Components.Title();
            Components.Info(Game.Player, tank, crew, equipment);
            Console.Write(story, Game.Player);
        }
        public void DisplayOutro(Tank tank, Crew crew, Equipment equipment, string story)
        {
            Console.Clear();
            Components.Title();
            Components.Info(Game.Player, tank, crew, equipment);
            Events.Display();
            Console.WriteLine(story, Game.Player);
            Utilities.OnSpacebar();
        }
        
    }
}

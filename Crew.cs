using System;
using System.Collections.Generic;

namespace CzterejPancerni
{
    internal class Crew
    {
        public Dictionary<string, CrewMember> CrewMembers { get; set; }

        public Crew()
        {
            CrewMembers = new Dictionary<string, CrewMember>()
            {
                {"Janek", new CrewMember("Janek", "Spryt")},
                {"Gustlik", new CrewMember("Gustlik", "Siła")},
                {"Grigorij", new CrewMember("Grigorij", "Kierowca")}
            };
        }
        public void Recruit(CrewMember member)
        {
            CrewMembers.Add(member.Name, member);
            Events.Add("+Member", member.Name);
        }
        public void Leave(CrewMember member)
        {
            CrewMembers.Remove(member.Name);
            Events.Add("-Member", member.Name);
        }
    }
}

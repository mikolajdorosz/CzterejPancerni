using System;

namespace CzterejPancerni
{
    internal class CrewMember : ObjectToGather
    {
        public string Name { get; private set; }
        public string Ability { get; private set; }

        public CrewMember(string name, string ability)
        {
            Name = name;
            Ability = ability;
        }
    }
}

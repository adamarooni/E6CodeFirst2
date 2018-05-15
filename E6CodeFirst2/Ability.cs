using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E6CodeFirst2
{
    public class Ability
    {
        public int AbilityId { get; set; }
        public string AbilityName { get; set; }
        public mutantAbility abilityType { get; set; }
        public enum mutantAbility { Physical, Mental, Esoteric }

        public ICollection<Student> Students { get; set; }
    }
}

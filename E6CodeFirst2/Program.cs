using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E6CodeFirst2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var student1 = new Student()
                {
                    StudentName = "Wanda Maximoff",
                    DateOfBirth = new DateTime(2001, 03, 27),
                    Height = 5.5m,
                    Weight = 110.5f,
                    MutantAbility = new Ability { AbilityName = "Chaos Magic", abilityType = Ability.mutantAbility.Esoteric }
                };

                var student2 = new Student()
                {
                    StudentName = "Piotr Rasputin",
                    DateOfBirth = new DateTime(1999, 10, 2),
                    Height = 6.5m,
                    Weight = 250.4f,
                    MutantAbility = new Ability { AbilityName = "Steel Form", abilityType = Ability.mutantAbility.Physical }
                };

                var student3 = new Student()
                {
                    StudentName = "Betsy Braddock",
                    DateOfBirth = new DateTime(2002, 01, 25),
                    Height = 5.8m,
                    Weight = 115.6f,
                    MutantAbility = new Ability { AbilityName = "Psionics", abilityType = Ability.mutantAbility.Mental }
                };

                ctx.Students.Add(student1);
                ctx.Students.Add(student2);
                ctx.Students.Add(student3);
                ctx.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E6CodeFirst2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                //initialize database with 3 students
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

                Console.WriteLine("Welcome to Xavier's School for Gifted Youngsters.");
                Console.WriteLine("Press enter to view all currently enrolled students.");
                Console.ReadLine();

                //display all students
                var query = from b in ctx.Students
                            orderby b.StudentName
                            select b;
                foreach (var student in query)
                {
                    Console.WriteLine(student.StudentName + ' ' + student.DateOfBirth + ' ' + student.MutantAbility.AbilityName + ' ' + student.MutantAbility.abilityType);
                }
                Console.ReadLine();
                Console.WriteLine("Would you like to add a student?");
                string response = Console.ReadLine().ToLower();
                if (response == "yes" || response == "y" || response == "yeah")
                {
                    try
                    {
                        Console.WriteLine("What is your student's full name?");
                        string name = Console.ReadLine();
                        Console.WriteLine("When was your child born?  Use this format 'YYYY-MM-DD'.");
                        string inputDate = Console.ReadLine();
                        DateTime date = DateTime.Parse(inputDate);
                        Console.WriteLine("How tall is your child? Use decimal format.  Example - if your child is 5 feet 6 inches, enter 5.5.");
                        decimal height = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("How much does your chidl weigh?  Use decimal format.  Example - if your child weighs 120 and a half pounds, enter 120.5.");
                        float weight = float.Parse(Console.ReadLine());
                        Console.WriteLine("What is your child's ability called?");
                        string inputAbility = Console.ReadLine();
                        Console.WriteLine("Is your child's ability Mental, Physical, or Esoteric?");
                        string input = Console.ReadLine();
                        var type = (Ability.mutantAbility)Enum.Parse(typeof(Ability.mutantAbility), input);


                        var newStudent = new Student()
                        {
                            StudentName = name,
                            DateOfBirth = date,
                            Height = height,
                            Weight = weight,
                            MutantAbility = new Ability { AbilityName = inputAbility, abilityType = type }
                        };

                        ctx.Students.Add(newStudent);
                        ctx.SaveChanges();
                        Console.WriteLine("Adding student to database...");
                        Thread.Sleep(1000);
                        Console.WriteLine("Student added.  Displaying list of currently enrolled students:");

                        //display all students again
                        var query2 = from b in ctx.Students
                                     orderby b.StudentName
                                     select b;
                        foreach (var student in query2)
                        {
                            Console.WriteLine(student.StudentName + ' ' + student.DateOfBirth + ' ' + student.MutantAbility.AbilityName + ' ' + student.MutantAbility.abilityType);
                        }
                        Console.WriteLine("Press enter to exit the database.");
                        Console.ReadLine();
                    }
                    catch (DbUpdateException)
                    {
                        Console.WriteLine("Your date of birth was invalid.  Please enter a valid birth date in the format 'YYYY-MM-DD.'");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Something went wrong.  Please try again.  If the error persists, please contact your System Administrator.");
                    }
            }
                else if (response == "no" || response == "nope" || response == "n")
                {
                    Console.WriteLine("Ok.  Press enter to exit.");
                    Console.ReadLine();
                }
            }     

        }          

    }
        
}
    


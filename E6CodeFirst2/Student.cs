using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E6CodeFirst2
{
    public class Student
    {   
        [Column("Student ID")]
        public int StudentId { get; set; }

        [Column("Student Name")]
        [MaxLength(75)]
        public string StudentName { get; set; }

        [Column("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        [Column("Ability")]
        public Ability MutantAbility { get; set; }
    }
}

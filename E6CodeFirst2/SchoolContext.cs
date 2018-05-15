using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E6CodeFirst2
{
    class SchoolContext : DbContext
    {
        public SchoolContext(): base("SchoolContext")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Ability> Abilities { get; set; } 
    }
}

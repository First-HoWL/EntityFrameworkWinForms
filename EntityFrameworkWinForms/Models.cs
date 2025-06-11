using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWinForms.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Group groupe { get; set; } = new Group { Id = 0, Name = "P00" };
        public double Avg { get; set; }
        public override string ToString()
        {
            //return $"{Id,5} | {Name,10} | {Math.Round(Avg, 2),6} | {groupe}";
            return $"{Id,5} | {Name,10} | {groupe}";
        }
    }
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher Curator { get; set; } = new Teacher { Id = 0, Name = "" };

        /* public Group(int Id, string name) 
        {
            this.Id = Id;
            this.Name = name;
        }*/
        public override string ToString()
        {
            // return $"{Id,5} | {Name,10} | {Curator}";
            return $"{Name,5}";
        }
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public override string ToString()
        {
            return $"{Id,5} | {Name} | {SecondName}";
        }
    }

    public class Note { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    

    public class UniversityContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=notes;user=root;password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}

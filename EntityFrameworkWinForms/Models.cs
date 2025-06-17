using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWinForms.Models
{
    public class Doctor
    {
        public int id { get; set; }
        public string name { get; set; }
        public double salary { get; set; }
        public Specialization specialization { get; set; }
        public override string ToString()
        {
            return $"{id,5} | {name,20} | {Math.Round(salary, 2),10} | {specialization}";
        }
    }
    public class Specialization
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{id,5} | {name,20}";
        }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Doctor Doctor { get; set; } = new Doctor();

        public override string ToString()
        {
            return $"{Id,5} | {Name,20} | {Age,4} | {Doctor.id,5} | {Doctor.name,20}";
        }
    }

    public class UniversityContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=hospital;user=root;password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }



    }
}

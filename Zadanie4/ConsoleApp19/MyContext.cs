using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    public class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(new Microsoft.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Nowa_baza3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            base.OnConfiguring(dbContextOptionsBuilder);
        }

     
    }

    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    public class Student : Person
    {
        public DateTime EnrollmentDate { get; set; }
    }

    public class Teacher : Person
    {
        public DateTime HireDate { get; set; }
    }
}

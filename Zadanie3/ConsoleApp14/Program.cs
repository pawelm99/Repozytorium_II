using Microsoft.Data.SqlClient;
using System;
using System.Configuration;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {

            var kontekst = new DBKontekst();
            kontekst.Database.EnsureCreated();

            kontekst.Users.Add(new MyUsers { Name = "Tomek2", RegistrationDate = DateTime.Today, Telefon = "513763123"});

            kontekst.SaveChanges();

            
        }
    }
}

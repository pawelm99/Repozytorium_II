using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    public class TPTKontekst : DbContext
    {
        public DbSet<Osoba> Osoba { get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Pracownik> Pracownik  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Nowa_bazaTPT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            base.OnConfiguring(dbContextOptionsBuilder);
        }

 


    }
}

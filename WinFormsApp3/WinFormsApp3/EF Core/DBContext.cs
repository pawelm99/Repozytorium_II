using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.EF_Core
{
    class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var pollInterval = ConfigurationManager.AppSettings["pollInterval"];
            dbContextOptionsBuilder.UseSqlServer(new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString));
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    
    }
}

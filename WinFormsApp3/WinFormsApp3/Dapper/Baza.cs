using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    class Baza
    {
        public string BaseGetTownship()
        {
            var DB = new DBCrudDapper(@"Data Source=DESKTOP-9SL4PUT;Initial Catalog=MBaza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var text = new StringBuilder();
            foreach (var obszar in DB.GetArea())
            {
                text.AppendLine(obszar.Miejscowosc);
            }
            return text.ToString();
            
        }
        public string BaseGetCity()
        {
            var DB = new DBCrudDapper(@"Data Source=DESKTOP-9SL4PUT;Initial Catalog=MBaza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var text = new StringBuilder();
            foreach (var obszar in DB.GetArea())
            {
                text.AppendLine(obszar.Miasto);
            }
            return text.ToString();

        }

    }
}

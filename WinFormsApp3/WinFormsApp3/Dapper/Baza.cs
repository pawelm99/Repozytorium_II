using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Models;

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

        public IEnumerable<PomiarMiejscowosc> BaseGetMeasureData()
        {
            var DB = new DBCrudDapper(@"Data Source=DESKTOP-9SL4PUT;Initial Catalog=MBaza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var text = new StringBuilder();
        /*    foreach (var pomiarMiejscowosc in DB.GetAreaEndangered())
            {
                text.Append($"{pomiarMiejscowosc.DataPomiaru.Date.ToString("d")}   ");
                text.Append($"{pomiarMiejscowosc.NazwaRzeki.ToString()}   ");
                text.Append($"{pomiarMiejscowosc.PoziomWody.ToString()}   ");
                text.Append($"{pomiarMiejscowosc.StandardowyPoziom.ToString()}   ");
                text.Append($"{pomiarMiejscowosc.Miejscowosc.ToString()}   ");
                text.Append($"{pomiarMiejscowosc.Miasto.ToString()}");
                text.AppendLine();
            }*/
            var collection = DB.GetAreaEndangered();
            return collection;

        }

    }
}

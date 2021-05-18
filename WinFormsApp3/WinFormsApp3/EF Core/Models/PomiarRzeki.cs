using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class PomiarRzeki
    {
        public PomiarRzeki()
        {
            ObszarZagrozonies = new HashSet<ObszarZagrozony>();
        }

        public double PoziomWody { get; set; }
        public string Miasto { get; set; }
        public DateTime Data { get; set; }
        public double StandardowyPoziom { get; set; }
        public string NazwaRzeki { get; set; }

        public virtual ICollection<ObszarZagrozony> ObszarZagrozonies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Ostrzeganie : Form
    {
        private int index;
        private string Sluzby;
        /// <summary>
        /// Formularz przyjmuje numer pozycji wiersza którego zaznaczyliśmy.
        /// </summary>
        /// <param name="ilosc"></param>
        public Ostrzeganie(int ilosc)
        {
            this.index = ilosc;
            InitializeComponent();
        }

         /// <summary>
         /// Następuje tutaj wyszukanie w bazie jaką służbę ratunkową posiada dany obszar.
         /// Jeśli posiada checkBox zostanie odblokwoany
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         
        private async void Ostrzeganie_Load(object sender, EventArgs e)
        {
            var baza = new Baza();
            var collction = await baza.BaseGetMeasureData();
            var text2 = collction.Select(x => x).ToArray();
            errorProvider1.SetError(checkBox4, "Realizowane w drugim projekcie");
            errorProvider1.RightToLeft = true;
            checkBox4.Enabled = false;
            if (text2[index].SluzbaRatunkowa.IndexOf("Szpital") >= 0)
            {
                checkBox2.Enabled = true;
            }
             if (text2[index].SluzbaRatunkowa.IndexOf("StrazPozarna") >= 0)
            {
                checkBox3.Enabled = true;
            }
             if (text2[index].SluzbaRatunkowa.IndexOf("Policja") >= 0)
            {
                checkBox1.Enabled = true;
            }


        }
        /// <summary>
        /// Odblokuje przycisk jeśli zaznaczymy checkBoxa
        /// </summary>
        void funEnableButton1()
        {
            button1.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            funEnableButton1();
            Sluzby += $"{checkBox1.Text}, ";
        }

 

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            funEnableButton1();
            Sluzby += $"{checkBox2.Text}, ";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            funEnableButton1();
            Sluzby += $"{checkBox3.Text}, ";

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            funEnableButton1();
            Sluzby += $"{checkBox4.Text}, ";
        }

       /// <summary>
       /// Utworzenie nowego formularza oraz wyświetlenie 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new WynikWyszukania();
            form.label1.Location = new Point(0,41);
            form.label1.Text = $"Powiadomienie wysłane do: {Sluzby}";
            form.ShowDialog();
            button1.Enabled = false;
            Close();

            
        }

  
    }
}

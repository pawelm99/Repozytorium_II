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
    public partial class WspieraneObszary : Form
    {

        public WspieraneObszary()
        {
            InitializeComponent();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            
            var form = new Tabela();
            form.ShowDialog();
        }
        /// <summary>
        /// Szuka w bazie frazy wyszukania po czym tworzy formularz
        /// z wynikem wyszukania
        /// Ustawia errorProvidera jeśli nie wpiszemy tekstu
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            
            
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                var baza = new Baza();
                progressBar1.Value = 25;
                var BaseTownShip = await baza.BaseGetTownship();
                var formFindResoult = new WynikWyszukania();


                var resoult = BaseTownShip.IndexOf(textBox1.Text, 0);
                if (resoult >= 0)
                {
                    progressBar1.Value = 100;
                    formFindResoult.label1.Text = $"Znaleziono: {textBox1.Text}";
                    

                }
                else if (resoult == -1)
                {
                    progressBar1.Value = 100;
                    formFindResoult.label1.Text = $"Nie znaleziono: {textBox1.Text}"; ;
                    
                }
                progressBar1.Value = 0;
                formFindResoult.ShowDialog();
            }
            else
            {
                errorProvider1.SetError(textBox1,"Wpisz tekst");
            }
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

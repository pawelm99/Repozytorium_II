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
        public Ostrzeganie(int ilosc)
        {
            this.index = ilosc;
            InitializeComponent();
        }

        private async void Ostrzeganie_Load(object sender, EventArgs e)
        {
            var baza = new Baza();
            var collction = await baza.BaseGetMeasureData();
            var text2 = collction.Select(x => x).ToArray();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            funEnableButton1();
            Sluzby += $"{checkBox1.Text}, ";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        void funEnableButton1()
        {
            button1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FindFuctionView();
            form.label1.Location = new Point(0,41);
            form.label1.Text = $"Powiadomienie wysłane do: {Sluzby}";
            form.ShowDialog();
            button1.Enabled = false;
            Close();

            
        }
    }
}

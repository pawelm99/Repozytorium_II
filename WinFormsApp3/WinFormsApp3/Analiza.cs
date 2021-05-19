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
    public partial class Analiza : Form
    {
        private int iloscZagrozonychObszarow; //???
        private int selectedIndexlistBox; 
        public Analiza()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var baza = new Baza();
            var collction = baza.BaseGetMeasureData();
            var text2 =  collction.Select(x => x);
            foreach (var item in text2)
            {
                listBox1.Items.Add($"{item.DataPomiaru.ToString("d")}");
                listBox2.Items.Add($"{item.Miasto.ToString()}");
                listBox3.Items.Add($"{item.NazwaRzeki.ToString()}");
                listBox4.Items.Add($"{item.Miejscowosc.ToString()}");
                listBox5.Items.Add($"{item.PoziomWody.ToString()}");
                listBox6.Items.Add($"{item.StandardowyPoziom.ToString()}");

            }

            if (text2.Count() >= 1)
            {
                button2.Enabled = true;
                iloscZagrozonychObszarow = text2.Count();
            }
           

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Analiza_Load(object sender, EventArgs e)
        {
            label2.Text = "DataPomiaru";
            label3.Text = "NazwaRzeki";
            label4.Text = "Miasto";
            label5.Text = "Miejscowosc";
            label6.Text = "PoziomWody";
            label7.Text = "StandardowyPoziom";
            
        }
        void AllIndex(int index)
        {
            listBox1.SelectedIndex = index;
            listBox2.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox4.SelectedIndex = index;
            listBox5.SelectedIndex = index;
            listBox6.SelectedIndex = index;
            selectedIndexlistBox  = index;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var form5 = new Ostrzeganie(selectedIndexlistBox);
           // form5.listBox1.Items.Add(richTextBox4.Text);
            //form5.listBox1.Items.Add(richTextBox1.Text);
            form5.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            AllIndex(listBox1.SelectedIndex);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox2.SelectedIndex);
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox3.SelectedIndex);
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox5.SelectedIndex);
        }
        

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox4.SelectedIndex);
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllIndex(listBox6.SelectedIndex);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

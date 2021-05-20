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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form1 = new DodajObszar();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2= new WspieraneObszary();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form3 = new Analiza();
            form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //var form5 = new Ostrzeganie();
            //form5.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("d");
        }
    }
}

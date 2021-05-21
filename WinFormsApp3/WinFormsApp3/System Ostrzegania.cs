using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            
            errorProvider1.SetError(button1, "Realizacja w dalszym projekcie");
            EventHandler eventHandler = error;
            eventHandler?.Invoke(this, e);
            //var form1 = new AddRegion();
            //form1.ShowDialog();
        }
        private async void error(object sender, EventArgs e)
        {
           await Task.Delay(3000);
            errorProvider1.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var form2= new WspieraneObszary();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form3 = new ZagrożoneObszary();
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
            menuStrip1.Items.Add(Name = "About",null,One_clickHelpMetod);
            


        }

        private void One_clickHelpMetod(object sender, EventArgs e)
        {
            var formText = new AboutText();
           formText.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_2(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Main_Click(object sender, EventArgs e)
        {
            
        }
    }
}

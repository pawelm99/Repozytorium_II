using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class AboutText : Form
    {
        public AboutText()
        {
            InitializeComponent();
        }

        private void FormText_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(@"C:\Users\pawel\source\repos\WinFormsApp3\WinFormsApp3\AboutOfApplication.txt");
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

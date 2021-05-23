using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadanie5_WinForms.Uzytkownik;

namespace Zadanie5_WinForms
{
    public partial class Rejestracja : Form
    {
       private string NazwaU;
        private string HasloU;
        private string PowtorzHasloU;
        private Uzytkownik.Uzytkownik user { get; set; }
        
        public Rejestracja( Uzytkownik.Uzytkownik user)
        {
            InitializeComponent();
            this.user = user;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Login";
            label2.Text = "Hasło";
            label3.Text = "Powtórz Hasło";
            checkBox1.Text = "Zgoda RODO";
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            user.Nazwa = NazwaU;
            if ((HasloU == PowtorzHasloU) && (checkBox1.Checked == true))
            {
                user.Hasło = HasloU;
                var form = new Message();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.label1.Text = "Rejestracja udana";
                form.ShowDialog();
                Close();
            }
            else if (checkBox1.Checked == false)
            {
                errorProvider1.SetError(checkBox1, "Musisz potwierdzić");
            }
            else 
            {
                errorProvider1.SetError(textBox2, "Hasła się nie zgadzają");
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            if (textBox1.Text.Length >= 4)
            {
                NazwaU = textBox1.Text;
            }
            else if(textBox1.Text.Length < 4 ) 
            {
                errorProvider1.SetError(textBox1, "Musi składać się z 4 znaków");
            }
 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            HasloU = textBox2.Text;
            errorProvider1.Clear();
            if (textBox2.Text.Length >= 4)
            {
                HasloU = textBox2.Text;
            }
            else if (textBox2.Text.Length < 4)
            {
                errorProvider1.SetError(textBox2, "Musi składać się z 4 znaków");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            PowtorzHasloU = textBox3.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                errorProvider1.Clear();
            }

        }
    }
}

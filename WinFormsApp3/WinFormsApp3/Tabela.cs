﻿using System;
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
    public partial class Tabela : Form
    {
        public Tabela()
        {
            InitializeComponent();
       
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async void Tabela_Load(object sender, EventArgs e)
        {
            var Baza = new Baza();

            textBox1.Text = "Miejscowosc";
            textBox2.Text = "Miasto";
            progressBar1.Value = 25;
            richTextBox1.Text = await Baza.BaseGetTownship();
            richTextBox2.Text = await Baza.BaseGetCity();
            progressBar1.Value = 100;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

using Newtonsoft.Json;
using System;
using Models.DB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using AapjesTesten.Models;

namespace AapjesTesten
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "admin";
            textBox2.Text = "adminpass";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string cmp_id = "demo";

            Apie.Ensure = "PostFetchToken";

            Apie.API.GetToken(username, password, cmp_id);

            if (Apie.TokenInfo != null)
            {
                Form2 lol = new Form2();
                Hide();
                lol.ShowDialog();
            }
            else
            {
                label4.Show();
                label4.Text = "Username/Password is fout";
            }
        }
    }
}

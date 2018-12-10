using System;
using Models.DB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace AapjesTesten
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Apie.Ensure = "api/Access/";
            string path = "CheckRelExist?rel_ad=" + textBox7.Text;
            string Result = await Apie.API.HTTPGet(path);
            label12.Text = Result;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string subject = textBox3.Text;
            string body = textBox6.Text;
            string bcc = textBox5.Text;
            string cc = textBox4.Text;

            Apie.Ensure = "api/Access/PostSendMail";

            Dictionary<string, string> Params = new Dictionary<string, string>
            {
                    {"email", email},
                    {"subject", subject},
                    {"body", body},
                    {"bccAdress", bcc },
                    {"ccAdress", cc }
            };

            string LParams = JsonConvert.SerializeObject(Params);

            await Apie.API.HTTPPost(LParams);

            textBox1.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();

            label12.Text = "Mail has been sent";
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    BackColor = Color.White;
                    break;
            }
        }

        private void Form2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    BackColor = Color.Red;
                    break;

                case MouseButtons.Right:
                    BackColor = Color.Yellow;
                    break;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            label12.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //colorDialog1.ShowDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog1.Color;
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Apie.Ensure = "api/Auth/";
            string path = "GetUserInfo?userName=" + textBox2.Text;
            string Result = await Apie.API.HTTPGet(path);
            label12.Text = Result;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string username = textBox8.Text;
            string password = textBox9.Text;
            string email = textBox10.Text;

            Apie.Ensure = "api/Auth/PostRelationUser";

            Dictionary<string, string> Params = new Dictionary<string, string>
            {
                    {"email", email},
                    {"loginname", username},
                    {"loginpassw", password}
            };

            string LParams = JsonConvert.SerializeObject(Params);

            string result = await Apie.API.HTTPPost(LParams);

            label12.Text = result;
        }
    }
}

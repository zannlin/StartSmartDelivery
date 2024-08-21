using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartSmartDelivery
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsernameIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lable1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = UsernameIn.Text;
            string Password = PasswordIn.Text;
            UsernameIn.Clear();
            PasswordIn.Clear();
            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}

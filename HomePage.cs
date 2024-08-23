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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            Application.Run(new LogIn());
            InitializeComponent();
            
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            
        }
    }
}

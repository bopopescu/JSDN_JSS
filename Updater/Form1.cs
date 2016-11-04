using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var req = (HttpWebRequest)WebRequest.Create("http://iwin247.kr/home/code/");
                req.ContentType = "applicaton/www-x-";
                req.Method = "POST";

            }
            catch(Exception e)
            {

            }
        }
    }
}

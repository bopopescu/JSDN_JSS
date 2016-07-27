using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSE
{
    public partial class StartingForm : Form
    {
        public int progressbar = 0;
        public StartingForm()
        {
            InitializeComponent();
        }

        private void StartingForm_Load(object sender, EventArgs e)
        {
            string version = Application.ProductVersion;
            string appname = Application.ProductName;
            string company = Application.CompanyName;
            string startup = Application.StartupPath;
            string culturename = Application.CurrentCulture.NativeName;
            versionlabel.Text = "버전 " + version + "";
            buildname.Text = appname;
            companylabel.Text = company;
            //startuplabel.Text = startup;
            culturelabel.Text = culturename;
            //timer1.Start();
        }
        public void check_file()
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressbar < 101)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                timer1.Interval = rnd.Next(80,420);
                progressBar1.Value = progressbar;
                progressbar++;
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}

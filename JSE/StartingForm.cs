using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string file = "AssemblyInfo.cs";
            if (File.Exists(file))
                File.WriteAllText(file,
                    Regex.Replace(
                        File.ReadAllText(file),
                        @"(?<=\[assembly: AssemblyFileVersion\(""[0-9]*.[0-9]*.)[0-9]*(?=.[0-9]*""\)\])",
                        m => (Convert.ToInt16(m.Value) + 1).ToString()
                    )
                );
            Additional add = new Additional();
            add.Show();
            
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
        public void contribute()
        {
        }
        public string GetFileSize(long numBytes)
        {
            string fileSize = "";

            if (numBytes > 1073741824)
                fileSize = String.Format("{0:0.00} GB", (double)numBytes / 1073741824);
            else if (numBytes > 1048576)
                fileSize = String.Format("{0:0.00} MB", (double)numBytes / 1048576);
            else
                fileSize = String.Format("{0:0} KB", (double)numBytes / 1024);

            if (numBytes != 0 && fileSize == "0 KB")
                fileSize = "1 KB";	// min.

            return fileSize;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressbar < 101)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                timer1.Interval = rnd.Next(80, 420);
                progressBar1.Value = progressbar;
                progressbar++;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(0, null);
            e.Result = null;
            FTPFactory ftp = new FTPFactory();
            ftp.setDebug(true);
            ftp.setRemoteHost("ftp.kaist.ac.kr");
            ftp.setRemoteUser("anonymous");
            ftp.setRemotePass("");
            try
            {
                ftp.login();

                Debug.WriteLine("FTP Listing");
                Debug.WriteLine(string.Join("\r\n", ftp.getFileList()));

                long nFileSize = ftp.getFileSize("CentOS/7.2.1511/isos/x86_64/CentOS-7-x86_64-DVD-1511.iso");
                Debug.WriteLine("FTP file size : " + GetFileSize(nFileSize));
            }
            catch
            {

            }
        }
    }
}

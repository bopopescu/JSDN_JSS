using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace JSE
{
    public partial class Additional : Form
    {
        public int percents = 0;
        public Additional()
        {
            InitializeComponent();
        }
        private void Additional_Load(object sender, EventArgs e)
        {

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.ReportProgress(0, null);
            e.Result = null;
            FTPFactory ftp = new FTPFactory();

            ftp.setDebug(true);

            ftp.setRemoteHost("hansung.info");

            ftp.setRemoteUser("jsdn");
            ftp.setRemotePass("whstn");

            try
            {
                ftp.login();
                Debug.WriteLine("FTP Listing");
                Debug.WriteLine(string.Join("\r\n", ftp.getFileList()));
                long nFileSize = ftp.getFileSize("JSDN/test.mp4");
                Debug.WriteLine("FTP file size : " + GetFileSize(nFileSize));
                label3.Invoke(() =>
                {
                    label3.Text = "전체 사이즈 : " + GetFileSize(nFileSize);
                });
                label2.Invoke(() =>
                {
                    label2.Text = "";
                });

                Debug.WriteLine("FTP move dir");
                ftp.chdir("JSDN/");
                /* File Download Part */

                bool isDownload = false;
                long bakDownLoadSize = -1;
                bool firstDownload = true;
                isDownload = ftp.download("test.mp4", "test.mp4", false, (long fileSize, long sendSize, long perSecSize,
                WorkCancelEvent cancelEvent) =>
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        cancelEvent.Cancel = true;
                    }
                    bakDownLoadSize = sendSize;
                    worker.ReportProgress((int)(((double)sendSize / fileSize) * 10000), null);

                    if (firstDownload == true)
                    {
                        firstDownload = false;
                        Debug.Write("실제 용량 : " + GetFileSize(fileSize) + "\r\n");
                    }
                    else
                    {
                        label1.Invoke(() =>
                        {
                            label1.Text = "전체 사이즈 : " + GetFileSize(nFileSize) + ", 받은 용량 : " + GetFileSize(sendSize);
                        });
                        label2.Invoke(() =>
                        {
                            label2.Text = "남은 용량 : " + GetFileSize(fileSize - sendSize) + ", 속도 : " + GetFileSize(perSecSize) + "/s" +
                                ", 퍼센트 : " + ((int)(((double)sendSize / fileSize) * 10000) / 100) + "%";
                        });
                        Debug.Write("남은 용량 : " + GetFileSize(fileSize - sendSize) + ",\t속도 : " + GetFileSize(perSecSize) + "/s");
                    }
                    Debug.Write(",\t퍼센트 : " + ((int)(((double)sendSize / fileSize) * 10000) / 100) + "%\r\n");
                    percents = ((int)(((double)sendSize / fileSize) * 10000) / 100);
                });
                //XXXX                
                ftp.close();
                if (isDownload)
                {
                    worker.ReportProgress(10000, null);
                    e.Result = new Object();
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
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
                fileSize = "1 KB";  // min.

            return fileSize;
        }

        public string CreateExceptionString(Exception e, string indent = null)
        {
            StringBuilder sb = new StringBuilder();
            if (indent == null)
            {
                indent = string.Empty;
            }
            else if (indent.Length > 0)
            {
                sb.AppendFormat("{0}Inner ", indent);
            }

            sb.AppendFormat("Exception Found:\r\n{0}Type: {1}", indent, e.GetType().FullName);
            sb.AppendFormat("\r\n{0}Message: {1}", indent, e.Message);
            sb.AppendFormat("\r\n{0}Source: {1}", indent, e.Source);
            sb.AppendFormat("\r\n{0}Stacktrace: {1}", indent, e.StackTrace);

            if (e.InnerException != null)
            {
                sb.Append("\r\n");
                sb.AppendFormat("InnerException Found:\r\n{0}Type: {1}", indent, e.GetType().FullName);
                sb.Append(CreateExceptionString(e.InnerException, indent + "  "));
            }

            return sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
            {
                if (backgroundWorker1.CancellationPending == false)
                {
                    DialogResult res = MessageBox.Show("다운로드가 진행중입니다. 진짜로 취소 하시겠습니까?", "중지?", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        button1.Text = "중지하는 중";
                        backgroundWorker1.CancelAsync();
                        button1.Text = "다운로드";
                    }
                }
            }
            else
            {
                button1.Text = "중지";
                if (File.Exists("test.mp4"))
                    File.Delete("test.mp4");
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = percents;
        }
    }
    public static class ControlExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            if (control.InvokeRequired) control.Invoke(new MethodInvoker(action), null);
            else action.Invoke();
        }
    }
}

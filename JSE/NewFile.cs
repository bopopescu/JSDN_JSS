using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JSE
{
    public partial class NewFile : Form
    {
        string folderpath;
        public NewFile()
        {
            InitializeComponent();
            folderpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\"; //시작할때는 내 문서 경로로 지정.
            listView1.Items[0].Selected = true;
            listView1.Select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int idx = 9999;
            if (listView1.SelectedItems.Count > 0)
            {
                idx = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            }
            textBox2.Text = folderpath + textBox1.Text;
            switch (idx)
            {
                case 0:
                    textBox2.Text += ".py";
                    ProjectOpt.Type = "Python";
                    break;
                case 1:
                    textBox2.Text += ".c";
                    ProjectOpt.Type = "C";
                    break;
                case 2:
                    textBox2.Text += ".html";
                    ProjectOpt.Type = "HTML";
                    break;
                case 3:
                    textBox2.Text += ".js";
                    ProjectOpt.Type = "JS";
                    break;
                case 4:
                    textBox2.Text += ".css";
                    ProjectOpt.Type = "CSS";
                    break;
                default:
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProjectOpt.m_FileName = textBox1.Text;
            using (System.IO.FileStream fs = System.IO.File.Create(textBox2.Text))
            {
                fs.WriteByte(1);
            }
            ProjectOpt.m_ProjectPath = textBox2.Text;

            Close();
        }

        private void NewFile_Load(object sender, EventArgs e)
        {
            textBox1.Text = "New_File";
            //textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if(r != DialogResult.Cancel)
            {
                folderpath = folderBrowserDialog1.SelectedPath;
                textBox2.Text = folderpath + "\\" +textBox1.Text;
                int idx = 9999;
                switch (idx)
                {
                    case 0:
                        textBox2.Text += ".py";
                        break;
                    case 1:
                        textBox2.Text += ".c";
                        break;
                    case 2:
                        textBox2.Text += ".html";
                        ProjectOpt.Type = "HTML";
                        break;
                    case 3:
                        textBox2.Text += ".js";
                        ProjectOpt.Type = "JS";
                        break;
                    case 4:
                        textBox2.Text += ".css";
                        ProjectOpt.Type = "CSS";
                        break;
                    default:
                        break;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

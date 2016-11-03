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
        string filepath;
        public NewFile()
        {
            InitializeComponent();
            filepath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int idx = 9999;
            if (listView1.SelectedItems.Count > 0)
            {
                idx = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            }
            textBox2.Text = filepath + @"\" + textBox1.Text;
            if (!(textBox2.Text.Contains(".py")||textBox2.Text.Contains(".c"))) //확장자가 안붙어있을때는 이렇게 해준다.
            {
                
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
                    default:
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProjectOpt.m_FileName = textBox1.Text;
            //System.IO.Directory.CreateDirectory(textBox2.Text);
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
            textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            textBox2.Text = path + textBox1.Text;
            filepath = path;
            int idx = 9999;
            switch (idx)
            {
                case 0:
                    textBox2.Text += ".py";
                    break;
                case 1:
                    textBox2.Text += ".c";
                    break;
                default:
                    break;
            }
        }
    }
}

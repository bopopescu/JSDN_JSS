using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if (ProjectOpt.m_ProjectPath != null)
            {
                filepath = ProjectOpt.m_ProjectPath;
            }
            else
            {
                filepath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int idx = 9999;
            if (listView1.SelectedItems.Count > 0)
            {
                idx = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            }
            textBox2.Text = filepath + @"\" + textBox1.Text;
            switch (idx)
            {
                case 0:
                    textBox2.Text += ".py";
                    break;
                case 1:
                    textBox2.Text += ".cs";
                    break;
                case 2:
                    textBox2.Text += ".js";
                    break;
                case 3:
                    textBox2.Text += ".c";
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.ShowDialog();
            filepath = saveFileDialog1.FileName;
        }
    }
}

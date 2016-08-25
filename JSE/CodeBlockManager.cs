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
    public partial class CodeBlockManager : Form
    {
        public string filename = Application.StartupPath + @"\codeblock\codeblock.txt";

        public string[] codes = new string[10000];
        public string[] code = new string[10000];
        public static int cnt = 0;
        public CodeBlockManager()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CodeBlockManager_Load(object sender, EventArgs e)
        {
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selidx = listBox1.SelectedIndex;
            richTextBox1.Text = "";
            richTextBox1.Text = code[selidx];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCode f = new AddCode();
            f.ShowDialog();
        }

        private void CodeBlockManager_Paint(object sender, PaintEventArgs e)
        {
            StreamReader sr = new StreamReader(filename);
            try
            {
                while (sr.EndOfStream != true)
                {
                    codes[cnt] = sr.ReadLine();
                    listBox1.Items.Add(codes[cnt]);
                    cnt++;
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
            sr.Close();
            /*
            string filename_code = Application.StartupPath + @"\codeblock\";
            int i = 0, j = 0;
            string f = filename_code + "";
            for (i = 1; i < cnt; i++)
            {
                StreamReader sr_code = new StreamReader("");
                try
                {
                    for (j = 0; sr_code.EndOfStream != true; j++)
                    {
                        code[cnt] = sr_code.ReadToEnd();
                    }
                }
                catch (IOException)
                {
                    throw new IOException();
                }
                sr_code.Close();
            }
            */
        }
    }
}

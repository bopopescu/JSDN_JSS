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
    public partial class AddCode : Form
    {
        public string filename = Application.StartupPath + @"\codeblock\";
        public static string selcode = "";
        public AddCode()
        {
            InitializeComponent();
            if(selcode != "" || selcode != null)
            {
                richTextBox1.Text = selcode;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cnt = CodeBlockManager.cnt;
            cnt++;
            StreamWriter sw = new StreamWriter(filename + textBox1.Text + ".txt");
            string[] str = richTextBox1.Text.Split('\r');
            foreach(string s in str)
            {
                sw.Write(s);
            }
            sw.Close();
        }
    }
}

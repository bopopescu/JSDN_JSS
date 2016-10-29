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
    public partial class NewProject : Form
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idx = 9999;
            if (listView1.SelectedItems.Count > 0)
            {
                idx = listView1.Items.IndexOf(listView1.SelectedItems[0]);
            }
            Console.WriteLine(idx); //Python = 0, CSharp = 1, JS = 2, C = 3;
            System.IO.Directory.CreateDirectory(textBox2.Text);

            switch (idx)
            {
                case 0:
                    using (System.IO.FileStream fs = System.IO.File.Create(textBox2.Text + @"\" + textBox1.Text + ".py"))
                    {
                        fs.WriteByte(1);
                    }
                    break;
                case 1:
                    using (System.IO.FileStream fs = System.IO.File.Create(textBox2.Text + @"\" + textBox1.Text + ".cs"))
                    {
                        fs.WriteByte(1);
                    }
                    break;
                case 2:
                    using (System.IO.FileStream fs = System.IO.File.Create(textBox2.Text + @"\" + textBox1.Text + ".js"))
                    {
                        fs.WriteByte(1);
                    }
                    break;
                case 3:
                    using (System.IO.FileStream fs = System.IO.File.Create(textBox2.Text + @"\" + textBox1.Text + ".c"))
                    {
                        fs.WriteByte(1);
                    }
                    break;
                default:
                    break;
            }

            ProjectOpt.m_ProjectPath = textBox2.Text;
            
            Close();
        }
    }
}

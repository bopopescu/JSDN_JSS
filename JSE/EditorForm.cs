using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSE
{
    public partial class EditorForm : Form
    {
        public Regex keyWords = new Regex("abstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for " + "foreach goto if implicit in int interface internal is lock long namespace new null object operator out override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static " + "string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual volatile void while ");

        public EditorForm()
        {
            InitializeComponent();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            string[] commands = Regex.Split(keyWords.ToString(), " ");
            for (int i = 0; i < commands.Length; i++)
            {
                syntaxHighlighter1.Settings.Keywords.Add(commands[i]);
            }
            
            syntaxHighlighter1.Settings.Comment = "//";
            syntaxHighlighter1.Settings.KeywordColor = Color.Blue;
            syntaxHighlighter1.Settings.CommentColor = Color.Green;
            syntaxHighlighter1.Settings.EnableStrings = false;
            syntaxHighlighter1.Settings.EnableIntegers = false;
            syntaxHighlighter1.CompileKeywords();
            syntaxHighlighter1.ProcessAllLines();
            syntaxHighlighter1.Text = "      ";
        }

        private void syntaxHighlighter1_TextChanged(object sender, EventArgs e)
        {

        }

        private void syntaxHighlighter1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Text += "      ";
            }
        }
    }
}

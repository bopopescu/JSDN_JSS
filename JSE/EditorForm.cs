using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JSE
{
    public partial class EditorForm : Form
    {
        //문법 요소들인데 나중에 외부 class로 빼야할듯
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
            const int dist = 36;
            syntaxHighlighter1.SetInnerMargins(dist, 0, 0, 0);
            syntaxHighlighter1.Settings.Comment = "//";
            syntaxHighlighter1.Settings.KeywordColor = Color.Blue;
            syntaxHighlighter1.Settings.CommentColor = Color.Green;
            syntaxHighlighter1.Settings.EnableStrings = true;
            syntaxHighlighter1.Settings.StringColor = Color.Brown;
            syntaxHighlighter1.Settings.IntegerColor = Color.Lime;
            syntaxHighlighter1.Settings.EnableIntegers = true;
            syntaxHighlighter1.CompileKeywords();
            syntaxHighlighter1.ProcessAllLines();
            //syntaxHighlighter1.Text = "      ";
            syntaxHighlighter1.ScrollToCaret();
        }

        private void syntaxHighlighter1_TextChanged(object sender, EventArgs e)
        {

        }

        private void syntaxHighlighter1_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
    }
}

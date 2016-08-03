using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JSE
{
    public partial class EditorForm : Form
    {
        //public Stack<string> undoList = new Stack<string>();
        //문법 요소들인데 나중에 외부 class로 빼야할듯
        public Regex keyWords = new Regex("문자열 구조체 스위치 이것 throw 참 try typeof uint ulong unchecked unsafe ushort using virtual volatile void while ");

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
            syntaxHighlighter1.CompileKeywords();
        }

        private void syntaxHighlighter1_TextChanged(object sender, EventArgs e)
        {
        }

        private void syntaxHighlighter1_KeyDown(object sender, KeyEventArgs e)
        {
          if(e.KeyCode == Keys.Z && e.Control)
            {
                syntaxHighlighter1.Undo();
            }
        }
    }
}

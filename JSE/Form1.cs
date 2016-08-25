using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JSE
{
    public partial class Form1 : Form
    {
        public Regex keyWords = new Regex("abstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for " + "foreach goto if implicit in int interface internal is lock long namespace new null object operator out override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static " + "string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual volatile void while ");
        public string save_string = "";
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Title = "열기";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int dist = 36;
            syntaxHighlighter1.SetInnerMargins(dist, 0, 0, 0);
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
            Console.Write("");
            richTextBox1.Text += "\r\n";
            Translator.translate();
            //richTextBox1.Text = Translator.replace_word("정수형 i = 0");
        }
        #region 추후 MDI 구현시 사용
        /*
        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false; // If no any child form, hide tabControl
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized; // Child form always maximized

                // If child form is new and no has tabPage, create new tabPage
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child form caption
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!tabForms.Visible) tabForms.Visible = true;
            }
        }
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }
        private void syntaxHighlighter1_TextChanged(object sender, EventArgs e)
        {
            //syntaxHighlighter1.ProcessAllLines();
        }

        private void 새창ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorForm f1 = new EditorForm();
            f1.MdiParent = this;
            f1.Show();
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabForms.SelectedTab != null) && (tabForms.SelectedTab.Tag != null))
                (tabForms.SelectedTab.Tag as Form).Select();
        }
        */
        #endregion

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 코드빌드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string org_word = syntaxHighlighter1.Text;
            string[] splitted = org_word.Split('\n');
            for (int i = 0; i < splitted.Length; i++)
            {
                /*
                richTextBox1.Text += Translator.replace_word(splitted[i]);
                richTextBox1.Text += "\r\n";
                */
                richTextBox1.Text = Translator.Interpret_bf(syntaxHighlighter1.Text);
            }
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != null)
            {

            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (save_string != "")
            {
                saveFileDialog1.Title = "저장";
                saveFileDialog1.ShowDialog();
            }
            else
            {

            }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "다른 이름으로 저장";
            saveFileDialog1.ShowDialog();
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 실행취소ㅓToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syntaxHighlighter1.Undo();
        }

        private void 다시실행ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syntaxHighlighter1.Redo();
        }

        private void 잘라내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syntaxHighlighter1.Cut();
        }

        private void 복사ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syntaxHighlighter1.Copy();
        }

        private void 붙여넣기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syntaxHighlighter1.Paste();
        }

        private void 모두선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syntaxHighlighter1.SelectAll();
        }

        private void 전체화면ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void 새창ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "새 파일";
        }

        private void savefile(string savestring, string savepos)
        {
            StreamWriter sw = new StreamWriter(savepos);
            sw.Write(savestring);
            sw.Close();
        }

        private void 제품등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void johnscriptStudio정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abx = new AboutBox1();
            abx.ShowDialog();
        }

        private void 온라인도움말ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = "http://jsdn.space/";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch
                (
                 System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void 코드정리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //빌드된 파일 전부 정리하기
        }

        private void 코드조각관리자ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeBlockManager cbm = new CodeBlockManager();
            cbm.ShowDialog();
        }

        private void 업데이트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateManager um = new UpdateManager();
            um.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void 코드조각저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            if(syntaxHighlighter1.SelectedText!=""||syntaxHighlighter1.SelectedText != null)
            {
                AddCode.selcode = syntaxHighlighter1.SelectedText;
            }
            AddCode f = new AddCode();
            f.ShowDialog();
        }
    }
}

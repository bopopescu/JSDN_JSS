using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IronPython;
using IronPython.Hosting;
namespace JSE
{
    public partial class MainForm : Form
    {
        public Regex keyWords = new Regex("abstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for " + "foreach goto if implicit in int interface internal is lock long namespace new null object operator out override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static " + "string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual volatile void while ");
        public string save_string = "";
        public bool isfirst = true;
        public int scrollTop;
        public int[] div_list = new int[10000];
        public string[] div_code = new string[10000];
        int cnt = 0;
        public static Boolean isCurslyBracesKeyPressed = false;
        public MainForm()

        {
            InitializeComponent();
            openFileDialog1.Title = "열기";
        }

        public int getYoffset(HtmlElement el)
        {
            //get element pos
            int yPos = el.OffsetRectangle.Top;

            //get the parents pos
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                yPos += tempEl.OffsetRectangle.Top;
                tempEl = tempEl.OffsetParent;
            }

            return yPos;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.syntaxHighlighter1.AutoCompleteMode;
            button1.FlatAppearance.BorderColor = Color.DodgerBlue;
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
            webBrowser1.Navigate("https://dicontest.herokuapp.com/code_front/qna/qnaFront.html");
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
        #region 메뉴클릭 이벤트
        private void 코드빌드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string org_word = syntaxHighlighter1.Text;
            string[] splitted = org_word.Split('\n');
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var source = engine.CreateScriptSourceFromFile("A.py");
            source.Execute(scope);

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
            WindowState = FormWindowState.Maximized;
        }

        private void 새창ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "새 파일";
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

            if (syntaxHighlighter1.SelectedText != "" || syntaxHighlighter1.SelectedText != null)
            {
                AddCode.selcode = syntaxHighlighter1.SelectedText;
            }
            AddCode f = new AddCode();
            f.ShowDialog();
        }
        private void mP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 재생ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WindowsMediaPlayer wmp = new WindowsMediaPlayer(file);

        }
        #endregion
        private void savefile(string savestring, string savepos)
        {
            StreamWriter sw = new StreamWriter(savepos);
            sw.Write(savestring);
            sw.Close();
        }

        private void syntaxHighlighter1_TextChanged(object sender, EventArgs e)
        {

        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //webBrowser1.Document.Window.AttachEventHandler("onscroll", OnScrollEventHandler);
            /*
            HtmlDocument doc = this.webBrowser1.Document;
            int scrollTop = doc.GetElementsByTagName("HTML")[0].ScrollTop;
            HtmlElement asd = doc.GetElementById("b");
            int a = getYoffset(asd);
            //MessageBox.Show(scrollTop.ToString());
            //MessageBox.Show(a.ToString());
            */

        }
        /*
        public void OnScrollEventHandler(object sender, EventArgs e)
        {
            HtmlDocument doc = webBrowser1.Document;
            scrollTop = doc.GetElementsByTagName("HTML")[0].ScrollTop; //현재위치
            Console.WriteLine(scrollTop.ToString());
            if (isfirst)
            {
                getCode();
                isfirst = false;
            }
            else
            {
                for (int i = 1; i <= cnt; i++)
                {
                    Console.WriteLine(scrollTop.ToString());
                    if (scrollTop < div_list[i] && div_list[i] < scrollTop + 300) //절대좌표를 이용, yPos를 직접비교한다.
                    {//현재위치가 코드 위치보다 작음(더 위쪽) && 코드 위치가 현재 위치에서 300 이내일때
                        syntaxHighlighter1.SelectAll();
                        syntaxHighlighter1.SelectionBackColor = Color.White;
                        HighlightText(syntaxHighlighter1, div_code[i], Color.Yellow);
                    }

                    else if (scrollTop > div_list[i - 1] || scrollTop + 300 < div_list[i - 1])
                    { // 현재위치가 전 코드 위치보다 아래쪽이거나 현재위치+300이 전 코드 위치보다 작음.
                        HighlightText(syntaxHighlighter1, div_code[i - 1], Color.White);
                    }

                }
            }
            
             * 현재 존재하는 Tag의 yOffset을 파악한다.(배열로) - Complete
             * 현재 Scroll된 TopOver yOffset을 파악한다. (Onscroll) - Complete
             * Toppos에서 일정 범위 내에 있는지를 검색한다. - Complete
             * 비교해서 일정 범위 내에 해당하면 비교해서 자동으로 해당하는지 검사한다. - Complete
             * 만약 해당한다면, 자동적으로 Overlay를 띄워주고 만약 아니라면 냅둔다 - BackColor Complete
             * 
             

        }
        */
        /*
        public void getCode()
        {

            HtmlElementCollection theElementCollection = default(HtmlElementCollection);
            theElementCollection = webBrowser1.Document.GetElementsByTagName("div");


            foreach (HtmlElement curElement in theElementCollection)
            {
                Console.WriteLine(curElement.GetAttribute("classname").ToString());
                if (curElement.GetAttribute("classname").ToString() == "__se_code_view se_textarea language-javascript")
                {
                    cnt++;
                    int a = getYoffset(curElement); //현재 태그의 yoffset을 찾아낸다.
                    div_list[cnt] = a;
                    div_code[cnt] = curElement.GetAttribute("InnerText");
                    div_code[cnt] = div_code[cnt].Replace("\r", "");
                    Console.WriteLine(curElement.GetAttribute("InnerText")); //InnerText만을 추출 가능하다.

                }
            }
        }
        */
        /*
        public static void HighlightText(RichTextBox myRtb, string word, Color color)
        {
            int s_start = myRtb.SelectionStart, startIndex = 0, index = 0;

            while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionBackColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }
        */
        private void syntaxHighlighter1_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void syntaxHighlighter1_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            String s = e.KeyChar.ToString();
            int sel = syntaxHighlighter1.SelectionStart;
            switch (s)
            {
                case "(":
                    syntaxHighlighter1.Text = syntaxHighlighter1.Text.Insert(sel, "()");
                    e.Handled = true;
                    syntaxHighlighter1.SelectionStart = sel + 1;
                    break;

                case "{":
                    String t = "{}";
                    syntaxHighlighter1.Text = syntaxHighlighter1.Text.Insert(sel, t);
                    e.Handled = true;
                    syntaxHighlighter1.SelectionStart = sel + t.Length - 1;
                    isCurslyBracesKeyPressed = true;
                    break;

                case "[":
                    syntaxHighlighter1.Text = syntaxHighlighter1.Text.Insert(sel, "[]");
                    e.Handled = true;
                    syntaxHighlighter1.SelectionStart = sel + 1;
                    break;

                case "<":
                    syntaxHighlighter1.Text = syntaxHighlighter1.Text.Insert(sel, "<>");
                    e.Handled = true;
                    syntaxHighlighter1.SelectionStart = sel + 1;
                    break;

                case "\"":
                    syntaxHighlighter1.Text = syntaxHighlighter1.Text.Insert(sel, "\"\"");
                    e.Handled = true;
                    syntaxHighlighter1.SelectionStart = sel + 1;
                    break;

                case "'":
                    syntaxHighlighter1.Text = syntaxHighlighter1.Text.Insert(sel, "''");
                    e.Handled = true;
                    syntaxHighlighter1.SelectionStart = sel + 1;
                    break;

            }
            */
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            button1.Height = splitContainer4.Panel1.Height;
            
        }
        private bool isclicked = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(isclicked)
            {
                button1.Text = "三";
                splitContainer3.Panel2Collapsed = true;
                isclicked = false;
            }
            else
            {
                button1.Text = ">";
                splitContainer3.Panel2Collapsed = false;
                isclicked = true;
            }
            
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Net;

namespace JSE
{
    public partial class MainForm : Form
    {
        public Regex keyWords = new Regex("and del from not while as elif global or with assert else if pass yield break except import print class exec in raise continue finally is return def for lambda try");
        public string save_string = "";
        public static bool isOpen = false;
        public bool isfirst = true;
        public int scrollTop;
        public int[] div_list = new int[10000];
        public string[] div_code = new string[10000];
        public bool isChanged = false;
        int cnt = 0;
        public static Boolean isCurslyBracesKeyPressed = false;
        public MainForm()

        {
            InitializeComponent();
            openFileDialog1.Title = "열기";
            //PopulateTreeView();
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
        public void PopulateTreeView()
        {
            TreeNode rootNode;
            if (ProjectOpt.m_ProjectPath != null)
            {
                DirectoryInfo info = new DirectoryInfo(ProjectOpt.m_ProjectPath);
                if (info.Exists)
                {
                    rootNode = new TreeNode(info.Name);
                    rootNode.Tag = info;
                    GetDirectories((info.GetDirectories()), rootNode);
                    treeView1.Nodes.Add(rootNode);
                }
            }
        }


        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            TreeNode fNode;
            DirectoryInfo[] subSubDirs;
            FileInfo[] subFile;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subFile = subDir.GetFiles();
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }

                foreach (FileInfo fileInfo in subFile)
                {
                    fNode = new TreeNode(fileInfo.Name, 0, 0);
                    fNode.Tag = fileInfo;
                    nodeToAddTo.Nodes[0].Nodes.Add(fNode);
                }

            }

        }

        private void AddFileNode(string filename)
        {
            treeView1.Nodes.Clear();
            TreeNode subFile;
            subFile = new TreeNode(filename, 0, 0);
            treeView1.Nodes.Add(subFile);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.FromArgb(22, 22, 22);
            splitContainer1.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer2.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer3.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer4.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer5.BackColor = Color.FromArgb(19, 19, 19);

            //splitContainer6.BackColor = Color.FromArgb(19, 19, 19);
            //splitContainer7.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer8.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer1.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer2.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer3.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer4.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer5.ForeColor = Color.FromArgb(19, 19, 19);
            //splitContainer6.ForeColor = Color.FromArgb(19, 19, 19);
            //splitContainer7.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer8.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer1.Panel1.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer1.Panel2.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer2.Panel1.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer2.Panel1.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer2.Panel2.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer2.Panel2.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer3.Panel1.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer3.Panel1.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer3.Panel2.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer3.Panel2.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer4.Panel1.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer4.Panel1.ForeColor = Color.FromArgb(19, 19, 19);
            splitContainer4.Panel2.BackColor = Color.FromArgb(19, 19, 19);
            splitContainer4.Panel1Collapsed = true;
            splitContainer4.Panel2.ForeColor = Color.FromArgb(19, 19, 19);
            treeView1.BackColor = Color.FromArgb(22, 22, 22);
            treeView1.ForeColor = Color.White;
            menuStrip1.ForeColor = Color.White;
            syntaxHighlighter1.BackColor = Color.FromArgb(26, 26, 26);
            richTextBox1.BackColor = Color.FromArgb(26, 26, 26);
            richTextBox1.ForeColor = Color.White;
            textBox1.BackColor = richTextBox1.BackColor = Color.FromArgb(26, 26, 26);
            textBox1.ForeColor = Color.White;
            syntaxHighlighter1.ForeColor = Color.White;
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
            syntaxHighlighter1.Settings.KeywordColor = Color.LightBlue;
            syntaxHighlighter1.Settings.CommentColor = Color.LightGreen;
            syntaxHighlighter1.Settings.EnableStrings = false;
            syntaxHighlighter1.Settings.EnableIntegers = false;
            syntaxHighlighter1.CompileKeywords();
            syntaxHighlighter1.ProcessAllLines();
            Console.Write("");
            richTextBox1.Text += "\r\n";
            Translator.translate();
            richTextBox1.Font = new Font("Consolas", 10);
            ;
            //webBrowser1.Navigate("http://iwin247.kr/dictionary/contents");
            webBrowser1.Navigate("http://iwin247.kr/");
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
            DialogResult dr;
            string save;
            if(syntaxHighlighter1.Enabled == false)
            {
                //아직 아무 프로젝트도 안생긴 것.
                return;
            }

            switch (ProjectOpt.Type)
            {
                case "Python":
                    saveFileDialog1.Filter = "*.py|*.py";
                    #region Python_Build
                    if (ProjectOpt.m_ProjectPath == "" || ProjectOpt.m_ProjectPath == null)
                    {
                        saveFileDialog1.DefaultExt = Path.GetExtension(ProjectOpt.m_ProjectPath);
                        saveFileDialog1.Title = "Choose Save Place";
                        saveFileDialog1.FileName = ProjectOpt.m_ProjectPath;
                        dr = saveFileDialog1.ShowDialog();
                        save = saveFileDialog1.FileName;
                    }
                    else
                    {
                        save = ProjectOpt.m_ProjectPath;
                        dr = DialogResult.OK;
                    }

                    if (dr != DialogResult.Cancel)
                    {
                        ProjectOpt.m_ProjectPath = save;
                        StreamWriter sw = new StreamWriter(save, false);
                        for (int i = 0; i < syntaxHighlighter1.Lines.Length; i++)
                        {
                            sw.WriteLine(syntaxHighlighter1.Lines[i]);
                        }
                        sw.Flush();
                        sw.Close();
                    }

                    isChanged = false;
                    // if(ProjectOpt.Type == "Python")
                    // {
                    ProcessStartInfo proInfo = new ProcessStartInfo();
                    Process pro = new Process();
                    proInfo.FileName = @"cmd";
                    proInfo.CreateNoWindow = false;
                    proInfo.WorkingDirectory = Application.StartupPath + @"\Python27";
                    proInfo.UseShellExecute = false;
                    proInfo.RedirectStandardOutput = true;
                    proInfo.RedirectStandardInput = true;
                    proInfo.RedirectStandardError = true;
                    pro.StartInfo = proInfo;
                    pro.Start();
                    File.Copy(ProjectOpt.m_ProjectPath, Application.StartupPath + @"\Python27\a.py", true);
                    pro.StandardInput.Write("python a.py" + Environment.NewLine);//ex> D:\Desktop\Python27\python test1.py
                    pro.StandardInput.WriteLine("exit");
                    StringBuilder returnVal = new StringBuilder();
                    while (!pro.HasExited)
                    {
                        returnVal.Append(pro.StandardOutput.ReadToEnd());
                    }
                    pro.Close();
                    richTextBox1.Text = returnVal.ToString();
                    #endregion
                    break;
                case "C":
                    saveFileDialog1.Filter = "*.c|*.c";
                    #region C_Build
                    if (ProjectOpt.m_ProjectPath == "" || ProjectOpt.m_ProjectPath == null)
                    {
                        saveFileDialog1.DefaultExt = Path.GetExtension(ProjectOpt.m_ProjectPath);
                        saveFileDialog1.Title = "Choose Save Place";
                        saveFileDialog1.FileName = ProjectOpt.m_ProjectPath;
                        dr = saveFileDialog1.ShowDialog();
                        save = saveFileDialog1.FileName;
                    }
                    else
                    {
                        save = ProjectOpt.m_ProjectPath;
                        dr = DialogResult.OK;
                    }

                    if (dr != DialogResult.Cancel)
                    {
                        ProjectOpt.m_ProjectPath = save;
                        StreamWriter sw = new StreamWriter(save, false);
                        for (int i = 0; i < syntaxHighlighter1.Lines.Length; i++)
                        {
                            sw.WriteLine(syntaxHighlighter1.Lines[i]);
                        }
                        sw.Flush();
                        sw.Close();
                    }

                    isChanged = false;
                    // if(ProjectOpt.Type == "Python")
                    // {
                    ProcessStartInfo C_proInfo = new ProcessStartInfo();
                    Process C_pro = new Process();
                    C_proInfo.FileName = @"cmd";
                    C_proInfo.CreateNoWindow = false;
                    C_proInfo.WorkingDirectory = Application.StartupPath + @"\MinGW\bin";
                    C_proInfo.UseShellExecute = false;
                    C_proInfo.RedirectStandardOutput = true;
                    C_proInfo.RedirectStandardInput = true;
                    C_proInfo.RedirectStandardError = true;
                    C_pro.StartInfo = C_proInfo;
                    C_pro.Start();
                    File.Copy(ProjectOpt.m_ProjectPath, Application.StartupPath + @"\MinGW\bin\a.c", true);
                    C_pro.StandardInput.Write("gcc a.c" + Environment.NewLine);//ex> D:\Desktop\Python27\python test1.py
                    C_pro.StandardInput.Write("a.exe" + Environment.NewLine);
                    C_pro.StandardInput.WriteLine("exit" + Environment.NewLine);
                    StringBuilder C_returnVal = new StringBuilder();
                    while (!C_pro.HasExited)
                    {
                        C_returnVal.Append(C_pro.StandardOutput.ReadToEnd());
                    }
                    C_pro.Close();
                    richTextBox1.Text = C_returnVal.ToString();
                    #endregion
                    break;
                case "HTML":
                    saveFileDialog1.Filter = "*.html|*.html";
                    Process.Start(ProjectOpt.m_ProjectPath);
                    break;
                case "JS":
                    saveFileDialog1.Filter = "*.js|*.js";
                    MessageBox.Show(".js 파일은 실행을 지원하지 않습니다.","JSE");
                    break;
                case "CSS":
                    saveFileDialog1.Filter = "*.css|*.css";
                    MessageBox.Show(".css 파일은 실행을 지원하지 않습니다.", "JSE");
                    break;
                default:
                    break;
            }


        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (!(r == DialogResult.Cancel))
            {
                if (openFileDialog1.FileName != null)
                {
                    syntaxHighlighter1.Text = "";
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    ProjectOpt.m_ProjectPath = openFileDialog1.FileName;
                    while (sr.EndOfStream != true)
                    {
                        syntaxHighlighter1.Text += sr.ReadLine();
                        syntaxHighlighter1.Text += Environment.NewLine;
                    }
                    sr.Close();
                    syntaxHighlighter1.ProcessAllLines();
                    AddFileNode(Path.GetFileNameWithoutExtension(ProjectOpt.m_ProjectPath));
                    string ext = Path.GetExtension(ProjectOpt.m_ProjectPath);
                    if(ext.Contains("py"))
                    {
                        ProjectOpt.Type = "Python";
                    }
                    else if (ext.Contains("c"))
                    {
                        ProjectOpt.Type = "C";
                    }
                    else if (ext.Contains("html"))
                    {
                        ProjectOpt.Type = "HTML";
                    }
                    else if (ext.Contains("js"))
                    {
                        ProjectOpt.Type = "JS";
                    }
                    else if (ext.Contains("css"))
                    {
                        ProjectOpt.Type = "CSS";
                    }
                    syntaxHighlighter1.Enabled = true;
                }
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            string save;
            saveFileDialog1.Filter = "*.py|*.py";

            if (ProjectOpt.m_ProjectPath == "" || ProjectOpt.m_ProjectPath == null)
            {
                saveFileDialog1.DefaultExt = Path.GetExtension(ProjectOpt.m_ProjectPath);
                saveFileDialog1.Title = "Choose Save Place";
                saveFileDialog1.FileName = ProjectOpt.m_ProjectPath;
                dr = saveFileDialog1.ShowDialog();
                save = saveFileDialog1.FileName;
            }
            else
            {
                save = ProjectOpt.m_ProjectPath;
                dr = DialogResult.OK;
            }
            if (dr != DialogResult.Cancel)
            {
                StreamWriter sw = new StreamWriter(save, false);
                for (int i = 0; i < syntaxHighlighter1.Lines.Length; i++)
                {
                    sw.WriteLine(syntaxHighlighter1.Lines[i]);
                }
                sw.Flush();
                sw.Close();
            }
            isChanged = false;
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            saveFileDialog1.DefaultExt = Path.GetExtension(ProjectOpt.m_ProjectPath);
            saveFileDialog1.Title = "Choose Save Place";
            dr = saveFileDialog1.ShowDialog();
            string save = saveFileDialog1.FileName;
            if (dr != DialogResult.Cancel)
            {
                StreamWriter sw = new StreamWriter(save, false);
                for (int i = 0; i < syntaxHighlighter1.Lines.Length; i++)
                {
                    sw.WriteLine(syntaxHighlighter1.Lines[i]);
                }
                sw.Flush();
                sw.Close();
            }
            isChanged = false;

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
            //button1.Height = splitContainer4.Panel1.Height;

        }
        private bool isclicked = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (isclicked)
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {/*
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                          {new ListViewItem.ListViewSubItem(item, "Directory"),
                   new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                          { new ListViewItem.ListViewSubItem(item, "File"),
                   new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            */
        }

        private void 새프로젝트PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject n = new NewProject();
            n.ShowDialog();
            treeView1.Nodes.Clear();
            PopulateTreeView();
        }

        private void 새파일FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile n = new NewFile();
            n.ShowDialog();
            treeView1.Nodes.Clear();
            AddFileNode(Path.GetFileNameWithoutExtension(ProjectOpt.m_ProjectPath));
            syntaxHighlighter1.Enabled = true;
            //Text = "JSS 1.0.0.0 - " + ProjectOpt.m_ProjectPath;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer4_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer8_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool m_IsFlipped = true;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (m_IsFlipped)
            {

                button1.Image = JSE.Properties.Resources.arrow;
                m_IsFlipped = false;
                splitContainer4.Panel1Collapsed = false;
            }
            else
            {
                button1.Image = JSE.Properties.Resources.df;

                m_IsFlipped = true;
                splitContainer4.Panel1Collapsed = true;
            }
        }

        private void syntaxHighlighter1_TextChanged_1(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void 파일FToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 빌드BToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void syntaxHighlighter1_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void syntaxHighlighter1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && (e.Control))
            {
                syntaxHighlighter1.Undo();
            }
            if (e.KeyCode == Keys.S && (e.Control))
            {
                saveFileDialog1.DefaultExt = Path.GetExtension(ProjectOpt.m_ProjectPath);
                saveFileDialog1.Title = "Choose Save Place";
                saveFileDialog1.ShowDialog();
                string save = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(save, false);
                for (int i = 0; i < syntaxHighlighter1.Lines.Length; i++)
                {
                    sw.WriteLine(syntaxHighlighter1.Lines[i]);
                }
                sw.Flush();
                sw.Close();
            }
            if (e.KeyCode == Keys.Z && (e.Shift) && (e.Control))
            {
                syntaxHighlighter1.Redo();
            }
            if (e.KeyCode == Keys.X && (e.Control))
            {
                syntaxHighlighter1.Cut();
            }
            if (e.KeyCode == Keys.V && (e.Control))
            {
                syntaxHighlighter1.Paste();
                syntaxHighlighter1.ProcessAllLines();
            }
            if (e.KeyCode == Keys.A && (e.Control))
            {
                syntaxHighlighter1.SelectAll();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer6_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 강ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * TODO : 
             * 서버에 POST request를 보내거나 GET을 때려서 아무튼 response를 받고, string값으로 받아서 그걸 코드 에디터에 띄워 준다.
             */

            HttpWebRequest login_request = (HttpWebRequest)WebRequest.Create("https://testsec.herokuapp.com/");
            string login_postData = "content=SEX";//JsonConvert.SerializeObject(u);
                                                  //login_postData = "drop database;";
            var login_data = Encoding.ASCII.GetBytes(login_postData);
            login_request.Method = "POST";
            login_request.ContentType = "application/x-www-form-urlencoded";

            login_request.ContentLength = login_data.Length;
            using (var stream = login_request.GetRequestStream())
            {
                stream.Write(login_data, 0, login_data.Length);
            }

            var login_response = (HttpWebResponse)login_request.GetResponse();
            var login_responseString = new StreamReader(login_response.GetResponseStream()).ReadToEnd();
            syntaxHighlighter1.Text = login_responseString;
            syntaxHighlighter1.ProcessAllLines();
        }

        private void tabControl1_DrawItem(Object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.FromArgb(19, 19, 19), 4);
            g.DrawRectangle(p, this.tabCode.Bounds);
        }

        private void webBrowser1_DocumentCompleted_1(Object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string txtHtmlView = "";
            HtmlElement elem;
           
            if (webBrowser1.Document != null)
            {
                HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("HTML");
                if (elems.Count == 1)
                {
                    elem = elems[0];
                    string pageSource = elem.OuterHtml;
                    txtHtmlView = pageSource;
                }
                if (txtHtmlView.Contains("codi-code-content"))
                {
                    /*
                     * codi-code-content 안쪽의 내용물을 추출해서 syntaxhighlighter에 띄워준다.                     
                    */
                    HtmlElement htmlElement = webBrowser1.Document.GetElementById("codi-code-content");
                    if (htmlElement == null)
                    {
                        return;
                    }
                    else
                    {
                        DialogResult dr;
                        string save;
                        if (syntaxHighlighter1.Enabled == false)
                        {
                            //아직 아무 프로젝트도 안생긴 것.
                            return;
                        }
                        if (ProjectOpt.m_ProjectPath == "" || ProjectOpt.m_ProjectPath == null)
                        {
                            saveFileDialog1.DefaultExt = Path.GetExtension(ProjectOpt.m_ProjectPath);
                            saveFileDialog1.Title = "Choose Save Place";
                            saveFileDialog1.FileName = ProjectOpt.m_ProjectPath;
                            dr = saveFileDialog1.ShowDialog();
                            save = saveFileDialog1.FileName;
                        }
                        else
                        {
                            save = ProjectOpt.m_ProjectPath;
                            dr = DialogResult.OK;
                        }

                        if (dr != DialogResult.Cancel)
                        {
                            ProjectOpt.m_ProjectPath = save;
                            StreamWriter sw = new StreamWriter(save, false);
                            for (int i = 0; i < syntaxHighlighter1.Lines.Length; i++)
                            {
                                sw.WriteLine(syntaxHighlighter1.Lines[i]);
                            }
                            sw.Flush();
                            sw.Close();
                        }
                        syntaxHighlighter1.Text = webBrowser1.Document.GetElementById("codi-code-content").InnerText;
                    }
                }
                else
                {
                    /*
                     * 그냥 webPage란 거니까, webBrowser로 탐색해준 다음, Focus를 옮겨준다.
                     */
                    if (txtHtmlView.Contains("codi-web"))
                    {
                        webContents.Navigate(webBrowser1.Url, false);
                        tabControl1.SelectedTab = tabWeb;
                    }

                }
            }
        }
    }
}

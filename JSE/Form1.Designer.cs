namespace JSE
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Project");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새창ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다른이름으로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.끝내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.실행취소ㅓToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다시실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.잘라내기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.복사ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.붙여넣기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.모두선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.찾기및바꾸기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.빌드BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.코드빌드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.코드정리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.디버그DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.디버깅시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도구TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.코드조각관리자ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.업데이트ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.옵션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.온라인도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.제품등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.johnscriptStudio정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.코드조각저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.잘라내기ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.복사ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.붙여넣기ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.지우기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.syntaxHighlighter1 = new JSE.SyntaxHighlighter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.편집FToolStripMenuItem,
            this.빌드BToolStripMenuItem,
            this.디버그DToolStripMenuItem,
            this.도구TToolStripMenuItem,
            this.도움말HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1221, 24);
            this.menuStrip1.TabIndex = 2;
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새창ToolStripMenuItem,
            this.열기ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.저장ToolStripMenuItem,
            this.다른이름으로저장ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.끝내기ToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 새창ToolStripMenuItem
            // 
            this.새창ToolStripMenuItem.Name = "새창ToolStripMenuItem";
            this.새창ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.새창ToolStripMenuItem.Text = "새 파일";
            this.새창ToolStripMenuItem.Click += new System.EventHandler(this.새창ToolStripMenuItem_Click);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 다른이름으로저장ToolStripMenuItem
            // 
            this.다른이름으로저장ToolStripMenuItem.Name = "다른이름으로저장ToolStripMenuItem";
            this.다른이름으로저장ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.다른이름으로저장ToolStripMenuItem.Text = "다른 이름으로 저장";
            this.다른이름으로저장ToolStripMenuItem.Click += new System.EventHandler(this.다른이름으로저장ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(175, 6);
            // 
            // 끝내기ToolStripMenuItem
            // 
            this.끝내기ToolStripMenuItem.Name = "끝내기ToolStripMenuItem";
            this.끝내기ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.끝내기ToolStripMenuItem.Text = "끝내기";
            this.끝내기ToolStripMenuItem.Click += new System.EventHandler(this.끝내기ToolStripMenuItem_Click);
            // 
            // 편집FToolStripMenuItem
            // 
            this.편집FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.실행취소ㅓToolStripMenuItem,
            this.다시실행ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.잘라내기ToolStripMenuItem,
            this.복사ToolStripMenuItem,
            this.붙여넣기ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.모두선택ToolStripMenuItem,
            this.toolStripMenuItem5,
            this.찾기및바꾸기ToolStripMenuItem});
            this.편집FToolStripMenuItem.Name = "편집FToolStripMenuItem";
            this.편집FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.편집FToolStripMenuItem.Text = "편집(&F)";
            // 
            // 실행취소ㅓToolStripMenuItem
            // 
            this.실행취소ㅓToolStripMenuItem.Name = "실행취소ㅓToolStripMenuItem";
            this.실행취소ㅓToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.실행취소ㅓToolStripMenuItem.Text = "실행 취소";
            this.실행취소ㅓToolStripMenuItem.Click += new System.EventHandler(this.실행취소ㅓToolStripMenuItem_Click);
            // 
            // 다시실행ToolStripMenuItem
            // 
            this.다시실행ToolStripMenuItem.Name = "다시실행ToolStripMenuItem";
            this.다시실행ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.다시실행ToolStripMenuItem.Text = "다시 실행";
            this.다시실행ToolStripMenuItem.Click += new System.EventHandler(this.다시실행ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(151, 6);
            // 
            // 잘라내기ToolStripMenuItem
            // 
            this.잘라내기ToolStripMenuItem.Name = "잘라내기ToolStripMenuItem";
            this.잘라내기ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.잘라내기ToolStripMenuItem.Text = "잘라내기";
            this.잘라내기ToolStripMenuItem.Click += new System.EventHandler(this.잘라내기ToolStripMenuItem_Click);
            // 
            // 복사ToolStripMenuItem
            // 
            this.복사ToolStripMenuItem.Name = "복사ToolStripMenuItem";
            this.복사ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.복사ToolStripMenuItem.Text = "복사";
            this.복사ToolStripMenuItem.Click += new System.EventHandler(this.복사ToolStripMenuItem_Click);
            // 
            // 붙여넣기ToolStripMenuItem
            // 
            this.붙여넣기ToolStripMenuItem.Name = "붙여넣기ToolStripMenuItem";
            this.붙여넣기ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.붙여넣기ToolStripMenuItem.Text = "붙여넣기";
            this.붙여넣기ToolStripMenuItem.Click += new System.EventHandler(this.붙여넣기ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(151, 6);
            // 
            // 모두선택ToolStripMenuItem
            // 
            this.모두선택ToolStripMenuItem.Name = "모두선택ToolStripMenuItem";
            this.모두선택ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.모두선택ToolStripMenuItem.Text = "모두 선택";
            this.모두선택ToolStripMenuItem.Click += new System.EventHandler(this.모두선택ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(151, 6);
            // 
            // 찾기및바꾸기ToolStripMenuItem
            // 
            this.찾기및바꾸기ToolStripMenuItem.Name = "찾기및바꾸기ToolStripMenuItem";
            this.찾기및바꾸기ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.찾기및바꾸기ToolStripMenuItem.Text = "찾기 및 바꾸기";
            // 
            // 빌드BToolStripMenuItem
            // 
            this.빌드BToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.코드빌드ToolStripMenuItem,
            this.코드정리ToolStripMenuItem});
            this.빌드BToolStripMenuItem.Name = "빌드BToolStripMenuItem";
            this.빌드BToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.빌드BToolStripMenuItem.Text = "빌드(&B)";
            // 
            // 코드빌드ToolStripMenuItem
            // 
            this.코드빌드ToolStripMenuItem.Name = "코드빌드ToolStripMenuItem";
            this.코드빌드ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.코드빌드ToolStripMenuItem.Text = "코드 빌드";
            this.코드빌드ToolStripMenuItem.Click += new System.EventHandler(this.코드빌드ToolStripMenuItem_Click);
            // 
            // 코드정리ToolStripMenuItem
            // 
            this.코드정리ToolStripMenuItem.Name = "코드정리ToolStripMenuItem";
            this.코드정리ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.코드정리ToolStripMenuItem.Text = "코드 정리";
            this.코드정리ToolStripMenuItem.Click += new System.EventHandler(this.코드정리ToolStripMenuItem_Click);
            // 
            // 디버그DToolStripMenuItem
            // 
            this.디버그DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.디버깅시작ToolStripMenuItem});
            this.디버그DToolStripMenuItem.Name = "디버그DToolStripMenuItem";
            this.디버그DToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.디버그DToolStripMenuItem.Text = "디버그(&D)";
            // 
            // 디버깅시작ToolStripMenuItem
            // 
            this.디버깅시작ToolStripMenuItem.Name = "디버깅시작ToolStripMenuItem";
            this.디버깅시작ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.디버깅시작ToolStripMenuItem.Text = "디버깅 시작";
            // 
            // 도구TToolStripMenuItem
            // 
            this.도구TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.코드조각관리자ToolStripMenuItem,
            this.업데이트ToolStripMenuItem,
            this.toolStripMenuItem6,
            this.옵션ToolStripMenuItem});
            this.도구TToolStripMenuItem.Name = "도구TToolStripMenuItem";
            this.도구TToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.도구TToolStripMenuItem.Text = "도구(&T)";
            // 
            // 코드조각관리자ToolStripMenuItem
            // 
            this.코드조각관리자ToolStripMenuItem.Name = "코드조각관리자ToolStripMenuItem";
            this.코드조각관리자ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.코드조각관리자ToolStripMenuItem.Text = "코드 조각 관리자";
            this.코드조각관리자ToolStripMenuItem.Click += new System.EventHandler(this.코드조각관리자ToolStripMenuItem_Click);
            // 
            // 업데이트ToolStripMenuItem
            // 
            this.업데이트ToolStripMenuItem.Name = "업데이트ToolStripMenuItem";
            this.업데이트ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.업데이트ToolStripMenuItem.Text = "확장 및 업데이트";
            this.업데이트ToolStripMenuItem.Click += new System.EventHandler(this.업데이트ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(163, 6);
            // 
            // 옵션ToolStripMenuItem
            // 
            this.옵션ToolStripMenuItem.Name = "옵션ToolStripMenuItem";
            this.옵션ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.옵션ToolStripMenuItem.Text = "옵션";
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.온라인도움말ToolStripMenuItem,
            this.제품등록ToolStripMenuItem,
            this.toolStripMenuItem7,
            this.johnscriptStudio정보ToolStripMenuItem});
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // 온라인도움말ToolStripMenuItem
            // 
            this.온라인도움말ToolStripMenuItem.Name = "온라인도움말ToolStripMenuItem";
            this.온라인도움말ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.온라인도움말ToolStripMenuItem.Text = "온라인 도움말";
            this.온라인도움말ToolStripMenuItem.Click += new System.EventHandler(this.온라인도움말ToolStripMenuItem_Click);
            // 
            // 제품등록ToolStripMenuItem
            // 
            this.제품등록ToolStripMenuItem.Name = "제품등록ToolStripMenuItem";
            this.제품등록ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.제품등록ToolStripMenuItem.Text = "제품 등록";
            this.제품등록ToolStripMenuItem.Click += new System.EventHandler(this.제품등록ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(192, 6);
            // 
            // johnscriptStudio정보ToolStripMenuItem
            // 
            this.johnscriptStudio정보ToolStripMenuItem.Name = "johnscriptStudio정보ToolStripMenuItem";
            this.johnscriptStudio정보ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.johnscriptStudio정보ToolStripMenuItem.Text = "Johnscript Studio 정보";
            this.johnscriptStudio정보ToolStripMenuItem.Click += new System.EventHandler(this.johnscriptStudio정보ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.syntaxHighlighter1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1060, 483);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1060, 112);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "출력";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1221, 483);
            this.splitContainer2.SplitterDistance = 157;
            this.splitContainer2.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "main_node";
            treeNode1.Text = "Project";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(157, 483);
            this.treeView1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.코드조각저장ToolStripMenuItem,
            this.toolStripMenuItem8,
            this.잘라내기ToolStripMenuItem1,
            this.복사ToolStripMenuItem1,
            this.붙여넣기ToolStripMenuItem1,
            this.지우기ToolStripMenuItem,
            this.toolStripMenuItem9});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 126);
            // 
            // 코드조각저장ToolStripMenuItem
            // 
            this.코드조각저장ToolStripMenuItem.Name = "코드조각저장ToolStripMenuItem";
            this.코드조각저장ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.코드조각저장ToolStripMenuItem.Text = "코드 조각 저장";
            this.코드조각저장ToolStripMenuItem.Click += new System.EventHandler(this.코드조각저장ToolStripMenuItem_Click);
            // 
            // 잘라내기ToolStripMenuItem1
            // 
            this.잘라내기ToolStripMenuItem1.Name = "잘라내기ToolStripMenuItem1";
            this.잘라내기ToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.잘라내기ToolStripMenuItem1.Text = "잘라내기";
            // 
            // 복사ToolStripMenuItem1
            // 
            this.복사ToolStripMenuItem1.Name = "복사ToolStripMenuItem1";
            this.복사ToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.복사ToolStripMenuItem1.Text = "복사";
            // 
            // 붙여넣기ToolStripMenuItem1
            // 
            this.붙여넣기ToolStripMenuItem1.Name = "붙여넣기ToolStripMenuItem1";
            this.붙여넣기ToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.붙여넣기ToolStripMenuItem1.Text = "붙여넣기";
            // 
            // 지우기ToolStripMenuItem
            // 
            this.지우기ToolStripMenuItem.Name = "지우기ToolStripMenuItem";
            this.지우기ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.지우기ToolStripMenuItem.Text = "지우기";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(151, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(151, 6);
            // 
            // syntaxHighlighter1
            // 
            this.syntaxHighlighter1.ContextMenuStrip = this.contextMenuStrip1;
            this.syntaxHighlighter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxHighlighter1.Location = new System.Drawing.Point(0, 0);
            this.syntaxHighlighter1.Name = "syntaxHighlighter1";
            this.syntaxHighlighter1.Size = new System.Drawing.Size(1060, 367);
            this.syntaxHighlighter1.TabIndex = 3;
            this.syntaxHighlighter1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 507);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Johnscript Studio v 1.0.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 빌드BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 디버그DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새창ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 끝내기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 실행취소ㅓToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다시실행ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 잘라내기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 복사ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 붙여넣기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 모두선택ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 찾기및바꾸기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 코드빌드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 코드정리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 디버깅시작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 코드조각관리자ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 업데이트ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem 옵션ToolStripMenuItem;
        private SyntaxHighlighter syntaxHighlighter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 온라인도움말ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 제품등록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem johnscriptStudio정보ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 코드조각저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem 잘라내기ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 복사ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 붙여넣기ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 지우기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
    }
}


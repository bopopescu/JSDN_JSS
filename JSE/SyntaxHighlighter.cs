using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
namespace JSE
{
    public partial class SyntaxHighlighter : RichTextBox
    {
        public static Boolean isCurslyBracesKeyPressed = false;
        private static string inpcache = "";
        #region 줄번호 표시용 선언부
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int IParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, POINT wParam, int IParam);
        private const int EC_LEFTMARGIN = 0x1;
        private const int EM_SETMARGINS = 0xD3;
        private const int WM_SIZE = 0x5;
        private const int WM_PAINT = 0x000F;
        private const int EM_GETFIRSTVISIBLELINE = 0xCE;
        private const int EM_GETLINECOUNT = 0x00BA;
        private const int EM_GETLINE = 0x00C4;
        private const int EM_LINELENGTH = 0x00C1;
        private const int EM_POSFROMCHAR = 0x00D6;
        public Graphics g = null;
        private SolidBrush txtBrush = null;
        private SolidBrush marginBrush = null;
        private Pen dotPen = null;
        private Pen solidPen = null;
        #endregion
        public SyntaxHighlighter()
        {
            InitializeComponent();
            this.txtBrush = new SolidBrush(Color.White);
            this.marginBrush = new SolidBrush(Color.FromArgb(22,22,22));
            this.dotPen = new Pen(new SolidBrush(Color.LightSeaGreen));
            this.solidPen = new Pen(new SolidBrush(Color.Indigo));
            this.dotPen.DashStyle = DashStyle.Dot;
            this.solidPen.DashStyle = DashStyle.Solid;
        }

        private SyntaxSettings m_settings = new SyntaxSettings();
        private static bool m_bPaint = true;
        private string m_strLine = "";
        private int m_nContentLength = 0;
        private int m_nLineLength = 0;
        private int m_nLineStart = 0;
        private int m_nLineEnd = 0;
        private string m_strKeywords = "";
        private int m_nCurSelection = 0;

        /// <summary>
        /// 설정들
        /// </summary>
        public SyntaxSettings Settings
        {
            get { return m_settings; }
        }

        /// <summary>
        /// WndProc
        /// </summary>
        /// <param name="m">메세지</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x00f)
            {
                if (m_bPaint)
                    base.WndProc(ref m);
                else
                    m.Result = IntPtr.Zero;
            }
            else
            {
                base.WndProc(ref m);
            }
            
            #region 줄번호 그려주기
            switch (m.Msg)
            {
                case WM_SIZE:
                    //사이즈가바뀌면 재설정
                    g = Graphics.FromHwnd(this.Handle);
                    break;
                case WM_PAINT:
                    if(g == null)
                    {
                        g = Graphics.FromHwnd(this.Handle);
                    }
                    //줄번호가 출력될 영역을 정리한다
                    g.FillRectangle(marginBrush, 0, 0, 30, this.Height);
                    //줄번호와 텍스트 입력 영역 사이의 선?
                    //g.DrawLine(dotPen, 30, 0, 30, this.Height);
                    g.DrawLine(solidPen, 32, 0, 32, this.Height);
                    //현재 보이고 있는 줄의 실제 번호를 구함
                    int firstVisibleLine = SendMessage(this.Handle, EM_GETFIRSTVISIBLELINE, 0, 0);
                    //문서의 전체 줄     길이도 구해야 함
                    int TotalLineCount = SendMessage(this.Handle, EM_GETLINECOUNT, 0, 0);
                    if(TotalLineCount > 0)
                    {
                        //가장 윗쪽 라인
                        int len = SendMessage(this.Handle, EM_LINELENGTH, 0, 0);
                        int secondlineidx = len + 1;
                        POINT point1 = new POINT();
                        POINT point2 = new POINT();
                        SendMessage(this.Handle, EM_POSFROMCHAR, point1, secondlineidx);
                        SendMessage(this.Handle, EM_POSFROMCHAR, point2, 0);
                        Point carePos1 = new Point(point1.x, point1.y);
                        Point carePos2 = new Point(point2.x, point2.y);
                        //Line Height = secondline.y - firstline.y
                        int lineHeight = carePos1.Y - carePos2.Y;
                        int VisibleLineCount = lineHeight == 0 ? 1 : (this.ClientRectangle.Height / lineHeight);
                        for(int i = 0; i < VisibleLineCount && i < TotalLineCount; i++)
                        {
                            //문자열 출력으로 그려내기
                            g.DrawString((firstVisibleLine + i).ToString(), this.Font, txtBrush, 0, 5 + (i * lineHeight));
                        }
                    }
                    break;
                default:
                    break;
            }
            #endregion
            
        }
        protected override void OnTextChanged(EventArgs e)
        {
           
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {/*
            String s = e.KeyChar.ToString();
            int sel = SelectionStart;
            switch (s)
            {
                case "(":
                    Text = Text.Insert(sel, "()");
                    e.Handled = true;
                    SelectionStart = sel + 1;
                    break;

                case "{":
                    String t = "{}";
                    Text = Text.Insert(sel, t);
                    e.Handled = true;
                    SelectionStart = sel + t.Length - 1;
                    isCurslyBracesKeyPressed = true;
                    break;

                case "[":
                    Text = Text.Insert(sel, "[]");
                    e.Handled = true;
                    SelectionStart = sel + 1;
                    break;

                case "<":
                    Text = Text.Insert(sel, "<>");
                    e.Handled = true;
                    SelectionStart = sel + 1;
                    break;

                case "\"":
                    Text = Text.Insert(sel, "\"\"");
                    e.Handled = true;
                    SelectionStart = sel + 1;
                    break;

                case "'":
                    Text = Text.Insert(sel, "''");
                    e.Handled = true;
                    SelectionStart = sel + 1;
                    break;

            }
            base.OnKeyPress(e);
            */
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                int sel = SelectionStart;
                if (e.KeyCode == Keys.Enter)
                {
                    if (isCurslyBracesKeyPressed == true)
                    {
                        Text = Text.Insert(sel, "\n \n");
                        sel += "\n\n".Length;
                        isCurslyBracesKeyPressed = false;
                    }
                }
                SelectionStart = sel;
            }
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                m_nContentLength = this.TextLength;
                int nCurrentSelectionStart = SelectionStart;
                int nCurrentSelectionLength = SelectionLength;

                m_bPaint = false;

                // 라인의 시작지점 찾아보기
                m_nLineStart = nCurrentSelectionStart;
                while ((m_nLineStart > 0) && (Text[m_nLineStart - 1] != '\n'))
                    m_nLineStart--;
                // 현재 라인의 종결지점
                m_nLineEnd = nCurrentSelectionStart;
                while ((m_nLineEnd < Text.Length) && (Text[m_nLineEnd] != '\n'))
                    m_nLineEnd++;
                // 줄의 길이 알아보기
                m_nLineLength = m_nLineEnd - m_nLineStart;
                // 현재 라인 가져오기
                m_strLine = Text.Substring(m_nLineStart, m_nLineLength);
                // 처리
                ProcessLine();
                m_bPaint = true;
            }
        }
        /// <summary>
        /// 현재 줄을 처리
        /// </summary>
        private void ProcessLine()
        {
            // 커서 포지션 확인해준다. 나중에 돌려놓자
            int nPosition = SelectionStart;
            SelectionStart = m_nLineStart;
            SelectionLength = m_nLineLength;
            SelectionColor = Color.White;

            // 키워드로 설정된 것들을 처리
            ProcessRegex(m_strKeywords, Settings.KeywordColor);
            // 숫자들 처리
            if (Settings.EnableIntegers)
                ProcessRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b", Settings.IntegerColor);
            // 문자열들 처리
            if (Settings.EnableStrings)
                ProcessRegex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", Settings.StringColor);
            // 주석들 처리
            if (Settings.EnableComments && !string.IsNullOrEmpty(Settings.Comment))
                ProcessRegex(Settings.Comment + ".*$", Settings.CommentColor);
     
            SelectionStart = nPosition;
            //Text.Insert(nPosition, " ");
            SelectionLength = 0;
            SelectionColor = Color.White;
    
            m_nCurSelection = nPosition;
        }
        /// <summary>
        /// 정규식 처리
        /// </summary>
        /// <param name="strRegex">정규식</param>
        /// <param name="color">색상</param>
        private void ProcessRegex(string strRegex, Color color)
        {
            Regex regKeywords = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match regMatch;

            for (regMatch = regKeywords.Match(m_strLine); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                // 단어 처리
                int nStart = m_nLineStart + regMatch.Index;
                int nLenght = regMatch.Length;
                SelectionStart = nStart;
                SelectionLength = nLenght;
                SelectionColor = color;
            }
        }
        /// <summary>
        /// 키워드를 정규식 표현으로 바꿈.
        /// </summary>
        public void CompileKeywords()
        {
            for (int i = 0; i < Settings.Keywords.Count; i++)
            {
                string strKeyword = Settings.Keywords[i];

                if (i == Settings.Keywords.Count - 1)
                    m_strKeywords += "\\b" + strKeyword + "\\b";
                else
                    m_strKeywords += "\\b" + strKeyword + "\\b|";
            }
        }
        /// <summary>
        /// 전체 라인 한번에 처리(응답 속도 느림)
        /// </summary>
        public void ProcessAllLines()
        {
            m_bPaint = false;

            int nStartPos = 0;
            int i = 0;
            int nOriginalPos = SelectionStart;
            while (i < Lines.Length)
            {
                m_strLine = Lines[i];
                m_nLineStart = nStartPos;
                m_nLineEnd = m_nLineStart + m_strLine.Length;
                ProcessLine();
                i++;
                nStartPos += m_strLine.Length + 1;
            }

            m_bPaint = true;
        }
    }

    /// <summary>
    /// 문법 요소들을 저장
    /// </summary>
    public class SyntaxList
    {
        public List<string> m_rgList = new List<string>();
        public Color m_color = new Color();
    }

    /// <summary>
    /// 키워드별 색상이나 등등 저장
    /// </summary>
    public class SyntaxSettings
    {
        SyntaxList m_rgKeywords = new SyntaxList();
        string m_strComment = "";
        Color m_colorComment = Color.Green;
        Color m_colorString = Color.Gray;
        Color m_colorInteger = Color.Red;
        bool m_bEnableComments = true;
        bool m_bEnableIntegers = true;
        bool m_bEnableStrings = true;

        #region Properties
        /// <summary>
        /// 모든 전체 키워드를 포함하는 리스트
        /// </summary>
        public List<string> Keywords
        {
            get { return m_rgKeywords.m_rgList; }
        }
        /// <summary>
        /// 키워드별 색상
        /// </summary>
        public Color KeywordColor
        {
            get { return m_rgKeywords.m_color; }
            set { m_rgKeywords.m_color = value; }
        }
        /// <summary>
        /// 주석 식별자들
        /// </summary>
        public string Comment
        {
            get { return m_strComment; }
            set { m_strComment = value; }
        }
        /// <summary>
        /// 주석에 입힐 색깔
        /// </summary>
        public Color CommentColor
        {
            get { return m_colorComment; }
            set { m_colorComment = value; }
        }
        /// <summary>
        /// true => 주석에 대한 색상 처리 활성화
        /// false => 주석문 색상 처리 비활성화
        /// </summary>
        public bool EnableComments
        {
            get { return m_bEnableComments; }
            set { m_bEnableComments = value; }
        }
        /// <summary>
        /// true => 숫자들 색상 따로 처리함
        /// false => 숫자들 색상 따로 처리 안함
        /// </summary>
        public bool EnableIntegers
        {
            get { return m_bEnableIntegers; }
            set { m_bEnableIntegers = value; }
        }
        /// <summary>
        /// true => string종류들은 따로 처리해줌
        /// false => string종류들도 색 안칠함
        /// </summary>
        public bool EnableStrings
        {
            get { return m_bEnableStrings; }
            set { m_bEnableStrings = value; }
        }
        /// <summary>
        /// string 형들에 입힐 색상
        /// </summary>
        public Color StringColor
        {
            get { return m_colorString; }
            set { m_colorString = value; }
        }
        /// <summary>
        /// 정수형에 입힐 색상
        /// </summary>
        public Color IntegerColor
        {
            get { return m_colorInteger; }
            set { m_colorInteger = value; }
        }
        #endregion
    }
}

namespace JSE
{
    partial class RibbonForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.syntaxHighlighter1 = new JSE.SyntaxHighlighter();
            this.SuspendLayout();
            // 
            // syntaxHighlighter1
            // 
            this.syntaxHighlighter1.Location = new System.Drawing.Point(17, 13);
            this.syntaxHighlighter1.Name = "syntaxHighlighter1";
            this.syntaxHighlighter1.Size = new System.Drawing.Size(941, 158);
            this.syntaxHighlighter1.TabIndex = 0;
            this.syntaxHighlighter1.Text = "";
            // 
            // RibbonForm1
            // 
            this.ClientSize = new System.Drawing.Size(975, 185);
            this.Controls.Add(this.syntaxHighlighter1);
            this.Name = "RibbonForm1";
            this.Text = "RibbonForm1";
            this.ResumeLayout(false);

        }

        #endregion

        private SyntaxHighlighter syntaxHighlighter1;
    }
}
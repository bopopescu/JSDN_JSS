namespace JSE
{
    partial class EditorForm
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
            this.syntaxHighlighter1.AcceptsTab = true;
            this.syntaxHighlighter1.AutoWordSelection = true;
            this.syntaxHighlighter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxHighlighter1.HideSelection = false;
            this.syntaxHighlighter1.Location = new System.Drawing.Point(0, 0);
            this.syntaxHighlighter1.Name = "syntaxHighlighter1";
            this.syntaxHighlighter1.Size = new System.Drawing.Size(1044, 396);
            this.syntaxHighlighter1.TabIndex = 0;
            this.syntaxHighlighter1.Text = "";
            this.syntaxHighlighter1.WordWrap = false;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 396);
            this.Controls.Add(this.syntaxHighlighter1);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SyntaxHighlighter syntaxHighlighter1;
    }
}
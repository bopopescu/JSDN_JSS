namespace JSE
{
    partial class StartingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingForm));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.versionlabel = new System.Windows.Forms.Label();
            this.buildname = new System.Windows.Forms.Label();
            this.companylabel = new System.Windows.Forms.Label();
            this.culturelabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 236);
            this.progressBar1.MarqueeAnimationSpeed = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(508, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(237, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "JohnScript Studio™";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // versionlabel
            // 
            this.versionlabel.AutoSize = true;
            this.versionlabel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.versionlabel.ForeColor = System.Drawing.Color.White;
            this.versionlabel.Location = new System.Drawing.Point(240, 143);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(96, 21);
            this.versionlabel.TabIndex = 3;
            this.versionlabel.Text = "버전 1.0.0.0";
            this.versionlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buildname
            // 
            this.buildname.AutoSize = true;
            this.buildname.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buildname.ForeColor = System.Drawing.Color.White;
            this.buildname.Location = new System.Drawing.Point(241, 49);
            this.buildname.Name = "buildname";
            this.buildname.Size = new System.Drawing.Size(83, 15);
            this.buildname.TabIndex = 4;
            this.buildname.Text = "빌드 코드네임";
            this.buildname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // companylabel
            // 
            this.companylabel.AutoSize = true;
            this.companylabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.companylabel.ForeColor = System.Drawing.Color.White;
            this.companylabel.Location = new System.Drawing.Point(241, 173);
            this.companylabel.Name = "companylabel";
            this.companylabel.Size = new System.Drawing.Size(43, 15);
            this.companylabel.TabIndex = 5;
            this.companylabel.Text = "회사명";
            this.companylabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // culturelabel
            // 
            this.culturelabel.AutoSize = true;
            this.culturelabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.culturelabel.ForeColor = System.Drawing.Color.White;
            this.culturelabel.Location = new System.Drawing.Point(241, 197);
            this.culturelabel.Name = "culturelabel";
            this.culturelabel.Size = new System.Drawing.Size(43, 15);
            this.culturelabel.TabIndex = 7;
            this.culturelabel.Text = "문화권";
            this.culturelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(534, 263);
            this.Controls.Add(this.culturelabel);
            this.Controls.Add(this.companylabel);
            this.Controls.Add(this.buildname);
            this.Controls.Add(this.versionlabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartingForm";
            this.Load += new System.EventHandler(this.StartingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.Label buildname;
        private System.Windows.Forms.Label companylabel;
        private System.Windows.Forms.Label culturelabel;
        private System.Windows.Forms.Timer timer1;
    }
}
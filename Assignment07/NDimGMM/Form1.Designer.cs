namespace GMM
{
    partial class Form1
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
         this.voPB = new System.Windows.Forms.PictureBox();
         this.btnGMMND = new System.Windows.Forms.Button();
         this.txtNumClusters = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.voBtnBrowse = new System.Windows.Forms.Button();
         this.voLB = new System.Windows.Forms.ListBox();
         this.label2 = new System.Windows.Forms.Label();
         this.voBtnShowBall = new System.Windows.Forms.Button();
         this.voBtnSwarm = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.voResult = new System.Windows.Forms.ListBox();
         ((System.ComponentModel.ISupportInitialize)(this.voPB)).BeginInit();
         this.SuspendLayout();
         // 
         // voPB
         // 
         this.voPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.voPB.Location = new System.Drawing.Point(170, 10);
         this.voPB.Margin = new System.Windows.Forms.Padding(1);
         this.voPB.Name = "voPB";
         this.voPB.Size = new System.Drawing.Size(877, 597);
         this.voPB.TabIndex = 5;
         this.voPB.TabStop = false;
         // 
         // btnGMMND
         // 
         this.btnGMMND.Location = new System.Drawing.Point(10, 101);
         this.btnGMMND.Margin = new System.Windows.Forms.Padding(1);
         this.btnGMMND.Name = "btnGMMND";
         this.btnGMMND.Size = new System.Drawing.Size(158, 25);
         this.btnGMMND.TabIndex = 6;
         this.btnGMMND.Text = "GMM ND";
         this.btnGMMND.UseVisualStyleBackColor = true;
         this.btnGMMND.Click += new System.EventHandler(this.btnGMMND_Click);
         // 
         // txtNumClusters
         // 
         this.txtNumClusters.Location = new System.Drawing.Point(108, 79);
         this.txtNumClusters.Margin = new System.Windows.Forms.Padding(1);
         this.txtNumClusters.Name = "txtNumClusters";
         this.txtNumClusters.Size = new System.Drawing.Size(34, 20);
         this.txtNumClusters.TabIndex = 7;
         this.txtNumClusters.Text = "4";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(10, 82);
         this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(96, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Number of Clusters";
         // 
         // voBtnBrowse
         // 
         this.voBtnBrowse.Location = new System.Drawing.Point(10, 10);
         this.voBtnBrowse.Margin = new System.Windows.Forms.Padding(1);
         this.voBtnBrowse.Name = "voBtnBrowse";
         this.voBtnBrowse.Size = new System.Drawing.Size(158, 25);
         this.voBtnBrowse.TabIndex = 9;
         this.voBtnBrowse.Text = "Browse";
         this.voBtnBrowse.UseVisualStyleBackColor = true;
         this.voBtnBrowse.Click += new System.EventHandler(this.voBtnBrowse_Click);
         // 
         // voLB
         // 
         this.voLB.FormattingEnabled = true;
         this.voLB.Location = new System.Drawing.Point(10, 143);
         this.voLB.Name = "voLB";
         this.voLB.Size = new System.Drawing.Size(156, 134);
         this.voLB.TabIndex = 10;
         this.voLB.SelectedIndexChanged += new System.EventHandler(this.voLB_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(10, 127);
         this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(47, 13);
         this.label2.TabIndex = 11;
         this.label2.Text = "Clusters:";
         // 
         // voBtnShowBall
         // 
         this.voBtnShowBall.Location = new System.Drawing.Point(10, 281);
         this.voBtnShowBall.Margin = new System.Windows.Forms.Padding(1);
         this.voBtnShowBall.Name = "voBtnShowBall";
         this.voBtnShowBall.Size = new System.Drawing.Size(158, 25);
         this.voBtnShowBall.TabIndex = 12;
         this.voBtnShowBall.Text = "Show Tennis Ball";
         this.voBtnShowBall.UseVisualStyleBackColor = true;
         this.voBtnShowBall.Click += new System.EventHandler(this.voBtnShowBall_Click);
         // 
         // voBtnSwarm
         // 
         this.voBtnSwarm.Location = new System.Drawing.Point(10, 359);
         this.voBtnSwarm.Margin = new System.Windows.Forms.Padding(1);
         this.voBtnSwarm.Name = "voBtnSwarm";
         this.voBtnSwarm.Size = new System.Drawing.Size(158, 25);
         this.voBtnSwarm.TabIndex = 13;
         this.voBtnSwarm.Text = "Swarm GMM ND";
         this.voBtnSwarm.UseVisualStyleBackColor = true;
         this.voBtnSwarm.Click += new System.EventHandler(this.voBtnSwarm_Click);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(10, 385);
         this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(47, 13);
         this.label3.TabIndex = 15;
         this.label3.Text = "Clusters:";
         // 
         // voResult
         // 
         this.voResult.FormattingEnabled = true;
         this.voResult.Location = new System.Drawing.Point(10, 401);
         this.voResult.Name = "voResult";
         this.voResult.Size = new System.Drawing.Size(156, 134);
         this.voResult.TabIndex = 14;
         this.voResult.SelectedIndexChanged += new System.EventHandler(this.voResult_SelectedIndexChanged);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1057, 617);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.voResult);
         this.Controls.Add(this.voBtnSwarm);
         this.Controls.Add(this.voBtnShowBall);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.voLB);
         this.Controls.Add(this.voBtnBrowse);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.txtNumClusters);
         this.Controls.Add(this.btnGMMND);
         this.Controls.Add(this.voPB);
         this.Margin = new System.Windows.Forms.Padding(1);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.voPB)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox voPB;
        private System.Windows.Forms.Button btnGMMND;
        private System.Windows.Forms.TextBox txtNumClusters;
        private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button voBtnBrowse;
      private System.Windows.Forms.ListBox voLB;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button voBtnShowBall;
      private System.Windows.Forms.Button voBtnSwarm;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ListBox voResult;
   }
}


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
            this.btnTestMM = new System.Windows.Forms.Button();
            this.btnTestClass = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.btnGMMND = new System.Windows.Forms.Button();
            this.txtNumClusters = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTestMM
            // 
            this.btnTestMM.Location = new System.Drawing.Point(60, 41);
            this.btnTestMM.Name = "btnTestMM";
            this.btnTestMM.Size = new System.Drawing.Size(349, 58);
            this.btnTestMM.TabIndex = 0;
            this.btnTestMM.Text = "GMM 1D";
            this.btnTestMM.UseVisualStyleBackColor = true;
            this.btnTestMM.Click += new System.EventHandler(this.btnTestMM_Click);
            // 
            // btnTestClass
            // 
            this.btnTestClass.Location = new System.Drawing.Point(60, 219);
            this.btnTestClass.Name = "btnTestClass";
            this.btnTestClass.Size = new System.Drawing.Size(349, 53);
            this.btnTestClass.TabIndex = 1;
            this.btnTestClass.Text = "Test Class";
            this.btnTestClass.UseVisualStyleBackColor = true;
            this.btnTestClass.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(263, 163);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(146, 38);
            this.txtNum.TabIndex = 2;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(67, 163);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(190, 32);
            this.lblNum.TabIndex = 3;
            this.lblNum.Text = "Enter Number";
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(452, 41);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(1657, 1066);
            this.pic1.TabIndex = 5;
            this.pic1.TabStop = false;
            // 
            // btnGMMND
            // 
            this.btnGMMND.Location = new System.Drawing.Point(60, 660);
            this.btnGMMND.Name = "btnGMMND";
            this.btnGMMND.Size = new System.Drawing.Size(349, 60);
            this.btnGMMND.TabIndex = 6;
            this.btnGMMND.Text = "GMM ND";
            this.btnGMMND.UseVisualStyleBackColor = true;
            this.btnGMMND.Click += new System.EventHandler(this.btnGMMND_Click);
            // 
            // txtNumClusters
            // 
            this.txtNumClusters.Location = new System.Drawing.Point(326, 606);
            this.txtNumClusters.Name = "txtNumClusters";
            this.txtNumClusters.Size = new System.Drawing.Size(83, 38);
            this.txtNumClusters.TabIndex = 7;
            this.txtNumClusters.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 612);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "number of Clusters";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2166, 1154);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumClusters);
            this.Controls.Add(this.btnGMMND);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.btnTestClass);
            this.Controls.Add(this.btnTestMM);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestMM;
        private System.Windows.Forms.Button btnTestClass;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.Button btnGMMND;
        private System.Windows.Forms.TextBox txtNumClusters;
        private System.Windows.Forms.Label label1;
    }
}


namespace TSGAMT2010
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
            this.components = new System.ComponentModel.Container();
            this.tabTSGA = new System.Windows.Forms.TabControl();
            this.tabTSGAST = new System.Windows.Forms.TabPage();
            this.btnStopGA = new System.Windows.Forms.Button();
            this.btnRunGA = new System.Windows.Forms.Button();
            this.btnEndCapture = new System.Windows.Forms.Button();
            this.btnStartCapture = new System.Windows.Forms.Button();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.tabTSGAMT = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.grpGASettings = new System.Windows.Forms.GroupBox();
            this.lblNumCities = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCrossOver = new System.Windows.Forms.Label();
            this.txtMutationRate = new System.Windows.Forms.TextBox();
            this.txtCrossOverRate = new System.Windows.Forms.TextBox();
            this.grpBestResult = new System.Windows.Forms.GroupBox();
            this.lblBestResult = new System.Windows.Forms.Label();
            this.picMap0 = new System.Windows.Forms.PictureBox();
            this.picMap1 = new System.Windows.Forms.PictureBox();
            this.lblThreadMonitored = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.optT1 = new System.Windows.Forms.RadioButton();
            this.optT2 = new System.Windows.Forms.RadioButton();
            this.optT3 = new System.Windows.Forms.RadioButton();
            this.optT4 = new System.Windows.Forms.RadioButton();
            this.lblBestResult0 = new System.Windows.Forms.Label();
            this.lblBestResult1 = new System.Windows.Forms.Label();
            this.lblBestResult2 = new System.Windows.Forms.Label();
            this.lblBestResult3 = new System.Windows.Forms.Label();
            this.grpThreads = new System.Windows.Forms.GroupBox();
            this.btnStartThreadsXchg = new System.Windows.Forms.Button();
            this.btnStartThreads = new System.Windows.Forms.Button();
            this.btnStopThreads = new System.Windows.Forms.Button();
            this.opt2 = new System.Windows.Forms.RadioButton();
            this.opt3 = new System.Windows.Forms.RadioButton();
            this.opt4 = new System.Windows.Forms.RadioButton();
            this.tabTSGA.SuspendLayout();
            this.tabTSGAST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.tabTSGAMT.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpGASettings.SuspendLayout();
            this.grpBestResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grpThreads.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTSGA
            // 
            this.tabTSGA.Controls.Add(this.tabTSGAST);
            this.tabTSGA.Controls.Add(this.tabTSGAMT);
            this.tabTSGA.Location = new System.Drawing.Point(5, 40);
            this.tabTSGA.Name = "tabTSGA";
            this.tabTSGA.SelectedIndex = 0;
            this.tabTSGA.Size = new System.Drawing.Size(623, 508);
            this.tabTSGA.TabIndex = 0;
            this.tabTSGA.SelectedIndexChanged += new System.EventHandler(this.tabTSGA_SelectedIndexChanged);
            // 
            // tabTSGAST
            // 
            this.tabTSGAST.Controls.Add(this.btnStopGA);
            this.tabTSGAST.Controls.Add(this.btnRunGA);
            this.tabTSGAST.Controls.Add(this.btnEndCapture);
            this.tabTSGAST.Controls.Add(this.btnStartCapture);
            this.tabTSGAST.Controls.Add(this.picMap);
            this.tabTSGAST.Location = new System.Drawing.Point(4, 25);
            this.tabTSGAST.Name = "tabTSGAST";
            this.tabTSGAST.Padding = new System.Windows.Forms.Padding(3);
            this.tabTSGAST.Size = new System.Drawing.Size(615, 479);
            this.tabTSGAST.TabIndex = 0;
            this.tabTSGAST.Text = "TSGA (Single Threaded)";
            this.tabTSGAST.UseVisualStyleBackColor = true;
            // 
            // btnStopGA
            // 
            this.btnStopGA.BackColor = System.Drawing.Color.Red;
            this.btnStopGA.ForeColor = System.Drawing.Color.White;
            this.btnStopGA.Location = new System.Drawing.Point(536, 6);
            this.btnStopGA.Name = "btnStopGA";
            this.btnStopGA.Size = new System.Drawing.Size(75, 29);
            this.btnStopGA.TabIndex = 5;
            this.btnStopGA.Text = "Stop GA";
            this.btnStopGA.UseVisualStyleBackColor = false;
            // 
            // btnRunGA
            // 
            this.btnRunGA.BackColor = System.Drawing.Color.White;
            this.btnRunGA.Location = new System.Drawing.Point(445, 6);
            this.btnRunGA.Name = "btnRunGA";
            this.btnRunGA.Size = new System.Drawing.Size(75, 30);
            this.btnRunGA.TabIndex = 1;
            this.btnRunGA.Text = "Run GA";
            this.btnRunGA.UseVisualStyleBackColor = false;
            this.btnRunGA.Click += new System.EventHandler(this.btnRunGA_Click);
            // 
            // btnEndCapture
            // 
            this.btnEndCapture.BackColor = System.Drawing.Color.Blue;
            this.btnEndCapture.ForeColor = System.Drawing.Color.White;
            this.btnEndCapture.Location = new System.Drawing.Point(162, 6);
            this.btnEndCapture.Name = "btnEndCapture";
            this.btnEndCapture.Size = new System.Drawing.Size(146, 29);
            this.btnEndCapture.TabIndex = 4;
            this.btnEndCapture.Text = "End Route Capture";
            this.btnEndCapture.UseVisualStyleBackColor = false;
            this.btnEndCapture.Click += new System.EventHandler(this.btnEndCapture_Click);
            // 
            // btnStartCapture
            // 
            this.btnStartCapture.BackColor = System.Drawing.Color.White;
            this.btnStartCapture.ForeColor = System.Drawing.Color.Black;
            this.btnStartCapture.Location = new System.Drawing.Point(6, 6);
            this.btnStartCapture.Name = "btnStartCapture";
            this.btnStartCapture.Size = new System.Drawing.Size(150, 29);
            this.btnStartCapture.TabIndex = 3;
            this.btnStartCapture.Text = "Start Route Capture";
            this.btnStartCapture.UseVisualStyleBackColor = false;
            this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
            // 
            // picMap
            // 
            this.picMap.Location = new System.Drawing.Point(6, 41);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(606, 432);
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseDown);
            // 
            // tabTSGAMT
            // 
            this.tabTSGAMT.Controls.Add(this.groupBox3);
            this.tabTSGAMT.Controls.Add(this.lblThreadMonitored);
            this.tabTSGAMT.Controls.Add(this.picMap1);
            this.tabTSGAMT.Controls.Add(this.picMap0);
            this.tabTSGAMT.Location = new System.Drawing.Point(4, 25);
            this.tabTSGAMT.Name = "tabTSGAMT";
            this.tabTSGAMT.Padding = new System.Windows.Forms.Padding(3);
            this.tabTSGAMT.Size = new System.Drawing.Size(615, 479);
            this.tabTSGAMT.TabIndex = 1;
            this.tabTSGAMT.Text = "TSGA (Multi-Threaded)";
            this.tabTSGAMT.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatus2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(965, 23);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(250, 18);
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = false;
            this.lblStatus2.Font = new System.Drawing.Font("Tahoma", 7F);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(500, 18);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(188, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Genetic Optimization of TSGA (by AM)";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // grpGASettings
            // 
            this.grpGASettings.Controls.Add(this.lblNumCities);
            this.grpGASettings.Controls.Add(this.label2);
            this.grpGASettings.Controls.Add(this.label3);
            this.grpGASettings.Controls.Add(this.lblCrossOver);
            this.grpGASettings.Controls.Add(this.txtMutationRate);
            this.grpGASettings.Controls.Add(this.txtCrossOverRate);
            this.grpGASettings.Location = new System.Drawing.Point(635, 40);
            this.grpGASettings.Name = "grpGASettings";
            this.grpGASettings.Size = new System.Drawing.Size(319, 117);
            this.grpGASettings.TabIndex = 5;
            this.grpGASettings.TabStop = false;
            this.grpGASettings.Text = "GA Settings";
            // 
            // lblNumCities
            // 
            this.lblNumCities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumCities.Location = new System.Drawing.Point(137, 18);
            this.lblNumCities.Name = "lblNumCities";
            this.lblNumCities.Size = new System.Drawing.Size(86, 23);
            this.lblNumCities.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of Cities";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "MutationRate";
            // 
            // lblCrossOver
            // 
            this.lblCrossOver.AutoSize = true;
            this.lblCrossOver.Location = new System.Drawing.Point(25, 58);
            this.lblCrossOver.Name = "lblCrossOver";
            this.lblCrossOver.Size = new System.Drawing.Size(106, 17);
            this.lblCrossOver.TabIndex = 2;
            this.lblCrossOver.Text = "Crossover Rate";
            // 
            // txtMutationRate
            // 
            this.txtMutationRate.Location = new System.Drawing.Point(137, 88);
            this.txtMutationRate.Name = "txtMutationRate";
            this.txtMutationRate.Size = new System.Drawing.Size(83, 22);
            this.txtMutationRate.TabIndex = 1;
            // 
            // txtCrossOverRate
            // 
            this.txtCrossOverRate.Location = new System.Drawing.Point(137, 58);
            this.txtCrossOverRate.Name = "txtCrossOverRate";
            this.txtCrossOverRate.Size = new System.Drawing.Size(83, 22);
            this.txtCrossOverRate.TabIndex = 0;
            // 
            // grpBestResult
            // 
            this.grpBestResult.Controls.Add(this.lblBestResult3);
            this.grpBestResult.Controls.Add(this.lblBestResult2);
            this.grpBestResult.Controls.Add(this.lblBestResult1);
            this.grpBestResult.Controls.Add(this.lblBestResult0);
            this.grpBestResult.Controls.Add(this.lblBestResult);
            this.grpBestResult.Location = new System.Drawing.Point(635, 177);
            this.grpBestResult.Name = "grpBestResult";
            this.grpBestResult.Size = new System.Drawing.Size(318, 371);
            this.grpBestResult.TabIndex = 6;
            this.grpBestResult.TabStop = false;
            this.grpBestResult.Text = "Best Result";
            // 
            // lblBestResult
            // 
            this.lblBestResult.Location = new System.Drawing.Point(6, 29);
            this.lblBestResult.Name = "lblBestResult";
            this.lblBestResult.Size = new System.Drawing.Size(310, 259);
            this.lblBestResult.TabIndex = 0;
            // 
            // picMap0
            // 
            this.picMap0.Location = new System.Drawing.Point(15, 15);
            this.picMap0.Name = "picMap0";
            this.picMap0.Size = new System.Drawing.Size(595, 284);
            this.picMap0.TabIndex = 0;
            this.picMap0.TabStop = false;
            // 
            // picMap1
            // 
            this.picMap1.Location = new System.Drawing.Point(15, 325);
            this.picMap1.Name = "picMap1";
            this.picMap1.Size = new System.Drawing.Size(458, 151);
            this.picMap1.TabIndex = 1;
            this.picMap1.TabStop = false;
            // 
            // lblThreadMonitored
            // 
            this.lblThreadMonitored.AutoSize = true;
            this.lblThreadMonitored.Location = new System.Drawing.Point(12, 302);
            this.lblThreadMonitored.Name = "lblThreadMonitored";
            this.lblThreadMonitored.Size = new System.Drawing.Size(160, 17);
            this.lblThreadMonitored.TabIndex = 2;
            this.lblThreadMonitored.Text = "Thread being Monitored";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.optT4);
            this.groupBox3.Controls.Add(this.optT3);
            this.groupBox3.Controls.Add(this.optT2);
            this.groupBox3.Controls.Add(this.optT1);
            this.groupBox3.Location = new System.Drawing.Point(479, 322);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 150);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Choose Thread";
            // 
            // optT1
            // 
            this.optT1.AutoSize = true;
            this.optT1.Location = new System.Drawing.Point(6, 21);
            this.optT1.Name = "optT1";
            this.optT1.Size = new System.Drawing.Size(87, 21);
            this.optT1.TabIndex = 4;
            this.optT1.Text = "Thread 1";
            this.optT1.UseVisualStyleBackColor = true;
            // 
            // optT2
            // 
            this.optT2.AutoSize = true;
            this.optT2.Checked = true;
            this.optT2.Location = new System.Drawing.Point(6, 53);
            this.optT2.Name = "optT2";
            this.optT2.Size = new System.Drawing.Size(87, 21);
            this.optT2.TabIndex = 5;
            this.optT2.TabStop = true;
            this.optT2.Text = "Thread 2";
            this.optT2.UseVisualStyleBackColor = true;
            // 
            // optT3
            // 
            this.optT3.AutoSize = true;
            this.optT3.Location = new System.Drawing.Point(6, 85);
            this.optT3.Name = "optT3";
            this.optT3.Size = new System.Drawing.Size(87, 21);
            this.optT3.TabIndex = 6;
            this.optT3.Text = "Thread 3";
            this.optT3.UseVisualStyleBackColor = true;
            // 
            // optT4
            // 
            this.optT4.AutoSize = true;
            this.optT4.Location = new System.Drawing.Point(6, 112);
            this.optT4.Name = "optT4";
            this.optT4.Size = new System.Drawing.Size(87, 21);
            this.optT4.TabIndex = 7;
            this.optT4.Text = "Thread 4";
            this.optT4.UseVisualStyleBackColor = true;
            // 
            // lblBestResult0
            // 
            this.lblBestResult0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBestResult0.Location = new System.Drawing.Point(12, 40);
            this.lblBestResult0.Name = "lblBestResult0";
            this.lblBestResult0.Size = new System.Drawing.Size(300, 82);
            this.lblBestResult0.TabIndex = 8;
            this.lblBestResult0.Visible = false;
            // 
            // lblBestResult1
            // 
            this.lblBestResult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBestResult1.Location = new System.Drawing.Point(12, 122);
            this.lblBestResult1.Name = "lblBestResult1";
            this.lblBestResult1.Size = new System.Drawing.Size(300, 82);
            this.lblBestResult1.TabIndex = 9;
            this.lblBestResult1.Visible = false;
            // 
            // lblBestResult2
            // 
            this.lblBestResult2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBestResult2.Location = new System.Drawing.Point(12, 204);
            this.lblBestResult2.Name = "lblBestResult2";
            this.lblBestResult2.Size = new System.Drawing.Size(300, 84);
            this.lblBestResult2.TabIndex = 10;
            this.lblBestResult2.Visible = false;
            // 
            // lblBestResult3
            // 
            this.lblBestResult3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBestResult3.Location = new System.Drawing.Point(13, 288);
            this.lblBestResult3.Name = "lblBestResult3";
            this.lblBestResult3.Size = new System.Drawing.Size(300, 88);
            this.lblBestResult3.TabIndex = 11;
            this.lblBestResult3.Visible = false;
            // 
            // grpThreads
            // 
            this.grpThreads.Controls.Add(this.opt4);
            this.grpThreads.Controls.Add(this.opt3);
            this.grpThreads.Controls.Add(this.opt2);
            this.grpThreads.Controls.Add(this.btnStopThreads);
            this.grpThreads.Controls.Add(this.btnStartThreads);
            this.grpThreads.Controls.Add(this.btnStartThreadsXchg);
            this.grpThreads.Location = new System.Drawing.Point(640, 55);
            this.grpThreads.Name = "grpThreads";
            this.grpThreads.Size = new System.Drawing.Size(319, 117);
            this.grpThreads.TabIndex = 6;
            this.grpThreads.TabStop = false;
            this.grpThreads.Text = "Threads";
            // 
            // btnStartThreadsXchg
            // 
            this.btnStartThreadsXchg.BackColor = System.Drawing.Color.White;
            this.btnStartThreadsXchg.ForeColor = System.Drawing.Color.Red;
            this.btnStartThreadsXchg.Location = new System.Drawing.Point(125, 18);
            this.btnStartThreadsXchg.Name = "btnStartThreadsXchg";
            this.btnStartThreadsXchg.Size = new System.Drawing.Size(179, 28);
            this.btnStartThreadsXchg.TabIndex = 6;
            this.btnStartThreadsXchg.Text = "Start Threads (Xchg)";
            this.btnStartThreadsXchg.UseVisualStyleBackColor = false;
            this.btnStartThreadsXchg.Click += new System.EventHandler(this.btnStartThreadsXchg_Click);
            // 
            // btnStartThreads
            // 
            this.btnStartThreads.BackColor = System.Drawing.Color.White;
            this.btnStartThreads.Location = new System.Drawing.Point(125, 52);
            this.btnStartThreads.Name = "btnStartThreads";
            this.btnStartThreads.Size = new System.Drawing.Size(179, 25);
            this.btnStartThreads.TabIndex = 7;
            this.btnStartThreads.Text = "Start Threads (No Xchg)";
            this.btnStartThreads.UseVisualStyleBackColor = false;
            this.btnStartThreads.Click += new System.EventHandler(this.btnStartThreads_Click);
            // 
            // btnStopThreads
            // 
            this.btnStopThreads.BackColor = System.Drawing.Color.Red;
            this.btnStopThreads.ForeColor = System.Drawing.Color.White;
            this.btnStopThreads.Location = new System.Drawing.Point(125, 83);
            this.btnStopThreads.Name = "btnStopThreads";
            this.btnStopThreads.Size = new System.Drawing.Size(179, 28);
            this.btnStopThreads.TabIndex = 8;
            this.btnStopThreads.Text = "Stop All Threads";
            this.btnStopThreads.UseVisualStyleBackColor = false;
            this.btnStopThreads.Click += new System.EventHandler(this.btnStopThreads_Click);
            // 
            // opt2
            // 
            this.opt2.AutoSize = true;
            this.opt2.Location = new System.Drawing.Point(9, 22);
            this.opt2.Name = "opt2";
            this.opt2.Size = new System.Drawing.Size(94, 21);
            this.opt2.TabIndex = 9;
            this.opt2.Text = "2 Threads";
            this.opt2.UseVisualStyleBackColor = true;
            // 
            // opt3
            // 
            this.opt3.AutoSize = true;
            this.opt3.Checked = true;
            this.opt3.Location = new System.Drawing.Point(9, 53);
            this.opt3.Name = "opt3";
            this.opt3.Size = new System.Drawing.Size(94, 21);
            this.opt3.TabIndex = 10;
            this.opt3.TabStop = true;
            this.opt3.Text = "3 Threads";
            this.opt3.UseVisualStyleBackColor = true;
            // 
            // opt4
            // 
            this.opt4.AutoSize = true;
            this.opt4.Location = new System.Drawing.Point(9, 84);
            this.opt4.Name = "opt4";
            this.opt4.Size = new System.Drawing.Size(94, 21);
            this.opt4.TabIndex = 11;
            this.opt4.Text = "4 Threads";
            this.opt4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 577);
            this.Controls.Add(this.grpThreads);
            this.Controls.Add(this.grpBestResult);
            this.Controls.Add(this.grpGASettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabTSGA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabTSGA.ResumeLayout(false);
            this.tabTSGAST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.tabTSGAMT.ResumeLayout(false);
            this.tabTSGAMT.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpGASettings.ResumeLayout(false);
            this.grpGASettings.PerformLayout();
            this.grpBestResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMap0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpThreads.ResumeLayout(false);
            this.grpThreads.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabTSGA;
        private System.Windows.Forms.TabPage tabTSGAST;
        private System.Windows.Forms.TabPage tabTSGAMT;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEndCapture;
        private System.Windows.Forms.Button btnStartCapture;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox grpGASettings;
        private System.Windows.Forms.Label lblNumCities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCrossOver;
        private System.Windows.Forms.TextBox txtMutationRate;
        private System.Windows.Forms.TextBox txtCrossOverRate;
        private System.Windows.Forms.GroupBox grpBestResult;
        private System.Windows.Forms.Button btnStopGA;
        private System.Windows.Forms.Button btnRunGA;
        private System.Windows.Forms.Label lblBestResult;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblThreadMonitored;
        private System.Windows.Forms.PictureBox picMap1;
        private System.Windows.Forms.PictureBox picMap0;
        private System.Windows.Forms.RadioButton optT4;
        private System.Windows.Forms.RadioButton optT3;
        private System.Windows.Forms.RadioButton optT2;
        private System.Windows.Forms.RadioButton optT1;
        private System.Windows.Forms.Label lblBestResult3;
        private System.Windows.Forms.Label lblBestResult2;
        private System.Windows.Forms.Label lblBestResult1;
        private System.Windows.Forms.Label lblBestResult0;
        private System.Windows.Forms.GroupBox grpThreads;
        private System.Windows.Forms.RadioButton opt4;
        private System.Windows.Forms.RadioButton opt3;
        private System.Windows.Forms.RadioButton opt2;
        private System.Windows.Forms.Button btnStopThreads;
        private System.Windows.Forms.Button btnStartThreads;
        private System.Windows.Forms.Button btnStartThreadsXchg;

    }
}


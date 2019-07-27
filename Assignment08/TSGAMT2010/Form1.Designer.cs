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
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.optT4 = new System.Windows.Forms.RadioButton();
         this.optT3 = new System.Windows.Forms.RadioButton();
         this.optT2 = new System.Windows.Forms.RadioButton();
         this.optT1 = new System.Windows.Forms.RadioButton();
         this.lblThreadMonitored = new System.Windows.Forms.Label();
         this.picMap1 = new System.Windows.Forms.PictureBox();
         this.picMap0 = new System.Windows.Forms.PictureBox();
         this.voTSGAWCF = new System.Windows.Forms.TabPage();
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
         this.lblBestResult3 = new System.Windows.Forms.Label();
         this.lblBestResult2 = new System.Windows.Forms.Label();
         this.lblBestResult1 = new System.Windows.Forms.Label();
         this.lblBestResult0 = new System.Windows.Forms.Label();
         this.lblBestResult = new System.Windows.Forms.Label();
         this.grpThreads = new System.Windows.Forms.GroupBox();
         this.opt4 = new System.Windows.Forms.RadioButton();
         this.opt3 = new System.Windows.Forms.RadioButton();
         this.opt2 = new System.Windows.Forms.RadioButton();
         this.btnStopThreads = new System.Windows.Forms.Button();
         this.btnStartThreads = new System.Windows.Forms.Button();
         this.btnStartThreadsXchg = new System.Windows.Forms.Button();
         this.tabTSGA.SuspendLayout();
         this.tabTSGAST.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
         this.tabTSGAMT.SuspendLayout();
         this.groupBox3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picMap1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.picMap0)).BeginInit();
         this.statusStrip1.SuspendLayout();
         this.grpGASettings.SuspendLayout();
         this.grpBestResult.SuspendLayout();
         this.grpThreads.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabTSGA
         // 
         this.tabTSGA.Controls.Add(this.tabTSGAST);
         this.tabTSGA.Controls.Add(this.tabTSGAMT);
         this.tabTSGA.Controls.Add(this.voTSGAWCF);
         this.tabTSGA.Location = new System.Drawing.Point(4, 32);
         this.tabTSGA.Margin = new System.Windows.Forms.Padding(2);
         this.tabTSGA.Name = "tabTSGA";
         this.tabTSGA.SelectedIndex = 0;
         this.tabTSGA.Size = new System.Drawing.Size(467, 413);
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
         this.tabTSGAST.Location = new System.Drawing.Point(4, 22);
         this.tabTSGAST.Margin = new System.Windows.Forms.Padding(2);
         this.tabTSGAST.Name = "tabTSGAST";
         this.tabTSGAST.Padding = new System.Windows.Forms.Padding(2);
         this.tabTSGAST.Size = new System.Drawing.Size(459, 387);
         this.tabTSGAST.TabIndex = 0;
         this.tabTSGAST.Text = "TSGA (Single Threaded)";
         this.tabTSGAST.UseVisualStyleBackColor = true;
         // 
         // btnStopGA
         // 
         this.btnStopGA.BackColor = System.Drawing.Color.Red;
         this.btnStopGA.ForeColor = System.Drawing.Color.White;
         this.btnStopGA.Location = new System.Drawing.Point(402, 5);
         this.btnStopGA.Margin = new System.Windows.Forms.Padding(2);
         this.btnStopGA.Name = "btnStopGA";
         this.btnStopGA.Size = new System.Drawing.Size(56, 24);
         this.btnStopGA.TabIndex = 5;
         this.btnStopGA.Text = "Stop GA";
         this.btnStopGA.UseVisualStyleBackColor = false;
         // 
         // btnRunGA
         // 
         this.btnRunGA.BackColor = System.Drawing.Color.White;
         this.btnRunGA.Location = new System.Drawing.Point(334, 5);
         this.btnRunGA.Margin = new System.Windows.Forms.Padding(2);
         this.btnRunGA.Name = "btnRunGA";
         this.btnRunGA.Size = new System.Drawing.Size(56, 24);
         this.btnRunGA.TabIndex = 1;
         this.btnRunGA.Text = "Run GA";
         this.btnRunGA.UseVisualStyleBackColor = false;
         this.btnRunGA.Click += new System.EventHandler(this.btnRunGA_Click);
         // 
         // btnEndCapture
         // 
         this.btnEndCapture.BackColor = System.Drawing.Color.Blue;
         this.btnEndCapture.ForeColor = System.Drawing.Color.White;
         this.btnEndCapture.Location = new System.Drawing.Point(122, 5);
         this.btnEndCapture.Margin = new System.Windows.Forms.Padding(2);
         this.btnEndCapture.Name = "btnEndCapture";
         this.btnEndCapture.Size = new System.Drawing.Size(110, 24);
         this.btnEndCapture.TabIndex = 4;
         this.btnEndCapture.Text = "End Route Capture";
         this.btnEndCapture.UseVisualStyleBackColor = false;
         this.btnEndCapture.Click += new System.EventHandler(this.btnEndCapture_Click);
         // 
         // btnStartCapture
         // 
         this.btnStartCapture.BackColor = System.Drawing.Color.White;
         this.btnStartCapture.ForeColor = System.Drawing.Color.Black;
         this.btnStartCapture.Location = new System.Drawing.Point(4, 5);
         this.btnStartCapture.Margin = new System.Windows.Forms.Padding(2);
         this.btnStartCapture.Name = "btnStartCapture";
         this.btnStartCapture.Size = new System.Drawing.Size(112, 24);
         this.btnStartCapture.TabIndex = 3;
         this.btnStartCapture.Text = "Start Route Capture";
         this.btnStartCapture.UseVisualStyleBackColor = false;
         this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
         // 
         // picMap
         // 
         this.picMap.Location = new System.Drawing.Point(4, 33);
         this.picMap.Margin = new System.Windows.Forms.Padding(2);
         this.picMap.Name = "picMap";
         this.picMap.Size = new System.Drawing.Size(454, 351);
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
         this.tabTSGAMT.Location = new System.Drawing.Point(4, 22);
         this.tabTSGAMT.Margin = new System.Windows.Forms.Padding(2);
         this.tabTSGAMT.Name = "tabTSGAMT";
         this.tabTSGAMT.Padding = new System.Windows.Forms.Padding(2);
         this.tabTSGAMT.Size = new System.Drawing.Size(459, 387);
         this.tabTSGAMT.TabIndex = 1;
         this.tabTSGAMT.Text = "TSGA (Multi-Threaded)";
         this.tabTSGAMT.UseVisualStyleBackColor = true;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.optT4);
         this.groupBox3.Controls.Add(this.optT3);
         this.groupBox3.Controls.Add(this.optT2);
         this.groupBox3.Controls.Add(this.optT1);
         this.groupBox3.Location = new System.Drawing.Point(359, 262);
         this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox3.Size = new System.Drawing.Size(98, 122);
         this.groupBox3.TabIndex = 3;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Choose Thread";
         // 
         // optT4
         // 
         this.optT4.AutoSize = true;
         this.optT4.Location = new System.Drawing.Point(4, 91);
         this.optT4.Margin = new System.Windows.Forms.Padding(2);
         this.optT4.Name = "optT4";
         this.optT4.Size = new System.Drawing.Size(68, 17);
         this.optT4.TabIndex = 7;
         this.optT4.Text = "Thread 4";
         this.optT4.UseVisualStyleBackColor = true;
         // 
         // optT3
         // 
         this.optT3.AutoSize = true;
         this.optT3.Location = new System.Drawing.Point(4, 69);
         this.optT3.Margin = new System.Windows.Forms.Padding(2);
         this.optT3.Name = "optT3";
         this.optT3.Size = new System.Drawing.Size(68, 17);
         this.optT3.TabIndex = 6;
         this.optT3.Text = "Thread 3";
         this.optT3.UseVisualStyleBackColor = true;
         // 
         // optT2
         // 
         this.optT2.AutoSize = true;
         this.optT2.Checked = true;
         this.optT2.Location = new System.Drawing.Point(4, 43);
         this.optT2.Margin = new System.Windows.Forms.Padding(2);
         this.optT2.Name = "optT2";
         this.optT2.Size = new System.Drawing.Size(68, 17);
         this.optT2.TabIndex = 5;
         this.optT2.TabStop = true;
         this.optT2.Text = "Thread 2";
         this.optT2.UseVisualStyleBackColor = true;
         // 
         // optT1
         // 
         this.optT1.AutoSize = true;
         this.optT1.Location = new System.Drawing.Point(4, 17);
         this.optT1.Margin = new System.Windows.Forms.Padding(2);
         this.optT1.Name = "optT1";
         this.optT1.Size = new System.Drawing.Size(68, 17);
         this.optT1.TabIndex = 4;
         this.optT1.Text = "Thread 1";
         this.optT1.UseVisualStyleBackColor = true;
         // 
         // lblThreadMonitored
         // 
         this.lblThreadMonitored.AutoSize = true;
         this.lblThreadMonitored.Location = new System.Drawing.Point(9, 245);
         this.lblThreadMonitored.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblThreadMonitored.Name = "lblThreadMonitored";
         this.lblThreadMonitored.Size = new System.Drawing.Size(120, 13);
         this.lblThreadMonitored.TabIndex = 2;
         this.lblThreadMonitored.Text = "Thread being Monitored";
         // 
         // picMap1
         // 
         this.picMap1.Location = new System.Drawing.Point(11, 264);
         this.picMap1.Margin = new System.Windows.Forms.Padding(2);
         this.picMap1.Name = "picMap1";
         this.picMap1.Size = new System.Drawing.Size(344, 123);
         this.picMap1.TabIndex = 1;
         this.picMap1.TabStop = false;
         // 
         // picMap0
         // 
         this.picMap0.Location = new System.Drawing.Point(11, 12);
         this.picMap0.Margin = new System.Windows.Forms.Padding(2);
         this.picMap0.Name = "picMap0";
         this.picMap0.Size = new System.Drawing.Size(446, 231);
         this.picMap0.TabIndex = 0;
         this.picMap0.TabStop = false;
         // 
         // voTSGAWCF
         // 
         this.voTSGAWCF.Location = new System.Drawing.Point(4, 22);
         this.voTSGAWCF.Name = "voTSGAWCF";
         this.voTSGAWCF.Size = new System.Drawing.Size(459, 387);
         this.voTSGAWCF.TabIndex = 2;
         this.voTSGAWCF.Text = "TSGA (WCF)";
         this.voTSGAWCF.UseVisualStyleBackColor = true;
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatus2});
         this.statusStrip1.Location = new System.Drawing.Point(0, 446);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
         this.statusStrip1.Size = new System.Drawing.Size(724, 23);
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
         this.label1.Location = new System.Drawing.Point(141, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(281, 20);
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
         this.grpGASettings.Location = new System.Drawing.Point(476, 32);
         this.grpGASettings.Margin = new System.Windows.Forms.Padding(2);
         this.grpGASettings.Name = "grpGASettings";
         this.grpGASettings.Padding = new System.Windows.Forms.Padding(2);
         this.grpGASettings.Size = new System.Drawing.Size(239, 95);
         this.grpGASettings.TabIndex = 5;
         this.grpGASettings.TabStop = false;
         this.grpGASettings.Text = "GA Settings";
         // 
         // lblNumCities
         // 
         this.lblNumCities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblNumCities.Location = new System.Drawing.Point(103, 15);
         this.lblNumCities.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblNumCities.Name = "lblNumCities";
         this.lblNumCities.Size = new System.Drawing.Size(65, 19);
         this.lblNumCities.TabIndex = 5;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(14, 20);
         this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(84, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Number of Cities";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(19, 72);
         this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(71, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "MutationRate";
         // 
         // lblCrossOver
         // 
         this.lblCrossOver.AutoSize = true;
         this.lblCrossOver.Location = new System.Drawing.Point(19, 47);
         this.lblCrossOver.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblCrossOver.Name = "lblCrossOver";
         this.lblCrossOver.Size = new System.Drawing.Size(80, 13);
         this.lblCrossOver.TabIndex = 2;
         this.lblCrossOver.Text = "Crossover Rate";
         // 
         // txtMutationRate
         // 
         this.txtMutationRate.Location = new System.Drawing.Point(103, 72);
         this.txtMutationRate.Margin = new System.Windows.Forms.Padding(2);
         this.txtMutationRate.Name = "txtMutationRate";
         this.txtMutationRate.Size = new System.Drawing.Size(63, 20);
         this.txtMutationRate.TabIndex = 1;
         // 
         // txtCrossOverRate
         // 
         this.txtCrossOverRate.Location = new System.Drawing.Point(103, 47);
         this.txtCrossOverRate.Margin = new System.Windows.Forms.Padding(2);
         this.txtCrossOverRate.Name = "txtCrossOverRate";
         this.txtCrossOverRate.Size = new System.Drawing.Size(63, 20);
         this.txtCrossOverRate.TabIndex = 0;
         // 
         // grpBestResult
         // 
         this.grpBestResult.Controls.Add(this.lblBestResult3);
         this.grpBestResult.Controls.Add(this.lblBestResult2);
         this.grpBestResult.Controls.Add(this.lblBestResult1);
         this.grpBestResult.Controls.Add(this.lblBestResult0);
         this.grpBestResult.Controls.Add(this.lblBestResult);
         this.grpBestResult.Location = new System.Drawing.Point(476, 144);
         this.grpBestResult.Margin = new System.Windows.Forms.Padding(2);
         this.grpBestResult.Name = "grpBestResult";
         this.grpBestResult.Padding = new System.Windows.Forms.Padding(2);
         this.grpBestResult.Size = new System.Drawing.Size(238, 301);
         this.grpBestResult.TabIndex = 6;
         this.grpBestResult.TabStop = false;
         this.grpBestResult.Text = "Best Result";
         // 
         // lblBestResult3
         // 
         this.lblBestResult3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblBestResult3.Location = new System.Drawing.Point(10, 234);
         this.lblBestResult3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblBestResult3.Name = "lblBestResult3";
         this.lblBestResult3.Size = new System.Drawing.Size(226, 72);
         this.lblBestResult3.TabIndex = 11;
         this.lblBestResult3.Visible = false;
         // 
         // lblBestResult2
         // 
         this.lblBestResult2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblBestResult2.Location = new System.Drawing.Point(9, 166);
         this.lblBestResult2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblBestResult2.Name = "lblBestResult2";
         this.lblBestResult2.Size = new System.Drawing.Size(226, 69);
         this.lblBestResult2.TabIndex = 10;
         this.lblBestResult2.Visible = false;
         // 
         // lblBestResult1
         // 
         this.lblBestResult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblBestResult1.Location = new System.Drawing.Point(9, 99);
         this.lblBestResult1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblBestResult1.Name = "lblBestResult1";
         this.lblBestResult1.Size = new System.Drawing.Size(226, 67);
         this.lblBestResult1.TabIndex = 9;
         this.lblBestResult1.Visible = false;
         // 
         // lblBestResult0
         // 
         this.lblBestResult0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.lblBestResult0.Location = new System.Drawing.Point(9, 32);
         this.lblBestResult0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblBestResult0.Name = "lblBestResult0";
         this.lblBestResult0.Size = new System.Drawing.Size(226, 67);
         this.lblBestResult0.TabIndex = 8;
         this.lblBestResult0.Visible = false;
         // 
         // lblBestResult
         // 
         this.lblBestResult.Location = new System.Drawing.Point(4, 24);
         this.lblBestResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblBestResult.Name = "lblBestResult";
         this.lblBestResult.Size = new System.Drawing.Size(232, 210);
         this.lblBestResult.TabIndex = 0;
         // 
         // grpThreads
         // 
         this.grpThreads.Controls.Add(this.opt4);
         this.grpThreads.Controls.Add(this.opt3);
         this.grpThreads.Controls.Add(this.opt2);
         this.grpThreads.Controls.Add(this.btnStopThreads);
         this.grpThreads.Controls.Add(this.btnStartThreads);
         this.grpThreads.Controls.Add(this.btnStartThreadsXchg);
         this.grpThreads.Location = new System.Drawing.Point(480, 45);
         this.grpThreads.Margin = new System.Windows.Forms.Padding(2);
         this.grpThreads.Name = "grpThreads";
         this.grpThreads.Padding = new System.Windows.Forms.Padding(2);
         this.grpThreads.Size = new System.Drawing.Size(239, 95);
         this.grpThreads.TabIndex = 6;
         this.grpThreads.TabStop = false;
         this.grpThreads.Text = "Threads";
         // 
         // opt4
         // 
         this.opt4.AutoSize = true;
         this.opt4.Location = new System.Drawing.Point(7, 68);
         this.opt4.Margin = new System.Windows.Forms.Padding(2);
         this.opt4.Name = "opt4";
         this.opt4.Size = new System.Drawing.Size(73, 17);
         this.opt4.TabIndex = 11;
         this.opt4.Text = "4 Threads";
         this.opt4.UseVisualStyleBackColor = true;
         // 
         // opt3
         // 
         this.opt3.AutoSize = true;
         this.opt3.Checked = true;
         this.opt3.Location = new System.Drawing.Point(7, 43);
         this.opt3.Margin = new System.Windows.Forms.Padding(2);
         this.opt3.Name = "opt3";
         this.opt3.Size = new System.Drawing.Size(73, 17);
         this.opt3.TabIndex = 10;
         this.opt3.TabStop = true;
         this.opt3.Text = "3 Threads";
         this.opt3.UseVisualStyleBackColor = true;
         // 
         // opt2
         // 
         this.opt2.AutoSize = true;
         this.opt2.Location = new System.Drawing.Point(7, 18);
         this.opt2.Margin = new System.Windows.Forms.Padding(2);
         this.opt2.Name = "opt2";
         this.opt2.Size = new System.Drawing.Size(73, 17);
         this.opt2.TabIndex = 9;
         this.opt2.Text = "2 Threads";
         this.opt2.UseVisualStyleBackColor = true;
         // 
         // btnStopThreads
         // 
         this.btnStopThreads.BackColor = System.Drawing.Color.Red;
         this.btnStopThreads.ForeColor = System.Drawing.Color.White;
         this.btnStopThreads.Location = new System.Drawing.Point(94, 67);
         this.btnStopThreads.Margin = new System.Windows.Forms.Padding(2);
         this.btnStopThreads.Name = "btnStopThreads";
         this.btnStopThreads.Size = new System.Drawing.Size(134, 23);
         this.btnStopThreads.TabIndex = 8;
         this.btnStopThreads.Text = "Stop All Threads";
         this.btnStopThreads.UseVisualStyleBackColor = false;
         this.btnStopThreads.Click += new System.EventHandler(this.btnStopThreads_Click);
         // 
         // btnStartThreads
         // 
         this.btnStartThreads.BackColor = System.Drawing.Color.White;
         this.btnStartThreads.Location = new System.Drawing.Point(94, 42);
         this.btnStartThreads.Margin = new System.Windows.Forms.Padding(2);
         this.btnStartThreads.Name = "btnStartThreads";
         this.btnStartThreads.Size = new System.Drawing.Size(134, 20);
         this.btnStartThreads.TabIndex = 7;
         this.btnStartThreads.Text = "Start Threads (No Xchg)";
         this.btnStartThreads.UseVisualStyleBackColor = false;
         this.btnStartThreads.Click += new System.EventHandler(this.btnStartThreads_Click);
         // 
         // btnStartThreadsXchg
         // 
         this.btnStartThreadsXchg.BackColor = System.Drawing.Color.White;
         this.btnStartThreadsXchg.ForeColor = System.Drawing.Color.Red;
         this.btnStartThreadsXchg.Location = new System.Drawing.Point(94, 15);
         this.btnStartThreadsXchg.Margin = new System.Windows.Forms.Padding(2);
         this.btnStartThreadsXchg.Name = "btnStartThreadsXchg";
         this.btnStartThreadsXchg.Size = new System.Drawing.Size(134, 23);
         this.btnStartThreadsXchg.TabIndex = 6;
         this.btnStartThreadsXchg.Text = "Start Threads (Xchg)";
         this.btnStartThreadsXchg.UseVisualStyleBackColor = false;
         this.btnStartThreadsXchg.Click += new System.EventHandler(this.btnStartThreadsXchg_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(724, 469);
         this.Controls.Add(this.grpThreads);
         this.Controls.Add(this.grpBestResult);
         this.Controls.Add(this.grpGASettings);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.tabTSGA);
         this.Margin = new System.Windows.Forms.Padding(2);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.tabTSGA.ResumeLayout(false);
         this.tabTSGAST.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
         this.tabTSGAMT.ResumeLayout(false);
         this.tabTSGAMT.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picMap1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.picMap0)).EndInit();
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.grpGASettings.ResumeLayout(false);
         this.grpGASettings.PerformLayout();
         this.grpBestResult.ResumeLayout(false);
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
      private System.Windows.Forms.TabPage voTSGAWCF;
   }
}


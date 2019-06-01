namespace TPLTest
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
         this.voBtnThreadLikeTask = new System.Windows.Forms.Button();
         this.voBtnThreadAsTask = new System.Windows.Forms.Button();
         this.voStatusStrip = new System.Windows.Forms.StatusStrip();
         this.voLblStatus = new System.Windows.Forms.Label();
         this.voBtnStartThread = new System.Windows.Forms.Button();
         this.voBtnStopThread = new System.Windows.Forms.Button();
         this.voBtnStartTask = new System.Windows.Forms.Button();
         this.voBtnStopTask = new System.Windows.Forms.Button();
         this.voBtnStopTaskC = new System.Windows.Forms.Button();
         this.voBtnStartTaskC = new System.Windows.Forms.Button();
         this.voLblStockPrice = new System.Windows.Forms.Label();
         this.voBtnStopTwoTasks = new System.Windows.Forms.Button();
         this.voBtnStartTwoTasks = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // voBtnThreadLikeTask
         // 
         this.voBtnThreadLikeTask.Location = new System.Drawing.Point(12, 12);
         this.voBtnThreadLikeTask.Name = "voBtnThreadLikeTask";
         this.voBtnThreadLikeTask.Size = new System.Drawing.Size(107, 23);
         this.voBtnThreadLikeTask.TabIndex = 0;
         this.voBtnThreadLikeTask.Text = "Thread Like Task";
         this.voBtnThreadLikeTask.UseVisualStyleBackColor = true;
         this.voBtnThreadLikeTask.Click += new System.EventHandler(this.voBtnThreadLikeTask_Click);
         // 
         // voBtnThreadAsTask
         // 
         this.voBtnThreadAsTask.Location = new System.Drawing.Point(12, 41);
         this.voBtnThreadAsTask.Name = "voBtnThreadAsTask";
         this.voBtnThreadAsTask.Size = new System.Drawing.Size(107, 23);
         this.voBtnThreadAsTask.TabIndex = 1;
         this.voBtnThreadAsTask.Text = "Thread As Task";
         this.voBtnThreadAsTask.UseVisualStyleBackColor = true;
         this.voBtnThreadAsTask.Click += new System.EventHandler(this.voBtnThreadAsTask_Click);
         // 
         // voStatusStrip
         // 
         this.voStatusStrip.Location = new System.Drawing.Point(0, 239);
         this.voStatusStrip.Name = "voStatusStrip";
         this.voStatusStrip.Size = new System.Drawing.Size(492, 22);
         this.voStatusStrip.TabIndex = 2;
         this.voStatusStrip.Text = "statusStrip1";
         // 
         // voLblStatus
         // 
         this.voLblStatus.AutoSize = true;
         this.voLblStatus.Location = new System.Drawing.Point(9, 244);
         this.voLblStatus.Name = "voLblStatus";
         this.voLblStatus.Size = new System.Drawing.Size(0, 13);
         this.voLblStatus.TabIndex = 3;
         // 
         // voBtnStartThread
         // 
         this.voBtnStartThread.Location = new System.Drawing.Point(12, 126);
         this.voBtnStartThread.Name = "voBtnStartThread";
         this.voBtnStartThread.Size = new System.Drawing.Size(128, 23);
         this.voBtnStartThread.TabIndex = 4;
         this.voBtnStartThread.Text = "Start Thread";
         this.voBtnStartThread.UseVisualStyleBackColor = true;
         this.voBtnStartThread.Click += new System.EventHandler(this.voBtnStartThread_Click);
         // 
         // voBtnStopThread
         // 
         this.voBtnStopThread.Location = new System.Drawing.Point(146, 126);
         this.voBtnStopThread.Name = "voBtnStopThread";
         this.voBtnStopThread.Size = new System.Drawing.Size(125, 23);
         this.voBtnStopThread.TabIndex = 5;
         this.voBtnStopThread.Text = "Stop Thread";
         this.voBtnStopThread.UseVisualStyleBackColor = true;
         this.voBtnStopThread.Click += new System.EventHandler(this.voBtnStopThread_Click);
         // 
         // voBtnStartTask
         // 
         this.voBtnStartTask.Location = new System.Drawing.Point(12, 155);
         this.voBtnStartTask.Name = "voBtnStartTask";
         this.voBtnStartTask.Size = new System.Drawing.Size(128, 23);
         this.voBtnStartTask.TabIndex = 6;
         this.voBtnStartTask.Text = "Start Task";
         this.voBtnStartTask.UseVisualStyleBackColor = true;
         this.voBtnStartTask.Click += new System.EventHandler(this.voBtnStartTask_Click);
         // 
         // voBtnStopTask
         // 
         this.voBtnStopTask.Location = new System.Drawing.Point(146, 155);
         this.voBtnStopTask.Name = "voBtnStopTask";
         this.voBtnStopTask.Size = new System.Drawing.Size(125, 23);
         this.voBtnStopTask.TabIndex = 7;
         this.voBtnStopTask.Text = "Stop Task";
         this.voBtnStopTask.UseVisualStyleBackColor = true;
         this.voBtnStopTask.Click += new System.EventHandler(this.voBtnStopTask_Click);
         // 
         // voBtnStopTaskC
         // 
         this.voBtnStopTaskC.Location = new System.Drawing.Point(146, 184);
         this.voBtnStopTaskC.Name = "voBtnStopTaskC";
         this.voBtnStopTaskC.Size = new System.Drawing.Size(125, 23);
         this.voBtnStopTaskC.TabIndex = 9;
         this.voBtnStopTaskC.Text = "Stop Cancellable Task";
         this.voBtnStopTaskC.UseVisualStyleBackColor = true;
         this.voBtnStopTaskC.Click += new System.EventHandler(this.voBtnStopTaskC_Click);
         // 
         // voBtnStartTaskC
         // 
         this.voBtnStartTaskC.Location = new System.Drawing.Point(12, 184);
         this.voBtnStartTaskC.Name = "voBtnStartTaskC";
         this.voBtnStartTaskC.Size = new System.Drawing.Size(128, 23);
         this.voBtnStartTaskC.TabIndex = 8;
         this.voBtnStartTaskC.Text = "Start Cancellable Task";
         this.voBtnStartTaskC.UseVisualStyleBackColor = true;
         this.voBtnStartTaskC.Click += new System.EventHandler(this.voBtnStartTaskC_Click);
         // 
         // voLblStockPrice
         // 
         this.voLblStockPrice.AutoSize = true;
         this.voLblStockPrice.Location = new System.Drawing.Point(445, 244);
         this.voLblStockPrice.Name = "voLblStockPrice";
         this.voLblStockPrice.Size = new System.Drawing.Size(0, 13);
         this.voLblStockPrice.TabIndex = 10;
         this.voLblStockPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
         // 
         // voBtnStopTwoTasks
         // 
         this.voBtnStopTwoTasks.Location = new System.Drawing.Point(146, 213);
         this.voBtnStopTwoTasks.Name = "voBtnStopTwoTasks";
         this.voBtnStopTwoTasks.Size = new System.Drawing.Size(125, 23);
         this.voBtnStopTwoTasks.TabIndex = 12;
         this.voBtnStopTwoTasks.Text = "Stop Two Tasks";
         this.voBtnStopTwoTasks.UseVisualStyleBackColor = true;
         this.voBtnStopTwoTasks.Click += new System.EventHandler(this.voBtnStopTwoTasks_Click);
         // 
         // voBtnStartTwoTasks
         // 
         this.voBtnStartTwoTasks.Location = new System.Drawing.Point(12, 213);
         this.voBtnStartTwoTasks.Name = "voBtnStartTwoTasks";
         this.voBtnStartTwoTasks.Size = new System.Drawing.Size(128, 23);
         this.voBtnStartTwoTasks.TabIndex = 11;
         this.voBtnStartTwoTasks.Text = "Start Two Tasks";
         this.voBtnStartTwoTasks.UseVisualStyleBackColor = true;
         this.voBtnStartTwoTasks.Click += new System.EventHandler(this.voBtnStartTwoTasks_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(492, 261);
         this.Controls.Add(this.voBtnStopTwoTasks);
         this.Controls.Add(this.voBtnStartTwoTasks);
         this.Controls.Add(this.voLblStockPrice);
         this.Controls.Add(this.voBtnStopTaskC);
         this.Controls.Add(this.voBtnStartTaskC);
         this.Controls.Add(this.voBtnStopTask);
         this.Controls.Add(this.voBtnStartTask);
         this.Controls.Add(this.voBtnStopThread);
         this.Controls.Add(this.voBtnStartThread);
         this.Controls.Add(this.voLblStatus);
         this.Controls.Add(this.voStatusStrip);
         this.Controls.Add(this.voBtnThreadAsTask);
         this.Controls.Add(this.voBtnThreadLikeTask);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnThreadLikeTask;
      private System.Windows.Forms.Button voBtnThreadAsTask;
      private System.Windows.Forms.StatusStrip voStatusStrip;
      private System.Windows.Forms.Label voLblStatus;
      private System.Windows.Forms.Button voBtnStartThread;
      private System.Windows.Forms.Button voBtnStopThread;
      private System.Windows.Forms.Button voBtnStartTask;
      private System.Windows.Forms.Button voBtnStopTask;
      private System.Windows.Forms.Button voBtnStopTaskC;
      private System.Windows.Forms.Button voBtnStartTaskC;
      private System.Windows.Forms.Label voLblStockPrice;
      private System.Windows.Forms.Button voBtnStopTwoTasks;
      private System.Windows.Forms.Button voBtnStartTwoTasks;
   }
}


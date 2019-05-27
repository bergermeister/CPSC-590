namespace ProducerConsumer
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
         this.voBtnConsumerStart = new System.Windows.Forms.Button();
         this.voBtnProducerStart = new System.Windows.Forms.Button();
         this.voBtnConsumerMR = new System.Windows.Forms.Button();
         this.voBtnProducerMR = new System.Windows.Forms.Button();
         this.voStatus = new System.Windows.Forms.StatusStrip();
         this.voLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // voBtnConsumerStart
         // 
         this.voBtnConsumerStart.Location = new System.Drawing.Point(12, 12);
         this.voBtnConsumerStart.Name = "voBtnConsumerStart";
         this.voBtnConsumerStart.Size = new System.Drawing.Size(146, 36);
         this.voBtnConsumerStart.TabIndex = 0;
         this.voBtnConsumerStart.Text = "Start Consumer";
         this.voBtnConsumerStart.UseVisualStyleBackColor = true;
         this.voBtnConsumerStart.Click += new System.EventHandler(this.voBtnConsumerStart_Click);
         // 
         // voBtnProducerStart
         // 
         this.voBtnProducerStart.Location = new System.Drawing.Point(218, 12);
         this.voBtnProducerStart.Name = "voBtnProducerStart";
         this.voBtnProducerStart.Size = new System.Drawing.Size(146, 36);
         this.voBtnProducerStart.TabIndex = 1;
         this.voBtnProducerStart.Text = "Start Producer";
         this.voBtnProducerStart.UseVisualStyleBackColor = true;
         this.voBtnProducerStart.Click += new System.EventHandler(this.voBtnProducerStart_Click);
         // 
         // voBtnConsumerMR
         // 
         this.voBtnConsumerMR.Location = new System.Drawing.Point(12, 80);
         this.voBtnConsumerMR.Name = "voBtnConsumerMR";
         this.voBtnConsumerMR.Size = new System.Drawing.Size(146, 36);
         this.voBtnConsumerMR.TabIndex = 2;
         this.voBtnConsumerMR.Text = "Consumer MR";
         this.voBtnConsumerMR.UseVisualStyleBackColor = true;
         this.voBtnConsumerMR.Click += new System.EventHandler(this.voBtnConsumerMR_Click);
         // 
         // voBtnProducerMR
         // 
         this.voBtnProducerMR.Location = new System.Drawing.Point(218, 80);
         this.voBtnProducerMR.Name = "voBtnProducerMR";
         this.voBtnProducerMR.Size = new System.Drawing.Size(146, 36);
         this.voBtnProducerMR.TabIndex = 3;
         this.voBtnProducerMR.Text = "Producer MR";
         this.voBtnProducerMR.UseVisualStyleBackColor = true;
         this.voBtnProducerMR.Click += new System.EventHandler(this.voBtnProducerMR_Click);
         // 
         // voStatus
         // 
         this.voStatus.ImageScalingSize = new System.Drawing.Size(24, 24);
         this.voStatus.Location = new System.Drawing.Point(0, 428);
         this.voStatus.Name = "voStatus";
         this.voStatus.Size = new System.Drawing.Size(800, 22);
         this.voStatus.TabIndex = 4;
         this.voStatus.Text = "statusStrip1";
         // 
         // voLabel
         // 
         this.voLabel.AutoSize = true;
         this.voLabel.Location = new System.Drawing.Point(12, 160);
         this.voLabel.Name = "voLabel";
         this.voLabel.Size = new System.Drawing.Size(0, 20);
         this.voLabel.TabIndex = 5;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.voLabel);
         this.Controls.Add(this.voStatus);
         this.Controls.Add(this.voBtnProducerMR);
         this.Controls.Add(this.voBtnConsumerMR);
         this.Controls.Add(this.voBtnProducerStart);
         this.Controls.Add(this.voBtnConsumerStart);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnConsumerStart;
      private System.Windows.Forms.Button voBtnProducerStart;
      private System.Windows.Forms.Button voBtnConsumerMR;
      private System.Windows.Forms.Button voBtnProducerMR;
      private System.Windows.Forms.StatusStrip voStatus;
      private System.Windows.Forms.Label voLabel;
   }
}


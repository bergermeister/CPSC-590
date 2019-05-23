namespace CrossThreading
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
         this.voBtnStartClock = new System.Windows.Forms.Button();
         this.voLblTime = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // voBtnStartClock
         // 
         this.voBtnStartClock.Location = new System.Drawing.Point(12, 12);
         this.voBtnStartClock.Name = "voBtnStartClock";
         this.voBtnStartClock.Size = new System.Drawing.Size(75, 23);
         this.voBtnStartClock.TabIndex = 0;
         this.voBtnStartClock.Text = "Start Clock";
         this.voBtnStartClock.UseVisualStyleBackColor = true;
         this.voBtnStartClock.Click += new System.EventHandler(this.voBtnStartClock_Click);
         // 
         // voLblTime
         // 
         this.voLblTime.AutoSize = true;
         this.voLblTime.Location = new System.Drawing.Point(93, 17);
         this.voLblTime.Name = "voLblTime";
         this.voLblTime.Size = new System.Drawing.Size(0, 13);
         this.voLblTime.TabIndex = 1;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(403, 79);
         this.Controls.Add(this.voLblTime);
         this.Controls.Add(this.voBtnStartClock);
         this.Name = "Form1";
         this.Text = "Form1";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnStartClock;
      private System.Windows.Forms.Label voLblTime;
   }
}


namespace ThreadPooling
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
         this.voBtnStart = new System.Windows.Forms.Button();
         this.voBtnTPArray = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // voBtnStart
         // 
         this.voBtnStart.Location = new System.Drawing.Point(12, 12);
         this.voBtnStart.Name = "voBtnStart";
         this.voBtnStart.Size = new System.Drawing.Size(158, 34);
         this.voBtnStart.TabIndex = 0;
         this.voBtnStart.Text = "Thread Pool Start";
         this.voBtnStart.UseVisualStyleBackColor = true;
         this.voBtnStart.Click += new System.EventHandler(this.voBtnStart_Click);
         // 
         // voBtnTPArray
         // 
         this.voBtnTPArray.Location = new System.Drawing.Point(12, 52);
         this.voBtnTPArray.Name = "voBtnTPArray";
         this.voBtnTPArray.Size = new System.Drawing.Size(158, 34);
         this.voBtnTPArray.TabIndex = 1;
         this.voBtnTPArray.Text = "Thread Pool Array";
         this.voBtnTPArray.UseVisualStyleBackColor = true;
         this.voBtnTPArray.Click += new System.EventHandler(this.voBtnTPArray_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.voBtnTPArray);
         this.Controls.Add(this.voBtnStart);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button voBtnStart;
      private System.Windows.Forms.Button voBtnTPArray;
   }
}


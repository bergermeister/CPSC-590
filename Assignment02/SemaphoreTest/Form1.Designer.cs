namespace SemaphoreTest
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
         this.voBtnNewCust = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // voBtnNewCust
         // 
         this.voBtnNewCust.Location = new System.Drawing.Point(12, 12);
         this.voBtnNewCust.Name = "voBtnNewCust";
         this.voBtnNewCust.Size = new System.Drawing.Size(132, 40);
         this.voBtnNewCust.TabIndex = 0;
         this.voBtnNewCust.Text = "New Customer";
         this.voBtnNewCust.UseVisualStyleBackColor = true;
         this.voBtnNewCust.Click += new System.EventHandler(this.voBtnNewCust_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.voBtnNewCust);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button voBtnNewCust;
   }
}


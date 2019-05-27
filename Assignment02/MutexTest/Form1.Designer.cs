namespace MutexTest
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
         this.voBtnTest = new System.Windows.Forms.Button();
         this.voSb1 = new System.Windows.Forms.StatusStrip();
         this.voLbl = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // voBtnTest
         // 
         this.voBtnTest.Location = new System.Drawing.Point(12, 12);
         this.voBtnTest.Name = "voBtnTest";
         this.voBtnTest.Size = new System.Drawing.Size(160, 31);
         this.voBtnTest.TabIndex = 0;
         this.voBtnTest.Text = "Mutex Test";
         this.voBtnTest.UseVisualStyleBackColor = true;
         this.voBtnTest.Click += new System.EventHandler(this.voBtnTest_Click);
         // 
         // voSb1
         // 
         this.voSb1.ImageScalingSize = new System.Drawing.Size(24, 24);
         this.voSb1.Location = new System.Drawing.Point(0, 422);
         this.voSb1.Name = "voSb1";
         this.voSb1.Size = new System.Drawing.Size(800, 28);
         this.voSb1.TabIndex = 1;
         // 
         // voLbl
         // 
         this.voLbl.AutoSize = true;
         this.voLbl.Location = new System.Drawing.Point(178, 17);
         this.voLbl.Name = "voLbl";
         this.voLbl.Size = new System.Drawing.Size(0, 20);
         this.voLbl.TabIndex = 2;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.voLbl);
         this.Controls.Add(this.voSb1);
         this.Controls.Add(this.voBtnTest);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnTest;
      private System.Windows.Forms.StatusStrip voSb1;
      private System.Windows.Forms.Label voLbl;
   }
}


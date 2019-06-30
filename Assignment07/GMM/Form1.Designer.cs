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
      protected override void Dispose( bool disposing )
      {
         if( disposing && ( components != null ) )
         {
            components.Dispose( );
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this.voBtnTestGMM = new System.Windows.Forms.Button();
         this.voBtnTestClass = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.voTxtNum = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // voBtnTestGMM
         // 
         this.voBtnTestGMM.Location = new System.Drawing.Point(12, 12);
         this.voBtnTestGMM.Name = "voBtnTestGMM";
         this.voBtnTestGMM.Size = new System.Drawing.Size(75, 23);
         this.voBtnTestGMM.TabIndex = 0;
         this.voBtnTestGMM.Text = "Test GMM";
         this.voBtnTestGMM.UseVisualStyleBackColor = true;
         this.voBtnTestGMM.Click += new System.EventHandler(this.voBtnTestGMM_Click);
         // 
         // voBtnTestClass
         // 
         this.voBtnTestClass.Location = new System.Drawing.Point(12, 41);
         this.voBtnTestClass.Name = "voBtnTestClass";
         this.voBtnTestClass.Size = new System.Drawing.Size(75, 23);
         this.voBtnTestClass.TabIndex = 1;
         this.voBtnTestClass.Text = "Test Class";
         this.voBtnTestClass.UseVisualStyleBackColor = true;
         this.voBtnTestClass.Click += new System.EventHandler(this.voBtnTestClass_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(110, 17);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(72, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Enter Number";
         // 
         // voTxtNum
         // 
         this.voTxtNum.Location = new System.Drawing.Point(113, 33);
         this.voTxtNum.Name = "voTxtNum";
         this.voTxtNum.Size = new System.Drawing.Size(100, 20);
         this.voTxtNum.TabIndex = 3;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.voTxtNum);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.voBtnTestClass);
         this.Controls.Add(this.voBtnTestGMM);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnTestGMM;
      private System.Windows.Forms.Button voBtnTestClass;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox voTxtNum;
   }
}


namespace MatrixMultiplication
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
         this.voBtnInit = new System.Windows.Forms.Button();
         this.voBtnMult = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // voBtnInit
         // 
         this.voBtnInit.Location = new System.Drawing.Point(12, 27);
         this.voBtnInit.Name = "voBtnInit";
         this.voBtnInit.Size = new System.Drawing.Size(189, 34);
         this.voBtnInit.TabIndex = 0;
         this.voBtnInit.Text = "Initialize Matrix";
         this.voBtnInit.UseVisualStyleBackColor = true;
         this.voBtnInit.Click += new System.EventHandler(this.voBtnInit_Click);
         // 
         // voBtnMult
         // 
         this.voBtnMult.Location = new System.Drawing.Point(12, 81);
         this.voBtnMult.Name = "voBtnMult";
         this.voBtnMult.Size = new System.Drawing.Size(189, 34);
         this.voBtnMult.TabIndex = 1;
         this.voBtnMult.Text = "Matrix Multiply";
         this.voBtnMult.UseVisualStyleBackColor = true;
         this.voBtnMult.Click += new System.EventHandler(this.voBtnMult_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.voBtnMult);
         this.Controls.Add(this.voBtnInit);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button voBtnInit;
      private System.Windows.Forms.Button voBtnMult;
   }
}


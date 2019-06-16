namespace ParallelLUDecomposition
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
         this.voBtnSequential = new System.Windows.Forms.Button();
         this.voBtnParallel = new System.Windows.Forms.Button();
         this.voTbSize = new System.Windows.Forms.TextBox();
         this.voLblSize = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // voBtnSequential
         // 
         this.voBtnSequential.Location = new System.Drawing.Point(12, 38);
         this.voBtnSequential.Name = "voBtnSequential";
         this.voBtnSequential.Size = new System.Drawing.Size(177, 23);
         this.voBtnSequential.TabIndex = 0;
         this.voBtnSequential.Text = "Sequential LU Decomposition";
         this.voBtnSequential.UseVisualStyleBackColor = true;
         this.voBtnSequential.Click += new System.EventHandler(this.voBtnSequential_Click);
         // 
         // voBtnParallel
         // 
         this.voBtnParallel.Location = new System.Drawing.Point(12, 67);
         this.voBtnParallel.Name = "voBtnParallel";
         this.voBtnParallel.Size = new System.Drawing.Size(177, 23);
         this.voBtnParallel.TabIndex = 1;
         this.voBtnParallel.Text = "Parallel LU Decomposition";
         this.voBtnParallel.UseVisualStyleBackColor = true;
         // 
         // voTbSize
         // 
         this.voTbSize.Location = new System.Drawing.Point(78, 12);
         this.voTbSize.Name = "voTbSize";
         this.voTbSize.Size = new System.Drawing.Size(111, 20);
         this.voTbSize.TabIndex = 2;
         // 
         // voLblSize
         // 
         this.voLblSize.AutoSize = true;
         this.voLblSize.Location = new System.Drawing.Point(12, 15);
         this.voLblSize.Name = "voLblSize";
         this.voLblSize.Size = new System.Drawing.Size(60, 13);
         this.voLblSize.TabIndex = 3;
         this.voLblSize.Text = "Block Size:";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(229, 450);
         this.Controls.Add(this.voLblSize);
         this.Controls.Add(this.voTbSize);
         this.Controls.Add(this.voBtnParallel);
         this.Controls.Add(this.voBtnSequential);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnSequential;
      private System.Windows.Forms.Button voBtnParallel;
      private System.Windows.Forms.TextBox voTbSize;
      private System.Windows.Forms.Label voLblSize;
   }
}


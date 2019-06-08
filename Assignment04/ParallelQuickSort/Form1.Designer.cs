namespace ParallelQuickSort
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
         this.voBtnSortSeqS = new System.Windows.Forms.Button();
         this.voBtnSortSeqL = new System.Windows.Forms.Button();
         this.vobtnSortParL = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // voBtnSortSeqS
         // 
         this.voBtnSortSeqS.Location = new System.Drawing.Point(12, 12);
         this.voBtnSortSeqS.Name = "voBtnSortSeqS";
         this.voBtnSortSeqS.Size = new System.Drawing.Size(125, 23);
         this.voBtnSortSeqS.TabIndex = 0;
         this.voBtnSortSeqS.Text = "Sort Sequential";
         this.voBtnSortSeqS.UseVisualStyleBackColor = true;
         this.voBtnSortSeqS.Click += new System.EventHandler(this.voBtnSortSeqS_Click);
         // 
         // voBtnSortSeqL
         // 
         this.voBtnSortSeqL.Location = new System.Drawing.Point(12, 41);
         this.voBtnSortSeqL.Name = "voBtnSortSeqL";
         this.voBtnSortSeqL.Size = new System.Drawing.Size(125, 23);
         this.voBtnSortSeqL.TabIndex = 1;
         this.voBtnSortSeqL.Text = "Sort Sequential Large";
         this.voBtnSortSeqL.UseVisualStyleBackColor = true;
         this.voBtnSortSeqL.Click += new System.EventHandler(this.voBtnSortSeqL_Click);
         // 
         // vobtnSortParL
         // 
         this.vobtnSortParL.Location = new System.Drawing.Point(12, 70);
         this.vobtnSortParL.Name = "vobtnSortParL";
         this.vobtnSortParL.Size = new System.Drawing.Size(125, 23);
         this.vobtnSortParL.TabIndex = 2;
         this.vobtnSortParL.Text = "Sort Parallel Large";
         this.vobtnSortParL.UseVisualStyleBackColor = true;
         this.vobtnSortParL.Click += new System.EventHandler(this.vobtnSortParL_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(208, 322);
         this.Controls.Add(this.vobtnSortParL);
         this.Controls.Add(this.voBtnSortSeqL);
         this.Controls.Add(this.voBtnSortSeqS);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button voBtnSortSeqS;
      private System.Windows.Forms.Button voBtnSortSeqL;
      private System.Windows.Forms.Button vobtnSortParL;
   }
}


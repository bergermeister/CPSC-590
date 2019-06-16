namespace SecondWCFClient
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
         this.voBtnGetEmp = new System.Windows.Forms.Button();
         this.voBtnMatMult = new System.Windows.Forms.Button();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // voBtnGetEmp
         // 
         this.voBtnGetEmp.Location = new System.Drawing.Point(12, 12);
         this.voBtnGetEmp.Name = "voBtnGetEmp";
         this.voBtnGetEmp.Size = new System.Drawing.Size(151, 51);
         this.voBtnGetEmp.TabIndex = 0;
         this.voBtnGetEmp.Text = "Get Employees";
         this.voBtnGetEmp.UseVisualStyleBackColor = true;
         this.voBtnGetEmp.Click += new System.EventHandler(this.voBtnGetEmp_Click);
         // 
         // voBtnMatMult
         // 
         this.voBtnMatMult.Location = new System.Drawing.Point(12, 69);
         this.voBtnMatMult.Name = "voBtnMatMult";
         this.voBtnMatMult.Size = new System.Drawing.Size(151, 51);
         this.voBtnMatMult.TabIndex = 1;
         this.voBtnMatMult.Text = "Test Matrix Multiply";
         this.voBtnMatMult.UseVisualStyleBackColor = true;
         this.voBtnMatMult.Click += new System.EventHandler(this.voBtnMatMult_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Location = new System.Drawing.Point(169, 12);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.RowTemplate.Height = 28;
         this.dataGridView1.Size = new System.Drawing.Size(619, 228);
         this.dataGridView1.TabIndex = 2;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 252);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.voBtnMatMult);
         this.Controls.Add(this.voBtnGetEmp);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button voBtnGetEmp;
      private System.Windows.Forms.Button voBtnMatMult;
      private System.Windows.Forms.DataGridView dataGridView1;
   }
}


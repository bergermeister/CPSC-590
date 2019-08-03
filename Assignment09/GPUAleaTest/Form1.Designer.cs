namespace GPUAleaTest
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
         this.voBtnGPUForWithLambda = new System.Windows.Forms.Button();
         this.voBtnGPUTestKernel = new System.Windows.Forms.Button();
         this.voBtnInitMatrices = new System.Windows.Forms.Button();
         this.voBtnMatMulGPU = new System.Windows.Forms.Button();
         this.voBtnMatMulSeq = new System.Windows.Forms.Button();
         this.voBtnMatMulGPU2 = new System.Windows.Forms.Button();
         this.voBtnMatMulGPU3 = new System.Windows.Forms.Button();
         this.voBtnMatMulGPU4 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // voBtnGPUForWithLambda
         // 
         this.voBtnGPUForWithLambda.Location = new System.Drawing.Point(35, 13);
         this.voBtnGPUForWithLambda.Name = "voBtnGPUForWithLambda";
         this.voBtnGPUForWithLambda.Size = new System.Drawing.Size(129, 23);
         this.voBtnGPUForWithLambda.TabIndex = 0;
         this.voBtnGPUForWithLambda.Text = "GPU For With Lambda";
         this.voBtnGPUForWithLambda.UseVisualStyleBackColor = true;
         this.voBtnGPUForWithLambda.Click += new System.EventHandler(this.voBtnGPUForWithLambda_Click);
         // 
         // voBtnGPUTestKernel
         // 
         this.voBtnGPUTestKernel.Location = new System.Drawing.Point(35, 42);
         this.voBtnGPUTestKernel.Name = "voBtnGPUTestKernel";
         this.voBtnGPUTestKernel.Size = new System.Drawing.Size(129, 23);
         this.voBtnGPUTestKernel.TabIndex = 1;
         this.voBtnGPUTestKernel.Text = "GPU Test Kernel";
         this.voBtnGPUTestKernel.UseVisualStyleBackColor = true;
         this.voBtnGPUTestKernel.Click += new System.EventHandler(this.voBtnGPUTestKernel_Click);
         // 
         // voBtnInitMatrices
         // 
         this.voBtnInitMatrices.Location = new System.Drawing.Point(35, 71);
         this.voBtnInitMatrices.Name = "voBtnInitMatrices";
         this.voBtnInitMatrices.Size = new System.Drawing.Size(129, 23);
         this.voBtnInitMatrices.TabIndex = 2;
         this.voBtnInitMatrices.Text = "Init Matrices";
         this.voBtnInitMatrices.UseVisualStyleBackColor = true;
         this.voBtnInitMatrices.Click += new System.EventHandler(this.voBtnInitMatrices_Click);
         // 
         // voBtnMatMulGPU
         // 
         this.voBtnMatMulGPU.Location = new System.Drawing.Point(35, 129);
         this.voBtnMatMulGPU.Name = "voBtnMatMulGPU";
         this.voBtnMatMulGPU.Size = new System.Drawing.Size(129, 23);
         this.voBtnMatMulGPU.TabIndex = 3;
         this.voBtnMatMulGPU.Text = "Multiply Matrix GPU 1";
         this.voBtnMatMulGPU.UseVisualStyleBackColor = true;
         this.voBtnMatMulGPU.Click += new System.EventHandler(this.voBtnMatMulGPU_Click);
         // 
         // voBtnMatMulSeq
         // 
         this.voBtnMatMulSeq.Location = new System.Drawing.Point(35, 100);
         this.voBtnMatMulSeq.Name = "voBtnMatMulSeq";
         this.voBtnMatMulSeq.Size = new System.Drawing.Size(129, 23);
         this.voBtnMatMulSeq.TabIndex = 4;
         this.voBtnMatMulSeq.Text = "Multiply Matrix Seq.";
         this.voBtnMatMulSeq.UseVisualStyleBackColor = true;
         this.voBtnMatMulSeq.Click += new System.EventHandler(this.voBtnMatMulSeq_Click);
         // 
         // voBtnMatMulGPU2
         // 
         this.voBtnMatMulGPU2.Location = new System.Drawing.Point(35, 158);
         this.voBtnMatMulGPU2.Name = "voBtnMatMulGPU2";
         this.voBtnMatMulGPU2.Size = new System.Drawing.Size(129, 23);
         this.voBtnMatMulGPU2.TabIndex = 5;
         this.voBtnMatMulGPU2.Text = "Multiply Matrix GPU 2";
         this.voBtnMatMulGPU2.UseVisualStyleBackColor = true;
         this.voBtnMatMulGPU2.Click += new System.EventHandler(this.voBtnMatMulGPU2_Click);
         // 
         // voBtnMatMulGPU3
         // 
         this.voBtnMatMulGPU3.Location = new System.Drawing.Point(35, 187);
         this.voBtnMatMulGPU3.Name = "voBtnMatMulGPU3";
         this.voBtnMatMulGPU3.Size = new System.Drawing.Size(129, 23);
         this.voBtnMatMulGPU3.TabIndex = 6;
         this.voBtnMatMulGPU3.Text = "Multiply Matrix GPU 3";
         this.voBtnMatMulGPU3.UseVisualStyleBackColor = true;
         this.voBtnMatMulGPU3.Click += new System.EventHandler(this.voBtnMatMulGPU3_Click);
         // 
         // voBtnMatMulGPU4
         // 
         this.voBtnMatMulGPU4.Location = new System.Drawing.Point(35, 216);
         this.voBtnMatMulGPU4.Name = "voBtnMatMulGPU4";
         this.voBtnMatMulGPU4.Size = new System.Drawing.Size(129, 23);
         this.voBtnMatMulGPU4.TabIndex = 7;
         this.voBtnMatMulGPU4.Text = "Multiply Matrix GPU 4";
         this.voBtnMatMulGPU4.UseVisualStyleBackColor = true;
         this.voBtnMatMulGPU4.Click += new System.EventHandler(this.voBtnMatMulGPU4_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.voBtnMatMulGPU4);
         this.Controls.Add(this.voBtnMatMulGPU3);
         this.Controls.Add(this.voBtnMatMulGPU2);
         this.Controls.Add(this.voBtnMatMulSeq);
         this.Controls.Add(this.voBtnMatMulGPU);
         this.Controls.Add(this.voBtnInitMatrices);
         this.Controls.Add(this.voBtnGPUTestKernel);
         this.Controls.Add(this.voBtnGPUForWithLambda);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button voBtnGPUForWithLambda;
      private System.Windows.Forms.Button voBtnGPUTestKernel;
      private System.Windows.Forms.Button voBtnInitMatrices;
      private System.Windows.Forms.Button voBtnMatMulGPU;
      private System.Windows.Forms.Button voBtnMatMulSeq;
      private System.Windows.Forms.Button voBtnMatMulGPU2;
      private System.Windows.Forms.Button voBtnMatMulGPU3;
      private System.Windows.Forms.Button voBtnMatMulGPU4;
   }
}


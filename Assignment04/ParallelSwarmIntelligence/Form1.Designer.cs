namespace ParallelSwarmIntelligence
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
         this.voBtnParallelRosenbrock = new System.Windows.Forms.Button();
         this.voBtnSequentialRosenBrock = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.voLblBest = new System.Windows.Forms.Label();
         this.voDataGridView = new System.Windows.Forms.DataGridView();
         this.voBtnParallelHimmelblau = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.voDataGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // voBtnParallelRosenbrock
         // 
         this.voBtnParallelRosenbrock.Location = new System.Drawing.Point(12, 12);
         this.voBtnParallelRosenbrock.Name = "voBtnParallelRosenbrock";
         this.voBtnParallelRosenbrock.Size = new System.Drawing.Size(142, 23);
         this.voBtnParallelRosenbrock.TabIndex = 0;
         this.voBtnParallelRosenbrock.Text = "Rosenbrock Parallel";
         this.voBtnParallelRosenbrock.UseVisualStyleBackColor = true;
         this.voBtnParallelRosenbrock.Click += new System.EventHandler(this.voBtnParallelRosenbrock_Click);
         // 
         // voBtnSequentialRosenBrock
         // 
         this.voBtnSequentialRosenBrock.Location = new System.Drawing.Point(12, 41);
         this.voBtnSequentialRosenBrock.Name = "voBtnSequentialRosenBrock";
         this.voBtnSequentialRosenBrock.Size = new System.Drawing.Size(142, 23);
         this.voBtnSequentialRosenBrock.TabIndex = 1;
         this.voBtnSequentialRosenBrock.Text = "Rosenbrock Sequential";
         this.voBtnSequentialRosenBrock.UseVisualStyleBackColor = true;
         this.voBtnSequentialRosenBrock.Click += new System.EventHandler(this.voBtnSequentialRosenbrock_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 211);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Best Result:";
         // 
         // voLblBest
         // 
         this.voLblBest.AutoSize = true;
         this.voLblBest.Location = new System.Drawing.Point(82, 211);
         this.voLblBest.Name = "voLblBest";
         this.voLblBest.Size = new System.Drawing.Size(0, 13);
         this.voLblBest.TabIndex = 3;
         // 
         // voDataGridView
         // 
         this.voDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.voDataGridView.Location = new System.Drawing.Point(160, 12);
         this.voDataGridView.Name = "voDataGridView";
         this.voDataGridView.Size = new System.Drawing.Size(603, 175);
         this.voDataGridView.TabIndex = 4;
         // 
         // voBtnParallelHimmelblau
         // 
         this.voBtnParallelHimmelblau.Location = new System.Drawing.Point(12, 70);
         this.voBtnParallelHimmelblau.Name = "voBtnParallelHimmelblau";
         this.voBtnParallelHimmelblau.Size = new System.Drawing.Size(142, 23);
         this.voBtnParallelHimmelblau.TabIndex = 5;
         this.voBtnParallelHimmelblau.Text = "Himmelblau Parallel";
         this.voBtnParallelHimmelblau.UseVisualStyleBackColor = true;
         this.voBtnParallelHimmelblau.Click += new System.EventHandler(this.voBtnParallelHimmelblau_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(775, 261);
         this.Controls.Add(this.voBtnParallelHimmelblau);
         this.Controls.Add(this.voDataGridView);
         this.Controls.Add(this.voLblBest);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.voBtnSequentialRosenBrock);
         this.Controls.Add(this.voBtnParallelRosenbrock);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.voDataGridView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnParallelRosenbrock;
      private System.Windows.Forms.Button voBtnSequentialRosenBrock;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label voLblBest;
      private System.Windows.Forms.DataGridView voDataGridView;
      private System.Windows.Forms.Button voBtnParallelHimmelblau;
   }
}


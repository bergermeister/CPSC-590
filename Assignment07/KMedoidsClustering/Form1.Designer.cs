namespace KMedoidsClustering
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
         this.voBtnLoad = new System.Windows.Forms.Button();
         this.voBtnInit = new System.Windows.Forms.Button();
         this.voBtnKMedoid = new System.Windows.Forms.Button();
         this.voBtnRedraw = new System.Windows.Forms.Button();
         this.voPB = new System.Windows.Forms.PictureBox();
         this.label1 = new System.Windows.Forms.Label();
         this.voTbK = new System.Windows.Forms.TextBox();
         this.voTbResult = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.voPB)).BeginInit();
         this.SuspendLayout();
         // 
         // voBtnLoad
         // 
         this.voBtnLoad.Location = new System.Drawing.Point(12, 12);
         this.voBtnLoad.Name = "voBtnLoad";
         this.voBtnLoad.Size = new System.Drawing.Size(101, 23);
         this.voBtnLoad.TabIndex = 0;
         this.voBtnLoad.Text = "Load Data Points";
         this.voBtnLoad.UseVisualStyleBackColor = true;
         this.voBtnLoad.Click += new System.EventHandler(this.voBtnLoad_Click);
         // 
         // voBtnInit
         // 
         this.voBtnInit.Location = new System.Drawing.Point(12, 41);
         this.voBtnInit.Name = "voBtnInit";
         this.voBtnInit.Size = new System.Drawing.Size(101, 23);
         this.voBtnInit.TabIndex = 1;
         this.voBtnInit.Text = "Initialize Data";
         this.voBtnInit.UseVisualStyleBackColor = true;
         this.voBtnInit.Click += new System.EventHandler(this.voBtnInit_Click);
         // 
         // voBtnKMedoid
         // 
         this.voBtnKMedoid.Location = new System.Drawing.Point(12, 96);
         this.voBtnKMedoid.Name = "voBtnKMedoid";
         this.voBtnKMedoid.Size = new System.Drawing.Size(101, 23);
         this.voBtnKMedoid.TabIndex = 2;
         this.voBtnKMedoid.Text = "KMedoid";
         this.voBtnKMedoid.UseVisualStyleBackColor = true;
         this.voBtnKMedoid.Click += new System.EventHandler(this.voBtnKMedoid_Click);
         // 
         // voBtnRedraw
         // 
         this.voBtnRedraw.Location = new System.Drawing.Point(351, 517);
         this.voBtnRedraw.Name = "voBtnRedraw";
         this.voBtnRedraw.Size = new System.Drawing.Size(112, 23);
         this.voBtnRedraw.TabIndex = 3;
         this.voBtnRedraw.Text = "Redraw Clusters";
         this.voBtnRedraw.UseVisualStyleBackColor = true;
         this.voBtnRedraw.Click += new System.EventHandler(this.voBtnRedraw_Click);
         // 
         // voPB
         // 
         this.voPB.Location = new System.Drawing.Point(139, 12);
         this.voPB.Name = "voPB";
         this.voPB.Size = new System.Drawing.Size(530, 499);
         this.voPB.TabIndex = 4;
         this.voPB.TabStop = false;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 73);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(14, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "K";
         // 
         // voTbK
         // 
         this.voTbK.Location = new System.Drawing.Point(32, 70);
         this.voTbK.Name = "voTbK";
         this.voTbK.Size = new System.Drawing.Size(81, 20);
         this.voTbK.TabIndex = 6;
         this.voTbK.Text = "3";
         // 
         // voTbResult
         // 
         this.voTbResult.Location = new System.Drawing.Point(12, 126);
         this.voTbResult.Multiline = true;
         this.voTbResult.Name = "voTbResult";
         this.voTbResult.Size = new System.Drawing.Size(121, 385);
         this.voTbResult.TabIndex = 7;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(681, 552);
         this.Controls.Add(this.voTbResult);
         this.Controls.Add(this.voTbK);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.voPB);
         this.Controls.Add(this.voBtnRedraw);
         this.Controls.Add(this.voBtnKMedoid);
         this.Controls.Add(this.voBtnInit);
         this.Controls.Add(this.voBtnLoad);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.voPB)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnLoad;
      private System.Windows.Forms.Button voBtnInit;
      private System.Windows.Forms.Button voBtnKMedoid;
      private System.Windows.Forms.Button voBtnRedraw;
      private System.Windows.Forms.PictureBox voPB;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox voTbK;
      private System.Windows.Forms.TextBox voTbResult;
   }
}


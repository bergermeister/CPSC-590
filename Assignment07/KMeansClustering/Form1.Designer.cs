namespace KMeansClustering
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
         this.voBtnKMeans = new System.Windows.Forms.Button();
         this.voBtnKMeansPP = new System.Windows.Forms.Button();
         this.voBtnKMeanPPV = new System.Windows.Forms.Button();
         this.voLblCount = new System.Windows.Forms.Label();
         this.voTbCount = new System.Windows.Forms.TextBox();
         this.voTbResult = new System.Windows.Forms.TextBox();
         this.voPB = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.voPB)).BeginInit();
         this.SuspendLayout();
         // 
         // voBtnLoad
         // 
         this.voBtnLoad.Location = new System.Drawing.Point(12, 12);
         this.voBtnLoad.Name = "voBtnLoad";
         this.voBtnLoad.Size = new System.Drawing.Size(174, 23);
         this.voBtnLoad.TabIndex = 0;
         this.voBtnLoad.Text = "Load Data File";
         this.voBtnLoad.UseVisualStyleBackColor = true;
         this.voBtnLoad.Click += new System.EventHandler(this.voBtnLoad_Click);
         // 
         // voBtnInit
         // 
         this.voBtnInit.Location = new System.Drawing.Point(12, 41);
         this.voBtnInit.Name = "voBtnInit";
         this.voBtnInit.Size = new System.Drawing.Size(174, 23);
         this.voBtnInit.TabIndex = 1;
         this.voBtnInit.Text = "Initialize Data";
         this.voBtnInit.UseVisualStyleBackColor = true;
         this.voBtnInit.Click += new System.EventHandler(this.voBtnInit_Click);
         // 
         // voBtnKMeans
         // 
         this.voBtnKMeans.Location = new System.Drawing.Point(12, 96);
         this.voBtnKMeans.Name = "voBtnKMeans";
         this.voBtnKMeans.Size = new System.Drawing.Size(174, 23);
         this.voBtnKMeans.TabIndex = 2;
         this.voBtnKMeans.Text = "Do KMeans";
         this.voBtnKMeans.UseVisualStyleBackColor = true;
         this.voBtnKMeans.Click += new System.EventHandler(this.voBtnKMeans_Click);
         // 
         // voBtnKMeansPP
         // 
         this.voBtnKMeansPP.Location = new System.Drawing.Point(12, 125);
         this.voBtnKMeansPP.Name = "voBtnKMeansPP";
         this.voBtnKMeansPP.Size = new System.Drawing.Size(174, 23);
         this.voBtnKMeansPP.TabIndex = 3;
         this.voBtnKMeansPP.Text = "Do KMeans++ Clustering";
         this.voBtnKMeansPP.UseVisualStyleBackColor = true;
         this.voBtnKMeansPP.Click += new System.EventHandler(this.voBtnKMeansPP_Click);
         // 
         // voBtnKMeanPPV
         // 
         this.voBtnKMeanPPV.Location = new System.Drawing.Point(12, 154);
         this.voBtnKMeanPPV.Name = "voBtnKMeanPPV";
         this.voBtnKMeanPPV.Size = new System.Drawing.Size(174, 23);
         this.voBtnKMeanPPV.TabIndex = 4;
         this.voBtnKMeanPPV.Text = "Do KMeans++ With Min Variance";
         this.voBtnKMeanPPV.UseVisualStyleBackColor = true;
         this.voBtnKMeanPPV.Click += new System.EventHandler(this.voBtnKMeanPPV_Click);
         // 
         // voLblCount
         // 
         this.voLblCount.AutoSize = true;
         this.voLblCount.Location = new System.Drawing.Point(12, 73);
         this.voLblCount.Name = "voLblCount";
         this.voLblCount.Size = new System.Drawing.Size(81, 13);
         this.voLblCount.TabIndex = 5;
         this.voLblCount.Text = "Num of Clusters";
         // 
         // voTbCount
         // 
         this.voTbCount.Location = new System.Drawing.Point(94, 70);
         this.voTbCount.Name = "voTbCount";
         this.voTbCount.Size = new System.Drawing.Size(30, 20);
         this.voTbCount.TabIndex = 6;
         this.voTbCount.Text = "3";
         // 
         // voTbResult
         // 
         this.voTbResult.Location = new System.Drawing.Point(12, 183);
         this.voTbResult.Multiline = true;
         this.voTbResult.Name = "voTbResult";
         this.voTbResult.Size = new System.Drawing.Size(174, 430);
         this.voTbResult.TabIndex = 7;
         // 
         // voPB
         // 
         this.voPB.Location = new System.Drawing.Point(192, 12);
         this.voPB.Name = "voPB";
         this.voPB.Size = new System.Drawing.Size(690, 601);
         this.voPB.TabIndex = 8;
         this.voPB.TabStop = false;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(894, 625);
         this.Controls.Add(this.voPB);
         this.Controls.Add(this.voTbResult);
         this.Controls.Add(this.voTbCount);
         this.Controls.Add(this.voLblCount);
         this.Controls.Add(this.voBtnKMeanPPV);
         this.Controls.Add(this.voBtnKMeansPP);
         this.Controls.Add(this.voBtnKMeans);
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
      private System.Windows.Forms.Button voBtnKMeans;
      private System.Windows.Forms.Button voBtnKMeansPP;
      private System.Windows.Forms.Button voBtnKMeanPPV;
      private System.Windows.Forms.Label voLblCount;
      private System.Windows.Forms.TextBox voTbCount;
      private System.Windows.Forms.TextBox voTbResult;
      private System.Windows.Forms.PictureBox voPB;
   }
}


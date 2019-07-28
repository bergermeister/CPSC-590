namespace GAWebClient
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.voBtnStartCap = new System.Windows.Forms.Button();
         this.voBtnEndCap = new System.Windows.Forms.Button();
         this.voBtnRunGADist = new System.Windows.Forms.Button();
         this.voMap = new System.Windows.Forms.PictureBox();
         this.voLblBestResult3 = new System.Windows.Forms.Label();
         this.voLblBestResult2 = new System.Windows.Forms.Label();
         this.voLblBestResult1 = new System.Windows.Forms.Label();
         this.voLblBestResult0 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.voMap)).BeginInit();
         this.SuspendLayout();
         // 
         // voBtnStartCap
         // 
         this.voBtnStartCap.BackColor = System.Drawing.Color.White;
         this.voBtnStartCap.ForeColor = System.Drawing.Color.Black;
         this.voBtnStartCap.Location = new System.Drawing.Point(11, 11);
         this.voBtnStartCap.Margin = new System.Windows.Forms.Padding(2);
         this.voBtnStartCap.Name = "voBtnStartCap";
         this.voBtnStartCap.Size = new System.Drawing.Size(112, 24);
         this.voBtnStartCap.TabIndex = 4;
         this.voBtnStartCap.Text = "Start Route Capture";
         this.voBtnStartCap.UseVisualStyleBackColor = false;
         this.voBtnStartCap.Click += new System.EventHandler(this.voBtnStartCap_Click);
         // 
         // voBtnEndCap
         // 
         this.voBtnEndCap.BackColor = System.Drawing.Color.Blue;
         this.voBtnEndCap.ForeColor = System.Drawing.Color.White;
         this.voBtnEndCap.Location = new System.Drawing.Point(127, 11);
         this.voBtnEndCap.Margin = new System.Windows.Forms.Padding(2);
         this.voBtnEndCap.Name = "voBtnEndCap";
         this.voBtnEndCap.Size = new System.Drawing.Size(110, 24);
         this.voBtnEndCap.TabIndex = 5;
         this.voBtnEndCap.Text = "End Route Capture";
         this.voBtnEndCap.UseVisualStyleBackColor = false;
         this.voBtnEndCap.Click += new System.EventHandler(this.voBtnEndCap_Click);
         // 
         // voBtnRunGADist
         // 
         this.voBtnRunGADist.BackColor = System.Drawing.Color.White;
         this.voBtnRunGADist.Location = new System.Drawing.Point(241, 11);
         this.voBtnRunGADist.Margin = new System.Windows.Forms.Padding(2);
         this.voBtnRunGADist.Name = "voBtnRunGADist";
         this.voBtnRunGADist.Size = new System.Drawing.Size(115, 24);
         this.voBtnRunGADist.TabIndex = 6;
         this.voBtnRunGADist.Text = "Run GA (Distributed)";
         this.voBtnRunGADist.UseVisualStyleBackColor = false;
         this.voBtnRunGADist.Click += new System.EventHandler(this.voBtnRunGADist_Click);
         // 
         // voMap
         // 
         this.voMap.InitialImage = ((System.Drawing.Image)(resources.GetObject("voMap.InitialImage")));
         this.voMap.Location = new System.Drawing.Point(11, 39);
         this.voMap.Margin = new System.Windows.Forms.Padding(2);
         this.voMap.Name = "voMap";
         this.voMap.Size = new System.Drawing.Size(603, 396);
         this.voMap.TabIndex = 7;
         this.voMap.TabStop = false;
         this.voMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.voMap_MouseDown);
         // 
         // voLblBestResult3
         // 
         this.voLblBestResult3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.voLblBestResult3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.voLblBestResult3.Location = new System.Drawing.Point(626, 242);
         this.voLblBestResult3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.voLblBestResult3.Name = "voLblBestResult3";
         this.voLblBestResult3.Size = new System.Drawing.Size(226, 72);
         this.voLblBestResult3.TabIndex = 15;
         // 
         // voLblBestResult2
         // 
         this.voLblBestResult2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.voLblBestResult2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.voLblBestResult2.Location = new System.Drawing.Point(626, 173);
         this.voLblBestResult2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.voLblBestResult2.Name = "voLblBestResult2";
         this.voLblBestResult2.Size = new System.Drawing.Size(226, 69);
         this.voLblBestResult2.TabIndex = 14;
         // 
         // voLblBestResult1
         // 
         this.voLblBestResult1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.voLblBestResult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.voLblBestResult1.Location = new System.Drawing.Point(626, 106);
         this.voLblBestResult1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.voLblBestResult1.Name = "voLblBestResult1";
         this.voLblBestResult1.Size = new System.Drawing.Size(226, 67);
         this.voLblBestResult1.TabIndex = 13;
         // 
         // voLblBestResult0
         // 
         this.voLblBestResult0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.voLblBestResult0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.voLblBestResult0.Location = new System.Drawing.Point(626, 39);
         this.voLblBestResult0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.voLblBestResult0.Name = "voLblBestResult0";
         this.voLblBestResult0.Size = new System.Drawing.Size(226, 67);
         this.voLblBestResult0.TabIndex = 12;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(863, 450);
         this.Controls.Add(this.voLblBestResult3);
         this.Controls.Add(this.voLblBestResult2);
         this.Controls.Add(this.voLblBestResult1);
         this.Controls.Add(this.voLblBestResult0);
         this.Controls.Add(this.voMap);
         this.Controls.Add(this.voBtnRunGADist);
         this.Controls.Add(this.voBtnEndCap);
         this.Controls.Add(this.voBtnStartCap);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.voMap)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.Button voBtnStartCap;
      private System.Windows.Forms.Button voBtnEndCap;
      private System.Windows.Forms.Button voBtnRunGADist;
      private System.Windows.Forms.PictureBox voMap;
      private System.Windows.Forms.Label voLblBestResult3;
      private System.Windows.Forms.Label voLblBestResult2;
      private System.Windows.Forms.Label voLblBestResult1;
      private System.Windows.Forms.Label voLblBestResult0;
   }
}


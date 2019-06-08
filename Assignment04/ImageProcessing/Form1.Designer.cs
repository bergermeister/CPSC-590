namespace ImageProcessing
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
         this.voBtnLoadImage = new System.Windows.Forms.Button();
         this.voBtnConvertSafe = new System.Windows.Forms.Button();
         this.voBtnConvertUnsafe = new System.Windows.Forms.Button();
         this.voBtnConvertParallel = new System.Windows.Forms.Button();
         this.voPictureBox = new System.Windows.Forms.PictureBox();
         this.voLblWidth = new System.Windows.Forms.Label();
         this.voLblHeight = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.voPictureBox)).BeginInit();
         this.SuspendLayout();
         // 
         // voBtnLoadImage
         // 
         this.voBtnLoadImage.Location = new System.Drawing.Point(12, 70);
         this.voBtnLoadImage.Name = "voBtnLoadImage";
         this.voBtnLoadImage.Size = new System.Drawing.Size(140, 31);
         this.voBtnLoadImage.TabIndex = 0;
         this.voBtnLoadImage.Text = "Load Image";
         this.voBtnLoadImage.UseVisualStyleBackColor = true;
         this.voBtnLoadImage.Click += new System.EventHandler(this.voBtnLoadImage_Click);
         // 
         // voBtnConvertSafe
         // 
         this.voBtnConvertSafe.Location = new System.Drawing.Point(12, 150);
         this.voBtnConvertSafe.Name = "voBtnConvertSafe";
         this.voBtnConvertSafe.Size = new System.Drawing.Size(140, 31);
         this.voBtnConvertSafe.TabIndex = 1;
         this.voBtnConvertSafe.Text = "Convert To Gray";
         this.voBtnConvertSafe.UseVisualStyleBackColor = true;
         this.voBtnConvertSafe.Click += new System.EventHandler(this.voBtnConvertSafe_Click);
         // 
         // voBtnConvertUnsafe
         // 
         this.voBtnConvertUnsafe.Location = new System.Drawing.Point(12, 261);
         this.voBtnConvertUnsafe.Name = "voBtnConvertUnsafe";
         this.voBtnConvertUnsafe.Size = new System.Drawing.Size(140, 74);
         this.voBtnConvertUnsafe.TabIndex = 2;
         this.voBtnConvertUnsafe.Text = "Convert To Gray Unsafe";
         this.voBtnConvertUnsafe.UseVisualStyleBackColor = true;
         this.voBtnConvertUnsafe.Click += new System.EventHandler(this.voBtnConvertUnsafe_Click);
         // 
         // voBtnConvertParallel
         // 
         this.voBtnConvertParallel.Location = new System.Drawing.Point(12, 383);
         this.voBtnConvertParallel.Name = "voBtnConvertParallel";
         this.voBtnConvertParallel.Size = new System.Drawing.Size(140, 79);
         this.voBtnConvertParallel.TabIndex = 3;
         this.voBtnConvertParallel.Text = "Convert To Gray Parallel Unsafe";
         this.voBtnConvertParallel.UseVisualStyleBackColor = true;
         this.voBtnConvertParallel.Click += new System.EventHandler(this.voBtnConvertParallel_Click);
         // 
         // voPictureBox
         // 
         this.voPictureBox.Location = new System.Drawing.Point(158, 41);
         this.voPictureBox.Name = "voPictureBox";
         this.voPictureBox.Size = new System.Drawing.Size(898, 686);
         this.voPictureBox.TabIndex = 4;
         this.voPictureBox.TabStop = false;
         // 
         // voLblWidth
         // 
         this.voLblWidth.AutoSize = true;
         this.voLblWidth.Location = new System.Drawing.Point(316, 13);
         this.voLblWidth.Name = "voLblWidth";
         this.voLblWidth.Size = new System.Drawing.Size(50, 20);
         this.voLblWidth.TabIndex = 5;
         this.voLblWidth.Text = "Width";
         // 
         // voLblHeight
         // 
         this.voLblHeight.AutoSize = true;
         this.voLblHeight.Location = new System.Drawing.Point(555, 13);
         this.voLblHeight.Name = "voLblHeight";
         this.voLblHeight.Size = new System.Drawing.Size(56, 20);
         this.voLblHeight.TabIndex = 6;
         this.voLblHeight.Text = "Height";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1068, 739);
         this.Controls.Add(this.voLblHeight);
         this.Controls.Add(this.voLblWidth);
         this.Controls.Add(this.voPictureBox);
         this.Controls.Add(this.voBtnConvertParallel);
         this.Controls.Add(this.voBtnConvertUnsafe);
         this.Controls.Add(this.voBtnConvertSafe);
         this.Controls.Add(this.voBtnLoadImage);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.voPictureBox)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button voBtnLoadImage;
      private System.Windows.Forms.Button voBtnConvertSafe;
      private System.Windows.Forms.Button voBtnConvertUnsafe;
      private System.Windows.Forms.Button voBtnConvertParallel;
      private System.Windows.Forms.PictureBox voPictureBox;
      private System.Windows.Forms.Label voLblWidth;
      private System.Windows.Forms.Label voLblHeight;
   }
}


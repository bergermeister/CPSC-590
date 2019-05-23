namespace Threading2
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
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.voBtnCompute = new System.Windows.Forms.Button();
         this.voBtnGetTemp = new System.Windows.Forms.Button();
         this.voBtnGetStockPrice = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // voBtnCompute
         // 
         this.voBtnCompute.Location = new System.Drawing.Point(31, 49);
         this.voBtnCompute.Name = "voBtnCompute";
         this.voBtnCompute.Size = new System.Drawing.Size(109, 23);
         this.voBtnCompute.TabIndex = 0;
         this.voBtnCompute.Text = "Compute";
         this.voBtnCompute.UseVisualStyleBackColor = true;
         this.voBtnCompute.Click += new System.EventHandler(this.voBtnCompute_Click);
         // 
         // voBtnGetTemp
         // 
         this.voBtnGetTemp.Location = new System.Drawing.Point(31, 78);
         this.voBtnGetTemp.Name = "voBtnGetTemp";
         this.voBtnGetTemp.Size = new System.Drawing.Size(109, 23);
         this.voBtnGetTemp.TabIndex = 1;
         this.voBtnGetTemp.Text = "Get Temperature";
         this.voBtnGetTemp.UseVisualStyleBackColor = true;
         this.voBtnGetTemp.Click += new System.EventHandler(this.voBtnGetTemp_Click);
         // 
         // voBtnGetStockPrice
         // 
         this.voBtnGetStockPrice.Location = new System.Drawing.Point(31, 107);
         this.voBtnGetStockPrice.Name = "voBtnGetStockPrice";
         this.voBtnGetStockPrice.Size = new System.Drawing.Size(109, 23);
         this.voBtnGetStockPrice.TabIndex = 2;
         this.voBtnGetStockPrice.Text = "Gert Stock Price";
         this.voBtnGetStockPrice.UseVisualStyleBackColor = true;
         this.voBtnGetStockPrice.Click += new System.EventHandler(this.voBtnGetStockPrice_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(174, 196);
         this.Controls.Add(this.voBtnGetStockPrice);
         this.Controls.Add(this.voBtnGetTemp);
         this.Controls.Add(this.voBtnCompute);
         this.Name = "Form1";
         this.Text = "Form1";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button voBtnCompute;
      private System.Windows.Forms.Button voBtnGetTemp;
      private System.Windows.Forms.Button voBtnGetStockPrice;
   }
}


namespace FirstWCFClient
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
         this.voBtnTestMyMath = new System.Windows.Forms.Button();
         this.voBtnTestProxy = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // voBtnTestMyMath
         // 
         this.voBtnTestMyMath.Location = new System.Drawing.Point(32, 37);
         this.voBtnTestMyMath.Name = "voBtnTestMyMath";
         this.voBtnTestMyMath.Size = new System.Drawing.Size(152, 28);
         this.voBtnTestMyMath.TabIndex = 0;
         this.voBtnTestMyMath.Text = "Test WCF MyMath";
         this.voBtnTestMyMath.UseVisualStyleBackColor = true;
         this.voBtnTestMyMath.Click += new System.EventHandler(this.voBtnTestMyMath_Click);
         // 
         // voBtnTestProxy
         // 
         this.voBtnTestProxy.Location = new System.Drawing.Point(32, 84);
         this.voBtnTestProxy.Name = "voBtnTestProxy";
         this.voBtnTestProxy.Size = new System.Drawing.Size(152, 28);
         this.voBtnTestProxy.TabIndex = 1;
         this.voBtnTestProxy.Text = "Test WCF Via Proxy";
         this.voBtnTestProxy.UseVisualStyleBackColor = true;
         this.voBtnTestProxy.Click += new System.EventHandler(this.voBtnTestProxy_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.voBtnTestProxy);
         this.Controls.Add(this.voBtnTestMyMath);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button voBtnTestMyMath;
      private System.Windows.Forms.Button voBtnTestProxy;
   }
}


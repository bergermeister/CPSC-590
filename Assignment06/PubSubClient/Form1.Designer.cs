namespace PubSubClient
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
         this.btnTestCallback = new System.Windows.Forms.Button();
         this.txtA = new System.Windows.Forms.TextBox();
         this.txtB = new System.Windows.Forms.TextBox();
         this.txtClientID = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // btnTestCallback
         // 
         this.btnTestCallback.Location = new System.Drawing.Point(105, 29);
         this.btnTestCallback.Name = "btnTestCallback";
         this.btnTestCallback.Size = new System.Drawing.Size(150, 35);
         this.btnTestCallback.TabIndex = 0;
         this.btnTestCallback.Text = "Test Callback";
         this.btnTestCallback.UseVisualStyleBackColor = true;
         this.btnTestCallback.Click += new System.EventHandler(this.btnTestCallback_Click);
         // 
         // txtA
         // 
         this.txtA.Location = new System.Drawing.Point(38, 83);
         this.txtA.Name = "txtA";
         this.txtA.Size = new System.Drawing.Size(100, 26);
         this.txtA.TabIndex = 1;
         // 
         // txtB
         // 
         this.txtB.Location = new System.Drawing.Point(215, 83);
         this.txtB.Name = "txtB";
         this.txtB.Size = new System.Drawing.Size(100, 26);
         this.txtB.TabIndex = 2;
         // 
         // txtClientID
         // 
         this.txtClientID.Location = new System.Drawing.Point(133, 139);
         this.txtClientID.Name = "txtClientID";
         this.txtClientID.Size = new System.Drawing.Size(100, 26);
         this.txtClientID.TabIndex = 3;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 86);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(20, 20);
         this.label1.TabIndex = 4;
         this.label1.Text = "A";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(189, 86);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(20, 20);
         this.label2.TabIndex = 5;
         this.label2.Text = "B";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(61, 142);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(66, 20);
         this.label3.TabIndex = 6;
         this.label3.Text = "ClientID";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.txtClientID);
         this.Controls.Add(this.txtB);
         this.Controls.Add(this.txtA);
         this.Controls.Add(this.btnTestCallback);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnTestCallback;
      private System.Windows.Forms.TextBox txtA;
      private System.Windows.Forms.TextBox txtB;
      private System.Windows.Forms.TextBox txtClientID;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
   }
}


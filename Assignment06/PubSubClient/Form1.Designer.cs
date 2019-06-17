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
         this.voBtnSubscribe = new System.Windows.Forms.Button();
         this.voBtnUnsubscribe = new System.Windows.Forms.Button();
         this.voBtnChngPrice = new System.Windows.Forms.Button();
         this.voTxtPrice = new System.Windows.Forms.TextBox();
         this.voTxtSymbol = new System.Windows.Forms.TextBox();
         this.voTxtTrigger = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.voTxtChngSym = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // btnTestCallback
         // 
         this.btnTestCallback.Location = new System.Drawing.Point(70, 19);
         this.btnTestCallback.Margin = new System.Windows.Forms.Padding(2);
         this.btnTestCallback.Name = "btnTestCallback";
         this.btnTestCallback.Size = new System.Drawing.Size(100, 23);
         this.btnTestCallback.TabIndex = 0;
         this.btnTestCallback.Text = "Test Callback";
         this.btnTestCallback.UseVisualStyleBackColor = true;
         this.btnTestCallback.Click += new System.EventHandler(this.btnTestCallback_Click);
         // 
         // txtA
         // 
         this.txtA.Location = new System.Drawing.Point(25, 54);
         this.txtA.Margin = new System.Windows.Forms.Padding(2);
         this.txtA.Name = "txtA";
         this.txtA.Size = new System.Drawing.Size(68, 20);
         this.txtA.TabIndex = 1;
         // 
         // txtB
         // 
         this.txtB.Location = new System.Drawing.Point(143, 54);
         this.txtB.Margin = new System.Windows.Forms.Padding(2);
         this.txtB.Name = "txtB";
         this.txtB.Size = new System.Drawing.Size(68, 20);
         this.txtB.TabIndex = 2;
         // 
         // txtClientID
         // 
         this.txtClientID.Location = new System.Drawing.Point(89, 90);
         this.txtClientID.Margin = new System.Windows.Forms.Padding(2);
         this.txtClientID.Name = "txtClientID";
         this.txtClientID.Size = new System.Drawing.Size(68, 20);
         this.txtClientID.TabIndex = 3;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(8, 56);
         this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(14, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "A";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(126, 56);
         this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(14, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "B";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(41, 92);
         this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(44, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "ClientID";
         // 
         // voBtnSubscribe
         // 
         this.voBtnSubscribe.Location = new System.Drawing.Point(11, 192);
         this.voBtnSubscribe.Margin = new System.Windows.Forms.Padding(2);
         this.voBtnSubscribe.Name = "voBtnSubscribe";
         this.voBtnSubscribe.Size = new System.Drawing.Size(100, 23);
         this.voBtnSubscribe.TabIndex = 7;
         this.voBtnSubscribe.Text = "Subscribe";
         this.voBtnSubscribe.UseVisualStyleBackColor = true;
         this.voBtnSubscribe.Click += new System.EventHandler(this.voBtnSubscribe_Click);
         // 
         // voBtnUnsubscribe
         // 
         this.voBtnUnsubscribe.Location = new System.Drawing.Point(11, 246);
         this.voBtnUnsubscribe.Margin = new System.Windows.Forms.Padding(2);
         this.voBtnUnsubscribe.Name = "voBtnUnsubscribe";
         this.voBtnUnsubscribe.Size = new System.Drawing.Size(100, 23);
         this.voBtnUnsubscribe.TabIndex = 8;
         this.voBtnUnsubscribe.Text = "Unsubscribe";
         this.voBtnUnsubscribe.UseVisualStyleBackColor = true;
         this.voBtnUnsubscribe.Click += new System.EventHandler(this.voBtnUnsubscribe_Click);
         // 
         // voBtnChngPrice
         // 
         this.voBtnChngPrice.Location = new System.Drawing.Point(11, 219);
         this.voBtnChngPrice.Margin = new System.Windows.Forms.Padding(2);
         this.voBtnChngPrice.Name = "voBtnChngPrice";
         this.voBtnChngPrice.Size = new System.Drawing.Size(100, 23);
         this.voBtnChngPrice.TabIndex = 9;
         this.voBtnChngPrice.Text = "Change Price";
         this.voBtnChngPrice.UseVisualStyleBackColor = true;
         this.voBtnChngPrice.Click += new System.EventHandler(this.voBtnChngPrice_Click);
         // 
         // voTxtPrice
         // 
         this.voTxtPrice.Location = new System.Drawing.Point(187, 221);
         this.voTxtPrice.Margin = new System.Windows.Forms.Padding(2);
         this.voTxtPrice.Name = "voTxtPrice";
         this.voTxtPrice.Size = new System.Drawing.Size(68, 20);
         this.voTxtPrice.TabIndex = 10;
         this.voTxtPrice.Text = "120";
         // 
         // voTxtSymbol
         // 
         this.voTxtSymbol.Location = new System.Drawing.Point(115, 194);
         this.voTxtSymbol.Margin = new System.Windows.Forms.Padding(2);
         this.voTxtSymbol.Name = "voTxtSymbol";
         this.voTxtSymbol.Size = new System.Drawing.Size(68, 20);
         this.voTxtSymbol.TabIndex = 11;
         // 
         // voTxtTrigger
         // 
         this.voTxtTrigger.Location = new System.Drawing.Point(187, 194);
         this.voTxtTrigger.Margin = new System.Windows.Forms.Padding(2);
         this.voTxtTrigger.Name = "voTxtTrigger";
         this.voTxtTrigger.Size = new System.Drawing.Size(68, 20);
         this.voTxtTrigger.TabIndex = 12;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(126, 179);
         this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(41, 13);
         this.label4.TabIndex = 13;
         this.label4.Text = "Symbol";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(199, 179);
         this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(40, 13);
         this.label5.TabIndex = 14;
         this.label5.Text = "Trigger";
         // 
         // voTxtChngSym
         // 
         this.voTxtChngSym.Location = new System.Drawing.Point(115, 221);
         this.voTxtChngSym.Margin = new System.Windows.Forms.Padding(2);
         this.voTxtChngSym.Name = "voTxtChngSym";
         this.voTxtChngSym.Size = new System.Drawing.Size(68, 20);
         this.voTxtChngSym.TabIndex = 15;
         this.voTxtChngSym.Text = "IBM";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(533, 292);
         this.Controls.Add(this.voTxtChngSym);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.voTxtTrigger);
         this.Controls.Add(this.voTxtSymbol);
         this.Controls.Add(this.voTxtPrice);
         this.Controls.Add(this.voBtnChngPrice);
         this.Controls.Add(this.voBtnUnsubscribe);
         this.Controls.Add(this.voBtnSubscribe);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.txtClientID);
         this.Controls.Add(this.txtB);
         this.Controls.Add(this.txtA);
         this.Controls.Add(this.btnTestCallback);
         this.Margin = new System.Windows.Forms.Padding(2);
         this.Name = "Form1";
         this.Text = "Form1";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.Load += new System.EventHandler(this.Form1_Load);
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
      private System.Windows.Forms.Button voBtnSubscribe;
      private System.Windows.Forms.Button voBtnUnsubscribe;
      private System.Windows.Forms.Button voBtnChngPrice;
      private System.Windows.Forms.TextBox voTxtPrice;
      private System.Windows.Forms.TextBox voTxtSymbol;
      private System.Windows.Forms.TextBox voTxtTrigger;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox voTxtChngSym;
   }
}


namespace Forms
{
    partial class ServerGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client Hand:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 106);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1370, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(269, 106);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stand";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1365, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dealer Hand:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(892, 1131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(366, 84);
            this.button3.TabIndex = 4;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ServerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2263, 1313);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "ServerGame";
            this.Text = "ServerGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerGame_FormClosing);
            this.Load += new System.EventHandler(this.ServerGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
    }
}
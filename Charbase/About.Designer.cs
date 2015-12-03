namespace Charbase
{
    partial class About
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "CharBase v0.1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 93);
            this.label2.TabIndex = 1;
            this.label2.Text = "CharBase v0.1 is a mini database application to keep track of characters, locatio" +
    "ns, and events in stories or novels you\'re writing.\r\n\r\nFeatures:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 60);
            this.label3.TabIndex = 2;
            this.label3.Text = "Add/Edit/List/Delete characters, locations, and events with pictures for each ite" +
    "m.\r\nLoad/Save .charbase files as JSON object with images inside them.";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(398, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Future features:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(21, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(381, 60);
            this.label5.TabIndex = 4;
            this.label5.Text = "Multiple pictures for each item.\r\nRelations between items.";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(398, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Feel free to contact me at:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(24, 299);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(124, 17);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "dev@q8geeks.org";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Charbase.Properties.Resources.database_512;
            this.pictureBox1.Location = new System.Drawing.Point(255, 204);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 336);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
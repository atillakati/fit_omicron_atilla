namespace Wifi.PlaylistEditor
{
    partial class NewPlaylistData
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
            this.btt_create = new System.Windows.Forms.Button();
            this.btt_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.txt_author = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btt_create
            // 
            this.btt_create.Location = new System.Drawing.Point(302, 143);
            this.btt_create.Name = "btt_create";
            this.btt_create.Size = new System.Drawing.Size(75, 23);
            this.btt_create.TabIndex = 0;
            this.btt_create.Text = "Create";
            this.btt_create.UseVisualStyleBackColor = true;
            this.btt_create.Click += new System.EventHandler(this.btt_create_Click);
            // 
            // btt_cancel
            // 
            this.btt_cancel.Location = new System.Drawing.Point(221, 143);
            this.btt_cancel.Name = "btt_cancel";
            this.btt_cancel.Size = new System.Drawing.Size(75, 23);
            this.btt_cancel.TabIndex = 1;
            this.btt_cancel.Text = "Cancel";
            this.btt_cancel.UseVisualStyleBackColor = true;
            this.btt_cancel.Click += new System.EventHandler(this.btt_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Author:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Please enter the playlist data:";
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(92, 68);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(285, 20);
            this.txt_title.TabIndex = 5;
            // 
            // txt_author
            // 
            this.txt_author.Location = new System.Drawing.Point(92, 99);
            this.txt_author.Name = "txt_author";
            this.txt_author.Size = new System.Drawing.Size(285, 20);
            this.txt_author.TabIndex = 6;
            // 
            // NewPlaylistData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 188);
            this.Controls.Add(this.txt_author);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btt_cancel);
            this.Controls.Add(this.btt_create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewPlaylistData";
            this.Text = "Create new Playlist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btt_create;
        private System.Windows.Forms.Button btt_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.TextBox txt_author;
    }
}
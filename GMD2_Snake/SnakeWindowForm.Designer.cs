namespace GMD2_Snake
{
    partial class SnakeWindowForm
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
            this.bgPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bgPB)).BeginInit();
            this.SuspendLayout();
            // 
            // bgPB
            // 
            this.bgPB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bgPB.Location = new System.Drawing.Point(12, 13);
            this.bgPB.Margin = new System.Windows.Forms.Padding(4);
            this.bgPB.Name = "bgPB";
            this.bgPB.Size = new System.Drawing.Size(667, 615);
            this.bgPB.TabIndex = 0;
            this.bgPB.TabStop = false;
            this.bgPB.Click += new System.EventHandler(this.bgPB_Click);
            // 
            // SnakeWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 639);
            this.Controls.Add(this.bgPB);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SnakeWindowForm";
            this.Text = "GMD2 - Snake";
            this.Load += new System.EventHandler(this.SnakeWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProcessInput);
            ((System.ComponentModel.ISupportInitialize)(this.bgPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bgPB;
    }
}


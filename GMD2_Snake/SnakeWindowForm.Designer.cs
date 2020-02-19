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
            this.test_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // test_textBox
            // 
            this.test_textBox.Location = new System.Drawing.Point(221, 192);
            this.test_textBox.Name = "test_textBox";
            this.test_textBox.Size = new System.Drawing.Size(378, 20);
            this.test_textBox.TabIndex = 0;
            this.test_textBox.TextChanged += new System.EventHandler(this.test_textBox_TextChanged);
            // 
            // SnakeWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.test_textBox);
            this.Name = "SnakeWindowForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SnakeWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox test_textBox;
    }
}


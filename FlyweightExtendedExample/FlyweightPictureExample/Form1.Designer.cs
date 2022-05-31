namespace FlyweightPictureExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FlyweightPictureBox = new System.Windows.Forms.PictureBox();
            this.NonFlyweightPictureBox = new System.Windows.Forms.PictureBox();
            this.RAMUsageInfoTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FlyweightPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonFlyweightPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FlyweightPictureBox
            // 
            this.FlyweightPictureBox.Location = new System.Drawing.Point(26, 60);
            this.FlyweightPictureBox.Name = "FlyweightPictureBox";
            this.FlyweightPictureBox.Size = new System.Drawing.Size(376, 397);
            this.FlyweightPictureBox.TabIndex = 0;
            this.FlyweightPictureBox.TabStop = false;
            this.FlyweightPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlyweightPictureBox_Click);
            // 
            // NonFlyweightPictureBox
            // 
            this.NonFlyweightPictureBox.Location = new System.Drawing.Point(459, 60);
            this.NonFlyweightPictureBox.Name = "NonFlyweightPictureBox";
            this.NonFlyweightPictureBox.Size = new System.Drawing.Size(376, 397);
            this.NonFlyweightPictureBox.TabIndex = 1;
            this.NonFlyweightPictureBox.TabStop = false;
            this.NonFlyweightPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NonFlyweightPictureBox_Click);
            // 
            // RAMUsageInfoTextBox
            // 
            this.RAMUsageInfoTextBox.Location = new System.Drawing.Point(26, 12);
            this.RAMUsageInfoTextBox.Name = "RAMUsageInfoTextBox";
            this.RAMUsageInfoTextBox.ReadOnly = true;
            this.RAMUsageInfoTextBox.Size = new System.Drawing.Size(809, 27);
            this.RAMUsageInfoTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 469);
            this.Controls.Add(this.RAMUsageInfoTextBox);
            this.Controls.Add(this.NonFlyweightPictureBox);
            this.Controls.Add(this.FlyweightPictureBox);
            this.Name = "Form1";
            this.Text = "Flyweight Pictures!";
            ((System.ComponentModel.ISupportInitialize)(this.FlyweightPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonFlyweightPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox FlyweightPictureBox;
        private PictureBox NonFlyweightPictureBox;
        private TextBox RAMUsageInfoTextBox;
    }
}
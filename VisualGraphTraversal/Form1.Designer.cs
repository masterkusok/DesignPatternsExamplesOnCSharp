namespace VisualGraphTraversal
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NLRMode = new System.Windows.Forms.Button();
            this.LNRMode = new System.Windows.Forms.Button();
            this.NextElemBtn = new System.Windows.Forms.Button();
            this.RLNMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(857, 447);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(12, 49);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(857, 27);
            this.OutputTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "OUTPUT:";
            // 
            // NLRMode
            // 
            this.NLRMode.Location = new System.Drawing.Point(888, 95);
            this.NLRMode.Name = "NLRMode";
            this.NLRMode.Size = new System.Drawing.Size(196, 91);
            this.NLRMode.TabIndex = 3;
            this.NLRMode.Text = "Left to Rigth mode";
            this.NLRMode.UseVisualStyleBackColor = true;
            this.NLRMode.Click += new System.EventHandler(this.NLRMode_Click);
            // 
            // LNRMode
            // 
            this.LNRMode.Location = new System.Drawing.Point(888, 204);
            this.LNRMode.Name = "LNRMode";
            this.LNRMode.Size = new System.Drawing.Size(196, 91);
            this.LNRMode.TabIndex = 4;
            this.LNRMode.Text = "Centered mode";
            this.LNRMode.UseVisualStyleBackColor = true;
            this.LNRMode.Click += new System.EventHandler(this.LNRMode_Click);
            // 
            // NextElemBtn
            // 
            this.NextElemBtn.Location = new System.Drawing.Point(888, 442);
            this.NextElemBtn.Name = "NextElemBtn";
            this.NextElemBtn.Size = new System.Drawing.Size(196, 100);
            this.NextElemBtn.TabIndex = 5;
            this.NextElemBtn.Text = "Next element";
            this.NextElemBtn.UseVisualStyleBackColor = true;
            this.NextElemBtn.Click += new System.EventHandler(this.NextElemBtn_Click);
            // 
            // RLNMode
            // 
            this.RLNMode.Location = new System.Drawing.Point(888, 317);
            this.RLNMode.Name = "RLNMode";
            this.RLNMode.Size = new System.Drawing.Size(196, 91);
            this.RLNMode.TabIndex = 7;
            this.RLNMode.Text = "Reverse mode";
            this.RLNMode.UseVisualStyleBackColor = true;
            this.RLNMode.Click += new System.EventHandler(this.RLNMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 568);
            this.Controls.Add(this.RLNMode);
            this.Controls.Add(this.NextElemBtn);
            this.Controls.Add(this.LNRMode);
            this.Controls.Add(this.NLRMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Visual graph traversal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox OutputTextBox;
        private Label label1;
        private Button NLRMode;
        private Button LNRMode;
        private Button NextElemBtn;
        private Button RLNMode;
    }
}
namespace fmDataTool
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
            this.LoadConfigButtion = new System.Windows.Forms.Button();
            this.SaveButtion = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.CheckFileButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TotalPB = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // LoadConfigButtion
            // 
            this.LoadConfigButtion.Location = new System.Drawing.Point(511, 12);
            this.LoadConfigButtion.Name = "LoadConfigButtion";
            this.LoadConfigButtion.Size = new System.Drawing.Size(100, 30);
            this.LoadConfigButtion.TabIndex = 0;
            this.LoadConfigButtion.Text = "LoadConfig";
            this.LoadConfigButtion.UseVisualStyleBackColor = true;
            this.LoadConfigButtion.Click += new System.EventHandler(this.LoadConfigButtion_Click);
            // 
            // SaveButtion
            // 
            this.SaveButtion.Location = new System.Drawing.Point(511, 48);
            this.SaveButtion.Name = "SaveButtion";
            this.SaveButtion.Size = new System.Drawing.Size(100, 30);
            this.SaveButtion.TabIndex = 1;
            this.SaveButtion.Text = "Save";
            this.SaveButtion.UseVisualStyleBackColor = true;
            this.SaveButtion.Click += new System.EventHandler(this.SaveButtion_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 29);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(487, 12);
            this.progressBar1.TabIndex = 2;
            // 
            // CheckFileButton
            // 
            this.CheckFileButton.Location = new System.Drawing.Point(511, 85);
            this.CheckFileButton.Name = "CheckFileButton";
            this.CheckFileButton.Size = new System.Drawing.Size(100, 30);
            this.CheckFileButton.TabIndex = 4;
            this.CheckFileButton.Text = "CheckFile";
            this.CheckFileButton.UseVisualStyleBackColor = true;
            this.CheckFileButton.Click += new System.EventHandler(this.CheckFileButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(487, 252);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // TotalPB
            // 
            this.TotalPB.Location = new System.Drawing.Point(13, 17);
            this.TotalPB.Name = "TotalPB";
            this.TotalPB.Size = new System.Drawing.Size(487, 12);
            this.TotalPB.TabIndex = 6;
            // 
            // fmDataTempleteTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 306);
            this.Controls.Add(this.TotalPB);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.CheckFileButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.SaveButtion);
            this.Controls.Add(this.LoadConfigButtion);
            this.Name = "fmDataTool";
            this.Text = "fmDataTool ver0.0.1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadConfigButtion;
        private System.Windows.Forms.Button SaveButtion;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button CheckFileButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ProgressBar TotalPB;
    }
}
using System.Drawing;
using System.Windows.Forms;

namespace fmDataTool.Loader.Base
{
    public partial class ExceptionPopUp : Form
    {
        private System.Windows.Forms.RichTextBox richTextBox1;

        public ExceptionPopUp()
        {
            InitializeComponent();
        }

        public ExceptionPopUp(string msg)
        {
            InitializeComponent();
            richTextBox1.AppendText(Color.Red, msg);
        }

        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(259, 236);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // ExceptionPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.richTextBox1);
            this.Name = "ExceptionPopUp";
            this.Text = "ExceptionPopUp";
            this.ResumeLayout(false);

        }
    }
}

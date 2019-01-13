using fmDataTool.Loader.Base;
using System;
using System.Windows.Forms;

namespace fmDataTool
{
    public partial class Form1 : Form
    {
        TempleteCreater m_loader = null;

        public Form1()
        {
            InitializeComponent();
            m_loader = new TempleteCreater(richTextBox1, progressBar1, TotalPB);
        }

        private void LoadConfigButtion_Click(object sender, EventArgs e)
        {
            bool isSucces = m_loader.SetConfig();
            if (false == isSucces)
                MessageBox.Show("설정 파일 인식 오류!!\r\n 다시 확인해 주세요.");
            else
                m_loader.PrintConfigs();
        }

        private void SaveButtion_Click(object sender, EventArgs e)
        {
            m_loader.Save();
        }

        private void CheckFileButton_Click(object sender, EventArgs e)
        {
            m_loader.CheckFile();
        }
    }
}

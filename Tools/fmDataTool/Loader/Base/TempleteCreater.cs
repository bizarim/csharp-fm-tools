using fmCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace fmDataTool.Loader.Base
{
    public partial class TempleteCreater
    {
        private bool m_isSaveFile = true;

        private RichTextBox m_textbox = null;
        private ProgressBar m_pbPart = null;
        private ProgressBar m_pbTotal = null;

        private fmDataTable m_tableFmData = null;

        public TempleteCreater(RichTextBox _textbox, ProgressBar PartPB, ProgressBar totalPB)
        {
            m_tableFmData = new fmDataTable();
            m_textbox = _textbox;
            m_pbPart = PartPB;
            m_pbTotal = totalPB;
            TextBoxClear();
        }

        protected void WriteTextBox(Color color, string msg)
        {
            m_textbox.AppendText(color, msg);
            m_textbox.ScrollToCaret();
        }

        protected void Error(string msg)
        {
            m_isSaveFile = false;
            Color color = Color.Red;

            m_textbox.AppendText(color, msg);
            m_textbox.ScrollToCaret();
        }

        protected void TextBoxClear()
        {
            m_textbox.Text = string.Empty;
        }

        protected void SetPartPB(int maxcount)
        {
            m_pbPart.Value = 0;
            m_pbPart.Maximum = maxcount;
            m_pbPart.Step = 1;
        }

        protected void SetTotalPB(int maxcount)
        {
            m_pbTotal.Value = 0;
            m_pbTotal.Maximum = maxcount;
            m_pbTotal.Step = 1;
        }

        protected void ProcessPartPB()
        {
            m_pbPart.PerformStep();
        }

        protected void ProcessTotalPB()
        {
            m_pbTotal.PerformStep();
        }

        protected void PopUp(string msg)
        {
            ExceptionPopUp form = new ExceptionPopUp(msg);
            form.Show();
        }
    }

    public partial class TempleteCreater
    {
        private static readonly string m_strBinaryFileName = "fmData.fm";

        private void Clear()
        {
            m_isSaveFile = true;

            m_tableFmData.Clear();
            fmLinker.Clear();
            DataLinkManager.Clear();
        }

        public bool Save()
        {
            if (null == m_listConfigs)
                return false;

            // 1. 엑셀 로드
            LoadExcel();
            // 2. 데이타 유효성 검사
            CheckValidData();
            // 3. 버퍼 파일 쓰기
            Write();

            Clear();

            return true;
        }

        private void LoadExcel()
        {
            TextBoxClear();

            SetTotalPB(m_listConfigs.Count);

            foreach (var node in m_listConfigs)
            {
                LoadExcelWithConfig(node);
                ProcessTotalPB();
            }
        }

        private void Write()
        {
            if (false == m_isSaveFile)
            {
                Error("Can Not Save File");
                return;
            }

            using (BufferCoder coder = new BufferCoder())
            {
                m_tableFmData.EncodeDecode(eCoderType.Encode, coder);

                if (System.IO.File.Exists(m_strBinaryFileName))
                    System.IO.File.Delete(m_strBinaryFileName);

                using (FileStream fs = new FileStream(m_strBinaryFileName, System.IO.FileMode.Create))
                {
                    byte[] output = coder.GetBuffer();
                    fs.Write(output, 0, coder.GetBufferLen());
                    fs.Close();
                }


            }

            WriteTextBox(Color.Blue, string.Format("Complete Save Binary File[{0}]", m_strBinaryFileName));
        }

        // 이름을 쫌 바꿀까?
        private void LoadExcelWithConfig(ConfigItem item)
        {
            try
            {
                // 엑셀 이름과 엑셀 시트 이름과 타입
                eFmDataType eFmDataType;
                Enum.TryParse(item.m_strFmDataType, out eFmDataType);
                string fullPath = string.Format("{0}{1}", m_strFolderPath, item.m_strFileName);
                string sheetName = item.m_strSheetName;

                ExcelLoader excelLoader = new ExcelLoader();
                DataTable data = excelLoader.GetData(fullPath, sheetName);

                SetPartPB(data.Rows.Count);

                foreach (DataRow row in data.Rows)
                {
                    if (null == row.ItemArray)
                        continue;

                    if (row.ItemArray.Length <= 0)
                        continue;

                    if(null == row.ItemArray[0])
                        continue;

                    int nTemp = 0;
                    if (false == int.TryParse(row.ItemArray[0].ToString(), out nTemp))
                        continue;

                    fmDataLoader loader = CreateLoader(eFmDataType);
                    if (null == loader)
                    {
                        Error("CreateLoader loader == null \r\n");
                        continue;
                    }

                    fmData _fmData = loader.GetFmData();
                    if (null == _fmData)
                    {
                        Error("_fmData == null \r\n");
                        continue;
                    }

                    loader.LoadExcelSheet(row);

                    if (false == loader.IsValid())
                    {
                        Error(string.Format("IsValid == false {0}\r\n", _fmData.Code));
                        continue;
                    }

                    if (false == m_tableFmData.Add(_fmData))
                    {
                        Error(string.Format("m_tableFmData.Add == false {0} {1}\r\n", eFmDataType, _fmData.Code));
                        return;
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Load Excel - {0} {1} {2} {3}\r\n", item.m_strFileName, item.m_strSheetName, item.m_strFmDataType, _fmData.Code);

                    WriteTextBox(Color.Black, sb.ToString());

                    ProcessPartPB();
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0} {1} {2}\r\n", item.m_strFileName, item.m_strSheetName, item.m_strFmDataType);
                Error(sb.ToString());
                PopUp(ex.ToString());
            }
        }
    }

    public partial class TempleteCreater
    {
        private bool CheckValidData()
        {
            bool isSuccess = true;

            SetTotalPB(fmLinker.m_dicLinks.Count);

            foreach (var nodes in fmLinker.m_dicLinks)
            {
                SetPartPB(nodes.Value.Count);


                foreach (var node in nodes.Value)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("{0} ", node.m_eFromFmDataType);
                    sb.AppendFormat("{0} ", node.m_nFromIndex);
                    sb.AppendFormat("/ {0} ", node.m_eToFmDataType);
                    sb.AppendFormat("{0}", node.m_nToIndex);

                    // 이 것 같고 어떻게 링크를 해 줄 수 있는 거지?
                    fmData fromFmData = m_tableFmData.Find(node.m_eFromFmDataType, node.m_nFromIndex);
                    if (null == fromFmData)
                    {
                        Error(string.Format("Error fromFmData CheckValidData  {0}\r\n", sb.ToString()));
                        isSuccess = false;
                        continue;
                    }

                    fmData toFmData = m_tableFmData.Find(node.m_eToFmDataType, node.m_nToIndex);
                    if (null == toFmData)
                    {
                        Error(string.Format("Error toFmData CheckValidData  {0}\r\n", sb.ToString()));
                        isSuccess = false;
                        continue;
                    }

                    DataLink fromDataLink = DataLinkManager.Find(node.m_strFromKey, node.m_nFromIndex);
                    if (null != fromDataLink)
                    {
                        fromDataLink.Add(toFmData);
                    }

                    DataLink toDataLink = DataLinkManager.Find(node.m_strToKey, node.m_nToIndex);
                    if (null != toDataLink)
                    {
                        toDataLink.Add(fromFmData);
                    }

                    WriteTextBox(Color.Black, string.Format("CheckValidData - {0}\r\n", sb.ToString()));

                    ProcessPartPB();
                }

                ProcessTotalPB();
            }

            return isSuccess;
        }

        public void CheckFile()
        {
            using (BufferCoder coder = new BufferCoder())
            {
                using (FileStream fs = new FileStream(m_strBinaryFileName, FileMode.Open, FileAccess.Read))
                {

                    byte[] output = coder.GetBuffer();

                    fs.Read(output, 0, output.Length);

                    fs.Close();
                }

                m_tableFmData.EncodeDecode(eCoderType.Decode, coder);

                if (false == CheckValidData())
                {
                    Error("Failed. CheckValidData\r\n");
                }
                else
                {
                    WriteTextBox(Color.Blue, "Success. CheckValidData\r\n");
                }

            }

            Clear();
        }
    }

    public partial class TempleteCreater
    {
        private string m_strFolderPath = string.Empty;
        private List<ConfigItem> m_listConfigs = null;

        public bool SetConfig()
        {
            string strCurDirectory = System.IO.Directory.GetCurrentDirectory();

            FileDialog fileDlg = new OpenFileDialog();
            fileDlg.InitialDirectory = strCurDirectory;
            fileDlg.RestoreDirectory = true;

            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                string fullPath = fileDlg.FileName;

                string[] args = fullPath.Split('\\');
                int count = args.Length - 1;
                string xmltemp = args[count];

                //if (!xmltemp.Equals("Aconfig.xml"))
                //    return false;

                m_strFolderPath = fullPath.Replace(xmltemp, "");

                try
                {
                    using (StreamReader sr = File.OpenText(fullPath))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                        Configuration config = serializer.Deserialize(sr) as Configuration;

                        m_listConfigs = new List<ConfigItem>(config.m_list);
                    }
                }
                catch (Exception ex)
                {
                    string strEX = ex.ToString();
                    return false;
                }

            }
            else
            {
                return false;
            }


            return true;
        }

        public void PrintConfigs()
        {
            if (null == m_listConfigs)
                return;

            SetPartPB(m_listConfigs.Count);

            WriteTextBox(Color.Red, string.Format("총 {0}개\r\n", m_listConfigs.Count));

            foreach (var node in m_listConfigs)
            {
                WriteTextBox(Color.Black, string.Format("파일명:{0} 시트명:{1} 타입:{2}\r\n", node.m_strFileName, node.m_strSheetName, node.m_strFmDataType));
                ProcessPartPB();
            }

            WriteTextBox(Color.Blue, string.Format("완료\r\n", m_listConfigs.Count));
        }
    }

    public partial class TempleteCreater
    {
        // fmData 만들기 순서 05
        // CreateLoader()안에 추가

        private fmDataLoader CreateLoader(eFmDataType type)
        {
            switch (type)
            {
                case eFmDataType.DTomb:             return new LoaderDragonTomb();
                case eFmDataType.Maze:              return new LoaderMaze();
                case eFmDataType.Monster:           return new LoaderMonster();
                case eFmDataType.Item:              return new LoaderItem();
                case eFmDataType.DropValue:         return new LoaderDropValue();
                case eFmDataType.Mission:           return new LoaderMission();
                case eFmDataType.Shop:              return new LoaderShop();
                case eFmDataType.Exp:               return new LoaderExp();
                case eFmDataType.PvpDummy:          return new LoaderPvpDummy();
                case eFmDataType.Option:            return new LoaderOption();
                case eFmDataType.Map:               return new LoaderMap();
                case eFmDataType.InDun: return new LoaderInDun();


                default:
                    break;
            }

            return null;
        }
    }
}

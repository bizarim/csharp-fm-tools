using fmCommon;
using fmDataTool.Loader.Base;
using System;
using System.Collections.Generic;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderOption : fmDataLoader
    {
        public LoaderOption()
        {
            m_fmData = new fmDataOption();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataOption data = m_fmData as fmDataOption;

            data.m_nCode = GetInt(rowData, "nCode");
            {
                string str = GetString(rowData, "eOption");
                data.m_eOption = (eOption)Enum.Parse(typeof(eOption), str);
            }
            data.m_nAppearLv = GetInt(rowData, "nAppearLv");
            {
                string[] strParts = GetStrArray(rowData, "eParts");
                
                List<int> list = new List<int>();

                foreach (var node in strParts)
                {
                    if (false == string.IsNullOrEmpty(node))
                    {
                        eParts parts = (eParts)Enum.Parse(typeof(eParts), node);
                        list.Add((int)parts);
                    }
                }
                data.m_nArrParts = list.ToArray();
            }
            {
                string[] strBeyond = GetStrArray(rowData, "eBeyond");
                List<int> list = new List<int>();

                foreach (var node in strBeyond)
                {
                    if (false == string.IsNullOrEmpty(node))
                    {
                        eBeyond parts = (eBeyond)Enum.Parse(typeof(eBeyond), node);
                        list.Add((int)parts);
                    }
                }
                data.m_nArrBeyond = list.ToArray();
            }
            
            //data.m_nWorld = GetInt(rowData, "nWorld");
            //data.m_nInDun = GetInt(rowData, "nIndun");

        }

        public override bool IsValid()
        {
            fmDataOption data = m_fmData as fmDataOption;

            return true;
        }
    }
}

using fmCommon;
using fmDataTool.Loader.Base;
using System;
using System.Collections.Generic;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderItem : fmDataLoader
    {
        public LoaderItem()
        {
            m_fmData = new fmDataItem();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataItem data = m_fmData as fmDataItem;

            data.m_nCode        = GetInt(rowData, "nCode");
            data.m_strNameCode  = GetString(rowData, "strNameCode");
            data.m_strImage     = GetString(rowData, "strImage");
            {
                string str = GetString(rowData, "eBeyond");
                data.m_eBeyond = (eBeyond)Enum.Parse(typeof(eBeyond), str);
            }
            {
                string str = GetString(rowData, "eParts");
                data.m_eParts = (eParts)Enum.Parse(typeof(eParts), str);
            }
            data.m_nPrice       = GetInt(rowData, "nPrice");
            {
                string str = GetString(rowData, "eWeapon");
                data.m_eWeapon = (eWeapon)Enum.Parse(typeof(eWeapon), str);
            }
            string[] strOpts    = GetStrArray(rowData, "eOptions");

            List<int> list = new List<int>();
            foreach (var node in strOpts)
            {
                eOption eOpt = (eOption)Enum.Parse(typeof(eOption), node);
                list.Add((int)eOpt);
            }
            data.m_nArrOptions  = list.ToArray();

            
        }

        public override bool IsValid()
        {
            fmDataItem data = m_fmData as fmDataItem;

            return true;
        }
    }
}


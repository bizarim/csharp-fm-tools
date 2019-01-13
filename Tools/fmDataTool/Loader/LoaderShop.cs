using fmCommon;
using fmDataTool.Loader.Base;
using System;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderShop : fmDataLoader
    {
        public LoaderShop()
        {
            m_fmData = new fmDataShop();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataShop data = m_fmData as fmDataShop;
            data.m_nCode = GetInt(rowData, "nCode");
            {
                string str = GetString(rowData, "eShop");
                data.m_eShop = (eShop)Enum.Parse(typeof(eShop), str);
            }
            data.m_strName = GetString(rowData, "strName");
            {
                string str = GetString(rowData, "eReward");
                data.m_eReward = (eReward)Enum.Parse(typeof(eReward), str);
            }
            data.m_nAmount = GetInt(rowData, "nAmount");
            {
                string str = GetString(rowData, "eFinance");
                data.m_eFinance = (eFinance)Enum.Parse(typeof(eFinance), str);
            }
            data.m_fNeed = GetFloat(rowData, "fNeed");
            data.m_strCashCode = GetString(rowData, "strCashCode");
            {
                string str = GetString(rowData, "eAddItemGrade");
                data.m_eAddItemGrade = (eGrade)Enum.Parse(typeof(eGrade), str);
            }
        }

        public override bool IsValid()
        {
            fmDataShop data = m_fmData as fmDataShop;

            return true;
        }
    }
}

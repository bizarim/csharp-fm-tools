using fmCommon;
using fmDataTool.Loader.Base;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderDropValue : fmDataLoader
    {
        public LoaderDropValue()
        {
            m_fmData = new fmDataDropValue();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataDropValue data = m_fmData as fmDataDropValue;

            data.m_nCode = GetInt(rowData, "nCode");
            data.m_strDropPlace = GetString(rowData, "strDropPlace");
            data.m_eGrade = (eGrade)GetInt(rowData, "eGrade");
            data.m_eParts = (eParts)GetInt(rowData, "eParts");
            data.m_nLimitValue = GetInt(rowData, "nLimitValue");
            data.m_nRate = GetInt(rowData, "nRate");

        }

        public override bool IsValid()
        {
            fmDataDropValue data = m_fmData as fmDataDropValue;

            return true;
        }
    }
}


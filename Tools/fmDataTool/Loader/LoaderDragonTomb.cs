using fmCommon;
using fmDataTool.Loader.Base;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderDragonTomb : fmDataLoader
    {
        public LoaderDragonTomb()
        {
            m_fmData = new fmDataDragonTomb();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataDragonTomb data = m_fmData as fmDataDragonTomb;

            data.m_nCode                = GetInt(rowData, "nCode");
            data.m_strNameCode          = GetString(rowData, "strNameCode");
            data.m_strImage             = GetString(rowData, "strImage");
            data.m_eLevel               = (eLevel)GetInt(rowData, "eLevel");
            data.m_nArrAppearMon        = GetIntArray(rowData, "nArrAppearMon");
            data.m_nArrAppearRateMon    = GetIntArray(rowData, "nArrAppearRateMon");
        }

        public override bool IsValid()
        {
            fmDataDragonTomb data = m_fmData as fmDataDragonTomb;

            return true;
        }
    }
}

using fmCommon;
using fmDataTool.Loader.Base;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderPvpDummy : fmDataLoader
    {
        public LoaderPvpDummy()
        {
            m_fmData = new fmDataPvpDummy();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataPvpDummy data = m_fmData as fmDataPvpDummy;

            data.m_nCode = GetInt(rowData, "nCode");
            data.m_nLv = GetInt(rowData, "nLv");
        }

        public override bool IsValid()
        {
            fmDataPvpDummy data = m_fmData as fmDataPvpDummy;

            return true;
        }
    }
}

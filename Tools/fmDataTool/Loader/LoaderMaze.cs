using fmCommon;
using fmDataTool.Loader.Base;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderMaze : fmDataLoader
    {
        public LoaderMaze()
        {
            m_fmData = new fmDataMaze();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataMaze data = m_fmData as fmDataMaze;

            data.m_nCode                = GetInt(rowData, "nCode");
            data.m_nFloor               = GetInt(rowData, "nFloor");
            data.m_nArrAppearMon        = GetIntArray(rowData, "nArrAppearMon");
            data.m_nArrAppearRateMon    = GetIntArray(rowData, "nArrAppearRateMon");
        }

        public override bool IsValid()
        {
            fmDataMaze data = m_fmData as fmDataMaze;

            if (data.m_nArrAppearMon.Length != data.m_nArrAppearRateMon.Length)
                return false;

            return true;
        }
    }
}

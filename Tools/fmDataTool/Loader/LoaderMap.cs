using fmCommon;
using fmDataTool.Loader.Base;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderMap : fmDataLoader
    {
        public LoaderMap()
        {
            m_fmData = new fmDataMap();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataMap data = m_fmData as fmDataMap;
            data.m_nCode = GetInt(rowData, "nCode");
            data.m_nMap = GetInt(rowData, "nMap");
            data.m_strNameCode = GetString(rowData, "strNameCode");
        }

        public override bool IsValid()
        {
            fmDataMap data = m_fmData as fmDataMap;

            return true;
        }
    }
}

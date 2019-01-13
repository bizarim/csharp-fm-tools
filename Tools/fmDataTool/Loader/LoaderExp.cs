using fmCommon;
using fmDataTool.Loader.Base;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderExp : fmDataLoader
    {
        public LoaderExp()
        {
            m_fmData = new fmDataExp();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataExp data = m_fmData as fmDataExp;

            data.m_nCode                = GetInt(rowData, "nCode");
            data.m_biTotalExp           = GetLong(rowData, "biTotalExp");
            data.m_biNeedExp            = GetLong(rowData, "biNeedExp");
        }

        public override bool IsValid()
        {
            fmDataExp data = m_fmData as fmDataExp;

            return true;
        }
    }
}

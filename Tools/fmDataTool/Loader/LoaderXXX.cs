using fmCommon;
using fmDataTool.Loader.Base;
using System.Data;

namespace fmDataTool.Loader
{
    // fmData 만들기 순서 04
    class LoaderXXX : fmDataLoader
    {

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataXXX data = m_fmData as fmDataXXX;

            {
                fmLink link = new fmLink();
                link.m_eFromFmDataType = data.GetFmDataType();
                //link.m_eToFmDataType = eFmDataType.Item;

                //link.m_nFromIndex = data.Code;
                //link.m_nToIndex = data.m_nStoneItemid;

                //link.m_strFromKey = string.Empty;
                //link.m_strToKey = "m_linkDicSummonUnit";

                fmLinker.Add(link);
            }
        }

        public override bool IsValid()
        {
            fmDataXXX data = m_fmData as fmDataXXX;

            return true;
        }
    }
}

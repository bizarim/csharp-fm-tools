using fmCommon;
using fmDataTool.Loader.Base;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderMonster : fmDataLoader
    {
        public LoaderMonster()
        {
            m_fmData = new fmDataMonster();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataMonster data = m_fmData as fmDataMonster;

            data.m_nCode                = GetInt(rowData, "nCode");
            data.m_strNameCode          = GetString(rowData, "strNameCode");
            data.m_strImage             = GetString(rowData, "strImage");
            data.m_nLv                  = GetInt(rowData, "nLv");
            data.m_nExtraLv             = GetInt(rowData, "nExtraLv");
            data.m_eRareLv              = (eRareLv)GetInt(rowData, "eRareLv");
            data.m_eTrait               = (eTrait)GetInt(rowData, "eTrait");
            data.m_eElement             = (eElement)GetInt(rowData, "eElement");
            data.m_eUnit                = (eUnit)GetInt(rowData, "eUnit");
        }

        public override bool IsValid()
        {
            fmDataMonster data = m_fmData as fmDataMonster;

            return true;
        }
    }
}

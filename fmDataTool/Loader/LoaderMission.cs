using fmCommon;
using fmDataTool.Loader.Base;
using System;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderMission : fmDataLoader
    {
        public LoaderMission()
        {
            m_fmData = new fmDataMission();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            fmDataMission data = m_fmData as fmDataMission;

            data.m_nCode = GetInt(rowData, "nCode");

            {
                string mission = GetString(rowData, "eMission");
                data.m_eMission = (eMission)Enum.Parse(typeof(eMission), mission);
            }

            data.m_nCondition = GetInt(rowData, "nCondition");
            //data.m_strContents = GetString(rowData, "strContents");
            //data.m_nExp = GetInt(rowData, "nExp");
            {
                string reward = GetString(rowData, "eReward");
                data.m_eReward = (eReward)Enum.Parse(typeof(eReward), reward);
            }

            data.m_nValue = GetInt(rowData, "nValue");
        }

        public override bool IsValid()
        {
            fmDataMission data = m_fmData as fmDataMission;

            return true;
        }
    }
}

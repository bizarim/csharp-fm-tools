using fmCommon;
using fmDataTool.Loader.Base;
using System;
using System.Collections.Generic;
using System.Data;

namespace fmDataTool.Loader
{
    class LoaderInDun : fmDataLoader
    {
        public LoaderInDun()
        {
            m_fmData = new fmDataInDun();
        }

        public override void LoadExcelSheet(DataRow rowData)
        {
            //nCode	nInDunCode	nPlace	nNextPlace	nLv	nAppearMoveMon	nAppearPlaceMon	nBoss	nGoblin	nForge	nArrDropOption
            fmDataInDun data = m_fmData as fmDataInDun;
            data.m_nCode = GetInt(rowData, "nCode");
            data.m_nInDunCode = GetInt(rowData, "nInDunCode");
            data.m_nPlace = GetInt(rowData, "nPlace");
            data.m_nArrNextPlace = GetIntArrayWithZero(rowData, "nArrNextPlace");
            data.m_nLv = GetInt(rowData, "nLv");
            data.m_nRound = GetInt(rowData, "nRound");
            data.m_nAppearMon = GetIntArray(rowData, "nAppearMon");
            data.m_nArrAppearRateMon = GetIntArray(rowData, "nArrAppearRateMon");
            //data.m_nAppearPlaceMon = GetIntArray(rowData, "nAppearPlaceMon");
            data.m_nBoss = GetInt(rowData, "nBoss");
            data.m_nGoblin = GetInt(rowData, "nGoblin");
            data.m_nForge = GetInt(rowData, "nForge");

            {
                //data.nArrDropOption = GetIntArray(rowData, "nArrDropOption");
                string[] strParts = GetStrArray(rowData, "nArrDropOption");
                List<int> list = new List<int>();
                foreach (var node in strParts)
                {
                    eOption opt = (eOption)Enum.Parse(typeof(eOption), node);
                    list.Add((int)opt);
                }
                data.m_nArrDropOption = list.ToArray();
            }

            data.m_xPos = GetFloat(rowData, "fXPos");
            data.m_yPos = GetFloat(rowData, "fYPos");

        }

        public override bool IsValid()
        {
            fmDataInDun data = m_fmData as fmDataInDun;

            if (data.m_nAppearMon.Length != data.m_nArrAppearRateMon.Length)
                return false;


            return true;
        }
    }
}

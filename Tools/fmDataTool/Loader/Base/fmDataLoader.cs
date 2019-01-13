using fmCommon;
using System;
using System.Collections.Generic;
using System.Data;

namespace fmDataTool.Loader.Base
{
    public partial class fmDataLoader
    {
        protected fmDataLoader() { }
        protected fmData m_fmData = null;
        public fmData GetFmData() { return m_fmData; }
        public virtual void LoadExcelSheet(DataRow datarow) { }
        public virtual bool IsValid() { return true; }
    }

    public partial class fmDataLoader
    {
        private string[] GetStringParsing(string data)
        {
            data = data.Replace('[', ' ');
            data = data.Replace(']', ' ');
            data = data.Trim();

            return data.Split(':');
        }

        protected byte GetByte(DataRow datarow, string columnName)
        {
            var value = datarow[columnName];

            return Convert.ToByte(value);
        }

        protected float GetFloat(DataRow datarow, string columnName)
        {
            var value = datarow[columnName];

            return Convert.ToSingle(value);
        }

        protected int GetInt(DataRow datarow, string columnName)
        {
            var value = datarow[columnName];

            return Convert.ToInt32(value);
        }

        protected bool GetBool(DataRow datarow, string columnName)
        {
            var value = datarow[columnName];

            return Convert.ToBoolean(value);
        }

        protected long GetLong(DataRow datarow, string columnName)
        {
            var value = datarow[columnName];

            return Convert.ToInt64(value);
        }

        //protected byte[] GetByteArray(DataRow datarow, string columnName)
        //{
        //    var data = datarow[columnName];

        //    string[] strArrayValue = GetStringParsing(data.ToString());
        //    List<byte> list = new List<byte>();

        //    for (int i = 0; i < strArrayValue.Length; ++i)
        //    {
        //        byte byteValue = 0;
        //        if (byte.TryParse(strArrayValue[i].Trim(), out byteValue))
        //        {
        //            if (byteValue != 0)
        //                list.Add(byteValue);
        //        }
        //    }

        //    return list.ToArray();
        //}

        protected float[] GetFloatArray(DataRow datarow, string columnName)
        {
            var data = datarow[columnName];

            string[] strArrayValue = GetStringParsing(data.ToString());
            List<float> list = new List<float>();

            for (int i = 0; i < strArrayValue.Length; ++i)
            {
                float fValue = 0;
                if (float.TryParse(strArrayValue[i].Trim(), out fValue))
                {
                    if (fValue != 0)
                        list.Add(fValue);
                }
            }

            return list.ToArray();
        }

        protected int[] GetIntArray(DataRow datarow, string columnName)
        {
            var data = datarow[columnName];

            string[] strArrayValue = GetStringParsing(data.ToString());
            List<int> list = new List<int>();

            for (int i = 0; i < strArrayValue.Length; ++i)
            {
                int intValue = 0;
                if (int.TryParse(strArrayValue[i].Trim(), out intValue))
                {
                    if (intValue != 0)
                        list.Add(intValue);
                }
            }

            return list.ToArray();
        }

        protected int[] GetIntArrayWithZero(DataRow datarow, string columnName)
        {
            var data = datarow[columnName];

            string[] strArrayValue = GetStringParsing(data.ToString());
            List<int> list = new List<int>();

            for (int i = 0; i < strArrayValue.Length; ++i)
            {
                int intValue = 0;
                if (int.TryParse(strArrayValue[i].Trim(), out intValue))
                {
                    list.Add(intValue);
                }
            }

            return list.ToArray();
        }

        protected long[] GetLongArray(DataRow datarow, string columnName)
        {
            var data = datarow[columnName];

            string[] strArrayValue = GetStringParsing(data.ToString());
            List<long> list = new List<long>();

            for (int i = 0; i < strArrayValue.Length; ++i)
            {
                long biValue = 0;
                if (long.TryParse(strArrayValue[i].Trim(), out biValue))
                {
                    if (biValue != 0)
                        list.Add(biValue);
                }
            }

            return list.ToArray();
        }

        protected string GetString(DataRow datarow, string columnName)
        {
            var value = datarow[columnName];

            return value.ToString();
        }

        protected string[] GetStrArray(DataRow datarow, string columnName)
        {
            var data = datarow[columnName];

            return GetStringParsing(data.ToString());
        }
    }
}

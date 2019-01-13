using System.Collections.Generic;
using System.Xml.Serialization;

namespace fmDataTool.Loader.Base
{
    [XmlRoot("Config")]
    public class Configuration
    {
        [XmlElement("item")]
        public List<ConfigItem> m_list = new List<ConfigItem>();
    }

    public class ConfigItem
    {
        [XmlElement("flie")]
        public string m_strFileName { get; set; }
        [XmlElement("sheet")]
        public string m_strSheetName { get; set; }
        [XmlElement("eFmDataType")]
        public string m_strFmDataType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MasterRouteConverter
{
   public class MasterRoute
    {
        [XmlElement(ElementName = "Code", Order = 1)]
        public string Code { get; set; }
        [XmlElement(ElementName = "CITSiteCode", Order = 2)]
        public string CITSiteCode { get; set; }
        [XmlElement(ElementName = "Weekday", Order = 3)]
        public int Weekday { get; set; }
        [XmlElement(ElementName = "DistancePlanned", Order = 4)]
        public int DistancePlanned { get; set; }
        [XmlElement(ElementName = "CrewRequired", Order = 5)]
        public int CrewRequired { get; set; }
        [XmlElement(ElementName = "Description", Order = 6)]
        public string Description { get; set; }
        [XmlElement(ElementName = "ReferenceNumber", Order = 7)]
        public string ReferenceNumber { get; set; }
        [XmlElement(ElementName = "MasterRouteStop", Order = 8)]
        public List<MasterRouteStop> MasterRouteStops = new List<MasterRouteStop>();
    }
}

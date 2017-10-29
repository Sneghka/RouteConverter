using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MasterRouteConverter
{

    [Serializable]
    public class MasterRouteStop
    {
        public int SequenceNumber { get; set; }
        public string LocationCode { get; set; }
        public string ArrivalTime { get; set; }
        public string OnSiteTime { get; set; }
        public string DepartureTime { get; set; }
    }
}

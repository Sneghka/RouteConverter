using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRouteConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var converterXml = new ConvertToXml();
            converterXml.ConvertMasterRouteListToXml();
        }
    }
}

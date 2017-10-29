using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MasterRouteConverter
{
    public class ConvertToXml
    {
        public void ConvertMasterRouteListToXml()
        {
            var converter = new Converter();
            var listOfMasterRoutes = converter.DataTableToObjectList();

            using (var writer = new StreamWriter(@"D:\Converted MasterRoute List.xml"))
            {
                new XmlSerializer(typeof(List<MasterRoute>)).Serialize(writer, listOfMasterRoutes);
            }
           
        }
    }
}

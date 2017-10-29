using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRouteConverter
{
    public class Converter
    {
        public List<MasterRoute> DataTableToObjectList()
        {
            var dt = new DataTable();
            var masterRouteList = new List<MasterRoute>();

            WorkWithExcel.ExcelFileToDataTable(out dt, @"D:\Route Load file 261017 test.xlsx");

            var tempMasterRoute = new MasterRoute();
         
            foreach (DataRow row in dt.Rows)
            {
                var code = row["Code"].ToString();
              
                if (tempMasterRoute.Code != code)
                {
                   if(!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(tempMasterRoute.Code)) masterRouteList.Add(tempMasterRoute);

                    var storedMasterRoute = new MasterRoute
                    {
                        Code = code,
                        Weekday = Convert.ToInt32(row["Weekday"]),
                        CITSiteCode = row["CITSiteCode"].ToString(),
                        DistancePlanned = Convert.ToInt32(row["DistancePlanned"]),
                        CrewRequired = Convert.ToInt32(row["CrewRequired"]),
                        Description = row["Description"].ToString(),
                        ReferenceNumber = row["ReferenceNumber"].ToString()
                    };

                    tempMasterRoute = storedMasterRoute;
                }

                var storedStop = new MasterRouteStop
                {
                    SequenceNumber = Convert.ToInt32(row["SequenceNumber"]),
                    LocationCode = row["LocationCode"].ToString(),
                   ArrivalTime = Convert.ToDateTime(row["ArrivalTime"]).ToString("HH:mm"),
                    OnSiteTime = Convert.ToDateTime(row["OnSiteTime"]).ToString("HH:mm"),
                    DepartureTime = Convert.ToDateTime(row["DepartureTime"]).ToString("HH:mm")
                };
                tempMasterRoute.MasterRouteStops.Add(storedStop);

                int index = dt.Rows.IndexOf(row);
                if (index == dt.Rows.Count - 1) masterRouteList.Add(tempMasterRoute);
            }

            return masterRouteList;
        }


    }
}

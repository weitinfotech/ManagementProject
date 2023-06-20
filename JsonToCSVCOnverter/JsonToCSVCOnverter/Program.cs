using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JsonToCSVCOnverter
{
    public class Object
    {
        public string date { get; set; }
        public int deleted { get; set; }
        public bool draw { get; set; }
        public int id { get; set; }
        public string label { get; set; }
        public List<List<double>> polygon { get; set; }
        public string user { get; set; }
        public int verified { get; set; }
    }

    public class RootObject
    {
        public int imgHeight { get; set; }
        public int imgWidth { get; set; }
        public List<object> objects { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader(@"D:\New_Task\000\_cam1_1509438801455_000004.json"))
            {
                string json = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RootObject>(json);

                jsonStringToCSV(json);

            }
        }
        public static void jsonStringToCSV(string jsonContent)
        {
            //used NewtonSoft json nuget package
            XmlNode xml = JsonConvert.DeserializeXmlNode("{records:{record:" + jsonContent + "}}");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml.InnerXml);
            XmlReader xmlReader = new XmlNodeReader(xml);
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlReader);
            var dataTable = dataSet.Tables[1];

            //Datatable to CSV
            var lines = new List<string>();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
            var header = string.Join(",", columnNames);
            lines.Add(header);
            var valueLines = dataTable.AsEnumerable()
                               .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
            File.WriteAllLines(@"D:\New_Task\000\_cam1_1509438801455_000004.csv", lines);
        }
    }
}

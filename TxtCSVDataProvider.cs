using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GenerateQRcode
{
    class TxtCSVDataProvider : IDataProvider

    {
        string PathFile { get; set; }
        public List<string> LstStringData { get; set; }

        public TxtCSVDataProvider(string PathFile)
        {
            this.PathFile = PathFile;

        }

        public bool SourceDataProviderReady()
        {
            if (PathFile != null && PathFile.Length > 0)
                return true;
            else
                return false;
        }

        List<string> IDataProvider.GetData()
        {
            return File.ReadAllLines(PathFile)
               .Skip(1)
               .Where(row => row.Length > 0)
               .ToList();
        }

        List<DataStructure> IDataProvider.ParsingData()
        {
            string patern = @",(?=(?:[^']*'[^']*')*[^']*$)";


            var lststringData = LstStringData.Select(x => Regex.Split(x.Replace("\"", "'"), patern));
            List<DataStructure> data = new List<DataStructure>();
            foreach (var columns in lststringData)
            {
                data.Add(new DataStructure
                {

                    Article = columns[0],
                    Group = columns[1],
                    Provider = columns[2],
                    Model = columns[3],
                    SN = columns[4],
                    IN = columns[5],
                    Owner = columns[6],
                    Date = DateTime.Now.ToString("D"),

                });
            }

            return new List<DataStructure>();
        }
              
    }


}

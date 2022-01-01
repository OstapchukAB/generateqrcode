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
        public List<string> LstStringData { get; set; } = new List<string>();

       

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

        bool IDataProvider.GetData()
        {
           LstStringData= File.ReadAllLines(PathFile)
               .Skip(1)
               .Where(row => row.Length > 0)
               .ToList();
            return true;
        }

        List<DataStructureEntity> IDataProvider.ParsingData()
        {
            string patern = @",(?=(?:[^']*'[^']*')*[^']*$)";


            var lststringData = LstStringData.Select(x => Regex.Split(x.Replace("\"", "'"), patern));
            List<DataStructureEntity> data = new List<DataStructureEntity>();
            foreach (var columns in lststringData)
            {
                data.Add(new DataStructureEntity
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

            return data;
        }

       
    }


}

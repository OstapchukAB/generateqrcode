﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateQRcode
{
    public  class LoadTxtFromFile
    {

        public List<FilesStructures> ReadFromCSV(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(new FilesStructures().ParseRow).ToList();
        }
    }

     public class FilesStructures
    {
        public string Article { get; private set; }
        public string Group { get; private set; }
        public string Provider { get; private set; }
        public string Model { get; private set; }
        public string SN { get; private set; }
        public string IN { get; private set; }
        public string Owner { get; private set; }

        internal  FilesStructures ParseRow(string row)
        {
            var columns = row.Split(',');
            return new FilesStructures()
            {
                Article =  columns[0],
                Group =    columns[1],
                Provider = columns[2],
                Model =    columns[3],
                SN =       columns[4],
                IN =       columns[5],
                Owner =    columns[6]
            };
        }
    }
}

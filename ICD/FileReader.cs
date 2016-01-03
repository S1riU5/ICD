using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ICD
{
    public class FileReader
    {


        private IParser parser;
        private string icdString;
        

        public FileReader(IParser parser, string path )
        {
            this.parser = parser;
            //TODO make this more generic
            icdString = File.ReadAllText(path);
            parser.ParseIcdCatalog(icdString);
        }

        public List<DataSet> ConvertFileToDataSetList()
        {
            List<DataSet> icdDataSets = new List<DataSet>();
            parser.ParseIcdCatalog(icdString);
            return icdDataSets;
        }

        public IParser Parser { get; set; } 

    }
}
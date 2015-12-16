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
            this.icdString = File.ReadAllText(path);
            parser.ParseICDCatalog(icdString);
        }

        public List<DataSet> convertFileToDataSetList()
        {
            List<DataSet> icdDataSets = new List<DataSet>();
            parser.ParseICDCatalog(icdString);
            
           
            return icdDataSets;
        }

        public IParser Parser { get; set; } 

    }
}
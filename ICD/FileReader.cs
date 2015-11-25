using System;
using System.Collections.Generic;
using System.IO;

namespace ICD
{
    public class FileReader
    {


        private IParser parser;
        private StreamReader reader;

        public FileReader(IParser parser, string path )
        {
            this.parser = parser;
            this.reader = new StreamReader(path);
        }

        public IParser Parser { get; set; }  


        public List<DataSet> readFile()
        {

            return null;
        }


    }
}
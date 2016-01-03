using System;
using System.Runtime.InteropServices;

namespace ICD
{
    public class DataSet
    {
        public DataSet(string code, string icdText)
        {
            this.code = code;
            this.icdText = icdText;  
        }

        private string code;
        private string icdText;
        private string restOfIcdText;

        public string RestOfIcdText { get; set; }

        public int Code { get; set; }

        public string IcdString { get; set; }      
    }
}
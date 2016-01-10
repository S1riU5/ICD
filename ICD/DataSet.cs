using System;
using System.Runtime.InteropServices;

namespace ICD
{
    public class DataSet
    {
        public DataSet(string code, string icdText)
        {
            this.Code = code;
            this.IcdText = icdText;  
        }


        public string Code { get; set; }

        public string IcdText { get; set; }
    }
}
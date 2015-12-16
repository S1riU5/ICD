using System;
using System.Runtime.InteropServices;

namespace ICD
{
    public class DataSet
    {
        public DataSet(int code, string icdText)
        {
            this.code = code;
            this.icdText = icdText;  
        }

        private int code;
        private String icdText;
        private String restOfIcdText;

        public String RestOfIcdText { get; set; }

        public int Code { get; set; }

        public String IcdString { get; set; }      
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICD
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "icd10gm2014syst_edvascii_20130920.txt";
            FileReader tesReader = new FileReader(new Paser(),path);
          
        }
    }
}

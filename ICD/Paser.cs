using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ICD
{
    public class Paser : IParser
    {
        public List<DataSet> ParseICDCatalog(string icdStringList)    
        {
           List<DataSet> icdList = new List<DataSet>();

            string[] test = icdStringList.Split(new string[] {"LZ"}, StringSplitOptions.None);
            Debug.WriteLine("length: "+ test.Length);
            for (int i = 0; i < test.Length; i++)
            {
                Debug.WriteLine(test[i]);    
            }
            
            
            

            return icdList;
        }
    }
}
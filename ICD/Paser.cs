using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ICD
{
    public class Paser : IParser
    {
        private readonly List<string> _myTmp2 = new List<string>();
        private Regex _regex = new Regex(@"[ ]{2,}", RegexOptions.None);
        private const int _EmptyStringLen = 3; 

        private int _testCounter;
        private int _testcounterfalse = 0;
        private int _testcountertrue = 0;
        private Dictionary<string,List<string>> _icdDictionary = new Dictionary<string, List<string>>(); 

        public List<DataSet> ParseIcdCatalog(string icdStringList)
        {
            var icdList = new List<DataSet>();
            //TODO Take this to the other project

            //icdStringList.Replace("LZ\r\n", "LZ");
            var test = icdStringList.Split(new[] {"LZ"}, StringSplitOptions.None);
            
            
            //var codes = new List<string>();
            //var content = new List<string>();
            //var inner = test[1].Split(new[] {"\n"}, StringSplitOptions.None);
             
            var tmp = test.ToList().Select(i => i).Take(10);

            //var tmp = regex.Replace(test[i], w ]");

           
            foreach (var entry in tmp)
            {
                //Debug.WriteLine(IsRelevant(entry));
                //Debug.WriteLine(entry);
                //if (IsRelevant(entry))
                {
                    //TODO Splice data ( 1.remove \n and spaces 2. Parse for code 3. save content and code into 2 temporary variables )
                    //TODO create Dataset
                    //TODO Process data into Dataset

                    var section = NormalizeContent(entry);

                    ParseSection(section);



                    //_myTmp2.Add(_content);
                }
            }

            Debug.WriteLine("All: "+_testCounter);
            Debug.WriteLine("True: "+_testcountertrue);
            Debug.WriteLine("False: "+_testcounterfalse);
            return icdList;
        }


        //TODO Take this to the oither Project
        private string NormalizeContent(string entry)
        {
            string tmp = string.Empty;
            var content = entry.Split(new [] {"\r\n" },StringSplitOptions.None ).ToList();
            foreach (var line in content)
            {
                if (line != string.Empty) {
                    tmp += line+" ";
               }          
            }

            tmp = _regex.Replace(tmp, @" ").TrimEnd();
            return tmp ;
        }


        private bool CheckIfAppend(string line)
        {
            return true;
        }


        //TODO Clean up this methode maybe throw out empty lines before searching for relevant entries
        private bool IsRelevant(string row)
        {
            var add = false;
 
            if (checkIfEmpty(row))
            {
                add = addable(row); 
            }

            return add;
        }

        //TODO Take this to the other project
        private string ParseSection(string section)
        {
            string code = null;
            List<string> value = new List<string>();

            if (addable(section))
            {
               addEntryToDictonary(section);
            }

            return code;

        }

         

        //TODO Take this to the other project
        private void addEntryToDictonary(string section)
        {
            //var content = _regex(section, @" ");
            var data = section.Split(' ');

            Debugger.Break();
        }
        

        //TODO Take this to the other project
        private bool addable(string str)
        {
            var result = false;
            if (str != string.Empty)
            {
                var letter = str[0];
                result = letter.Equals('4') || letter.Equals('5') || letter.Equals('6');
            }

            return result;
        }


        //TODO get all content and the code and write it into the dictionary extract this also to the other project
        private string splitEntry(string NormalizedEntry)
        {


            return "Hallo";
        }

        private bool checkIfEmpty(string str)
        {
            return str.Count() > _EmptyStringLen;
        }
    }
}
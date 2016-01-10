#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace ICD
{
    public class Paser : IParser
    {
        private const int EmptyStringLen = 3;
        private const int One = 1;
        private readonly List<string> _myTmp2 = new List<string>();


        private Dictionary<string,List<string>> _icdDictionary = new Dictionary<string, List<string>>();
        private readonly Regex _regex = new Regex(@"[ ]{2,}", RegexOptions.None);

        public List<DataSet> ParseIcdCatalog(string icdStringList)
        {
            var icdList = new List<DataSet>();
            //TODO Take this to the other project
            var sectionList = icdStringList.Split(new[] {"LZ"}, StringSplitOptions.None).ToList();
            InsertStrinListIntoDataSetList(sectionList, icdList);
            Debugger.Break();
            return icdList;
        }

        private void InsertStrinListIntoDataSetList(List<string> sectionList, List<DataSet> icdList)
        {
            foreach (var entry in sectionList)
            {
                var section = NormalizeContent(entry);
                ParseSection(section, icdList);
            }
        }


        //TODO Take this to the oither Project
        private string NormalizeContent(string entry)
        {
            var tmp = string.Empty;
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
        private void ParseSection(string section, List<DataSet> icdDataSets)
        {
            if (addable(section))
            {
                icdDataSets.Add(ConvertEntryToDataset(section));
            }

        }


        //TODO Take this to the other project
        private DataSet ConvertEntryToDataset(string section)
        {
            var code = GetCode(section);
            var content = GetContent(section);
            return new DataSet(code,content);
            
        }


        private string GetContent(string section)
        {
            var beginOfCode = section.IndexOf(' ')+One;
            var beginOfContent = section.IndexOf(' ', beginOfCode);
            var currentIndex = beginOfContent;
            var content = string.Empty;
            while (IsNextLineOrEndOfString(section, currentIndex))
            {
                content += section[currentIndex];
                currentIndex++;

            }

            if (IsInklusiv(section, currentIndex))
            {                
                var nextContent = section.IndexOf(' ', currentIndex);
                while (IsNextLineOrEndOfString(section, currentIndex))
                {
                    content += section[currentIndex];
                    currentIndex++;
                }
            }
            return content;
        }

        private static bool IsInklusiv(string section, int currentIndex)
        {
            var nextIndex = currentIndex + One;
            var isInklusiv = false;
            if (nextIndex < section.Length - One)
            {
                isInklusiv = section[nextIndex] == 'I';
                
            }
            return isInklusiv;
        }

        private static bool IsNextLineOrEndOfString(string section, int currentIndex)
        {
            return section[0] != section[currentIndex] && currentIndex < section.Length-1;
        }

        //TODO EXPORT TO OTHER PROJECT
        private string GetCode(string section)
        {
            var beginOfCode = section.IndexOf(' ')+One;
            var endOfCode = section.IndexOf(' ', beginOfCode);
            var code = string.Empty;
            for (var i = beginOfCode; i < endOfCode; i++)
            {
                code += section[i];
            }
            return code;
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


        private bool checkIfEmpty(string str)
        {
            return str.Count() > EmptyStringLen;
        }
    }
}
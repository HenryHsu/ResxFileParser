using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ResxFileParser
{
    public class ResxFileParser
    {
        public Dictionary<string, string> DataName;
        
        private void FileParser(string FileName)
        {
            StreamReader ResxSR = new StreamReader(FileName);

            Regex ResxPattern = new Regex("<data name=\"(?<DataName>.+?)\"\\sxml:space=\".+?\">[\\r\\n\\s]*<value>(?<Value>.+?)</value>[\\r\\n\\s]*</data>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection ResxDataCollection = ResxPattern.Matches(ResxSR.ReadToEnd());
            foreach(Match SingleMatch in ResxDataCollection)
            {
                DataName.Add(SingleMatch.Groups["DataName"].Value, SingleMatch.Groups["Value"].Value);
            }
        }
    }
}

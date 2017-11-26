using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DecryptingText
{
    static class Decrypt
    {
        public static List<string> FileReader(string filename)
        {
            var fileStr = new List<string>();
            var sr = new StreamReader(filename, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
                fileStr.Add(line);
            return fileStr;
        }
        public static List<string> Decoder(List<string> fileStr)
        {
            var dic = new Dictionary<char, int>();
            const string abcCap = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            var abcLCase = abcCap.ToLower();
            var letterFrequency = new List<char> { 'о', 'е', 'т', 'а', 'и', 'н', 'р', 'в', 'с', 'п', 'л', 'к', 'д', 'м', 'ы', 'у', 'б', 'ь', 'ч', 'ж', 'я', 'г', 'й', 'х', 'з', 'ц', 'ю', 'э', 'ш', 'ф', 'щ', 'ё', 'г' };


            foreach (var letter in fileStr)
                foreach (var chr in letter)
                {
                    var c = Convert.ToChar(chr.ToString().ToLower());
                    if (!abcLCase.Contains(c)) continue;
                    if (!dic.ContainsKey(c))
                        dic.Add(c, 1);
                    else
                        dic[c]++;
                } 
           
            var sortedDict = dic.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            ICollection<int> value = sortedDict.Values;
            var valueList = new List<int>();
            valueList.AddRange(value);

            ICollection<char> keys = sortedDict.Keys;
            var keyList = new List<char>();
            keyList.AddRange(keys);

            var keyDict = new Dictionary<char, char>();
            for (var i = 0; i < keyList.Count; i++)
                keyDict.Add(keyList[i], letterFrequency[i]);


            var valueDict = new Dictionary<char, int>();
            for (var i = 0; i < 31; i++)
                valueDict.Add(letterFrequency[i],valueList[i] );

            var fstrOutput = new List<string>();
            foreach (var letter in fileStr)
            {
                var s = "";
                foreach (var chr in letter)
                {
                    if (abcCap.Contains(chr))
                    {
                        var c = Convert.ToChar(chr.ToString().ToLower());
                        s += keyDict[c].ToString().ToUpper();
                    }
                    else
                    {
                        if (abcLCase.Contains(chr))
                            s += keyDict[chr];
                        else
                            s += chr;
                    }
                }
                fstrOutput.Add(s);
            }
            return fstrOutput;
        }

    }
}

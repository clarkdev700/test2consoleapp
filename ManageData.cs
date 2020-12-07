using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddingStringNumber
{
    public static class ManageData
    {

        public static int Add(List<int> numberToAdd)
        {

            return numberToAdd.Count > 0 ? numberToAdd.Sum() : 0;
        }
        public static bool validateNumberFormat(string str)
        {
            string extractNumber = null;

            if (str.StartsWith("//"))
            {
                //extract number
                if (str.Length > 5)
                {
                    extractNumber = str.Substring(5);
                }
            }
            else
            {
                extractNumber = str;
            }

            if (extractNumber == null)
            {
                return false;
            }
            else
            {
                string pattern = @"\\n";
                Regex rgx = new Regex(pattern);
                foreach (Match match in rgx.Matches(extractNumber))
                {
                    var prevValue = extractNumber.Substring((match.Index - 1), 1);
                    int j = 0;
                    int.TryParse(prevValue, out j);
                    if (j == 0 && prevValue != "0")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static List<int> extractAddingNumber(string str)
        {
            //var strReplace = str.Replace("\\n", "");
            var strReplace = str.Replace("//", "");
            var strToChar = strReplace.ToCharArray();
            string delimiter = "";
            string temp = "";
            int index = 0;
            List<int> numberToAdd = new List<int>();
            foreach (var elt in strToChar)
            {
                index++;
                if (elt.ToString() == "-" || elt.ToString() == "+")
                {
                    temp += elt.ToString();
                    continue;
                }

                int eltout = -1;
                int.TryParse(elt.ToString(), out eltout);
                if (eltout > 0 || elt.ToString() == "0")
                {
                    //strBuilder.Append(elt);
                    //total += eltout;
                    temp += elt.ToString();
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(temp))
                    {
                        numberToAdd.Add(int.Parse(temp));
                        temp = "";
                    }

                    var lSeparator = "";
                    if (elt.ToString() == "n" && index >= 2)
                    {
                        lSeparator = getLiteralSeparator(strToChar, index, -1);
                    }

                    if (elt.ToString() == "\\")
                    {
                        lSeparator = getLiteralSeparator(strToChar, index, 1);
                    }


                    if (!string.IsNullOrEmpty(delimiter) && delimiter != elt.ToString() && lSeparator != "\\n")
                    {
                        return new List<int>();
                    }
                    else
                    {
                        if (lSeparator != "\\n")
                        {
                            delimiter = elt.ToString();
                        }

                    }

                }
            }
            if (!string.IsNullOrEmpty(temp))
            {
                numberToAdd.Add(int.Parse(temp));
            }
            //
            return numberToAdd;
        }
        private static string getLiteralSeparator(char[] records, int index, int x)
        {
            var ls = "";
            int startIndex = x > 0 ? index - 1 : index - 2;
            int endIndex = x > 0 ? index + 1 : index;
            for (var i = startIndex; i < endIndex; i++)
            {
                ls += records[i];
            }
            return ls;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReplaceCypher
{
    public static class Encoder
    {
        public static string Encode(string content, Dictionary<string, string> rule, bool splitCh = false)
        {
            string result = "";

            IEnumerable<string> arr;
            if (splitCh)
            {
                var temp = content.ToCharArray();
                var arr1 = new List<string>();
                for (int i = 0; i < content.Length; i++)
                {
                    arr1.Add( Convert.ToString(temp[i]));
                }

                arr = arr1;

            }
            else
            {
                arr = content.Split(" ");
            }

            string last = "\0";
            foreach (var ch in arr)
            {
                if (last == " " && ch == " ")
                {
                    result += " ";
                }
                else
                {
                    result += rule[ch];
                }

                last = ch;
            }

            return result;
        }
    }
}

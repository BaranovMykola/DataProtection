using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReplaceEncoder
{
    public static class Encoder
    {
        public static string Encode(string text, ReplaceTabel rule)
        {
            var splitted = rule.EncodeSplitter(text);
            return ToCypher(splitted, rule);
        }

        public static string Decode(string text, ReplaceTabel rule)
        {
            var splitted = rule.DecodeSplitter(text);
            return ToCypher(splitted, rule);
        }

        private static string ToCypher(List<string> splitted, ReplaceTabel rule)
        {
            string result = string.Empty;
            foreach (var ch in splitted)
            {
                if (ch != string.Empty)
                {
                    result += rule[ch];
                }
            }

            return result;
        }

        public static List<string> SplitByChar(string text)
        {
            var temp = text.ToCharArray();
            var splitted = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                splitted.Add(Convert.ToString(temp[i]));
            }

            return splitted;
        }

        public static List<string> SplitBySpace(string text)
        {
            return text.Split(" ").ToList();
        }
    }
}

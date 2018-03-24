using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ReplaceCypher
{
    using System.Collections.Generic;

    public static class CypherRuleBuilder
    {
        public static IEnumerable<string> EnglishAlphabet { get; }

        static CypherRuleBuilder()
        {
            var alphabet = "A a B b C c D d E e F f G g H h I i J j K k L l M m N n O o P p Q q R r S s T t U u V v W w X x Y y Z z";
            var lst = alphabet.Split(" ").ToList();
            EnglishAlphabet = lst;
        }

        public static Dictionary<string, string> BuildCesarCypher(int shift)
        {
            var alphaLst = EnglishAlphabet.ToList();
            var cypher = new Dictionary<string, string>();

            for (int i = 0; i < alphaLst.Count; i++)
            {
                cypher[alphaLst[i]] = alphaLst[(Math.Abs(i + shift*2)) % alphaLst.Count];
            }

            cypher[" "] = " ";

            return cypher;
        }

        public static Dictionary<string, string> BuildRandomCypher(int seed)
        {
            HashSet<int> code = new HashSet<int>();
            Random rnd = new Random();
            while (code.Count != EnglishAlphabet.Count())
            {
                code.Add(rnd.Next(0, 100));
            }

            var lst = code.ToList();
            lst.OrderBy(s => rnd.Next());

            var alphaLst = EnglishAlphabet.ToList();
            var cypher = new Dictionary<string,string>();
            for (int i = 0; i < alphaLst.Count; i++)
            {
                cypher[alphaLst[i]] = lst[i].ToString()+" ";
            }

            cypher[" "] = " ";

            return cypher;

        }

        public static Dictionary<string, string> InvertCypher(Dictionary<string, string> rule, bool trim = false)
        {
            var newRule = new Dictionary<string,string>();

            foreach (var pair in rule)
            {
                string val = pair.Value;
                if (trim)
                {
                    val = val.Trim();
                }

                newRule[val] = pair.Key;
            }

            return newRule;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReplaceEncoder
{
    public static class ReplaceTabelBuilder
    {
        public static IEnumerable<string> EnglishAlphabet { get; }

        static ReplaceTabelBuilder()
        {
            var alphabet = "A a B b C c D d E e F f G g H h I i J j K k L l M m N n O o P p Q q R r S s T t U u V v W w X x Y y Z z";
            var lst = alphabet.Split(" ").ToList();
            EnglishAlphabet = lst;
        }

        public static ReplaceTabel BuilderCesarCypheReplaceTabel(int shift)
        {
            var alphaLst = EnglishAlphabet.ToList();
            var cypher = new CesarCypher(new List<CypherPair>());

            for (int i = 0; i < alphaLst.Count; i++)
            {
                //cypher[alphaLst[i]] = alphaLst[(Math.Abs(i + shift * 2)) % alphaLst.Count];
                cypher.Cyphper.Add( new CypherPair(alphaLst[i], alphaLst[(Math.Abs(i + shift * 2)) % alphaLst.Count]));
            }

            cypher.Cyphper.Add(new CypherPair(" ", " "));

            return cypher;
        }

        public static ReplaceTabel BuidRandomCypheReplaceTabel(int seed)
        {
            HashSet<int> code = new HashSet<int>();
            Random rnd = new Random();
            while (code.Count != EnglishAlphabet.Count()+1)
            {
                code.Add(rnd.Next(0, 100));
            }

            var lst = code.ToList();
            lst.OrderBy(s => rnd.Next());

            var alphaLst = EnglishAlphabet.ToList();
            var cypher = new RadndomCypher(new List<CypherPair>());

            for (int i = 0; i < alphaLst.Count; i++)
            {
                //cypher[alphaLst[i]] = lst[i].ToString() + " ";
                cypher.Cyphper.Add( new CypherPair(alphaLst[i], lst[i].ToString()+" "));
            }

            cypher.Cyphper.Add( new CypherPair(" ", lst.Last().ToString()+" ") );

            return cypher;
        }
    }
}

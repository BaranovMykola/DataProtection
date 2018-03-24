using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceEncoder
{
    public class CesarCypher : ReplaceTabel
    {
        public CesarCypher()
        {
        }

        public CesarCypher(List<CypherPair> cyphper) : base(cyphper)
        {
        }

        public CesarCypher(string file) : base(file)
        {
        }

        public override void Invert()
        {
            base.Invert();
        }
    }
}

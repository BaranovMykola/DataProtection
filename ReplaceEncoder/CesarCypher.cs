using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceEncoder
{
    [Serializable]
    public class CesarCypher : ReplaceTabel
    {
        public CesarCypher()
        {
        }

        public CesarCypher(List<CypherPair> cyphper) : base(cyphper)
        {
        }

        public override void Invert()
        {
            base.Invert();
        }
    }
}

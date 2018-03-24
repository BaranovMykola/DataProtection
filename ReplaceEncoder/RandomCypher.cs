using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceEncoder
{
    [Serializable]
    public class RandomCypher : ReplaceTabel
    {
        public RandomCypher()
        {
        }

        public RandomCypher(List<CypherPair> cyphper) : base(cyphper)
        {
        }

        public override Func<string, List<string>> DecodeSplitter { get; } = Encoder.SplitBySpace;

        public override void Invert()
        {
            base.Invert();
            Cyphper.ForEach(s => s.From = s.From.Trim());
        }
    }
}

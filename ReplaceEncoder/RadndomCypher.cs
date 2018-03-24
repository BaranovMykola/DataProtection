using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceEncoder
{
    public class RadndomCypher : ReplaceTabel
    {
        public RadndomCypher()
        {
        }

        public RadndomCypher(List<CypherPair> cyphper) : base(cyphper)
        {
        }

        public RadndomCypher(string file) : base(file)
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

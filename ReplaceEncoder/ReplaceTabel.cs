using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using System.Xml.Serialization;

namespace ReplaceEncoder
{
    [Serializable]
    [XmlInclude(typeof(CesarCypher))]
    [XmlInclude(typeof(RandomCypher))]
    public class ReplaceTabel
    {
        public ReplaceTabel()
        {
            
        }

        public ReplaceTabel(List<CypherPair> cyphper)
        {
            Cyphper = cyphper;
        }

        public List<CypherPair> Cyphper { get; set; }

        public virtual Func<string, List<string>> EncodeSplitter { get; } = Encoder.SplitByChar;

        public virtual Func<string, List<string>> DecodeSplitter { get; } = Encoder.SplitByChar;

        public string this[string key]
        {
            get
            {
                return Cyphper.Find(s => s.From == key).To ?? throw new ArgumentException();
            }
        }

        public virtual void Invert()
        {
            Cyphper.ForEach(s => s.Swap());
        }
    }
}

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
    public class ReplaceTabel
    {
        public ReplaceTabel()
        {
            
        }

        public ReplaceTabel(List<CypherPair> cyphper)
        {
            Cyphper = cyphper;
        }

        public ReplaceTabel(string file)
        {
            this.Cyphper = ReplaceTabel.Read(file).Cyphper;
        }

        public List<CypherPair> Cyphper { get; set; }

        public virtual Func<string, List<string>> EncodeSplitter { get; } = Encoder.SplitByChar;

        public virtual Func<string, List<string>> DecodeSplitter { get; } = Encoder.SplitByChar;

        public void Write(string file)
        {
            File.WriteAllText(file, string.Empty);
            using (var stream = File.Open(file,FileMode.OpenOrCreate))
            {
                var xml = new XmlSerializer(typeof(ReplaceTabel));
                xml.Serialize(stream,this);
            }
        }

        public static ReplaceTabel Read(string file)
        {
            using (var stream = File.Open(file, FileMode.OpenOrCreate))
            {
                var xml = new XmlSerializer(typeof(ReplaceTabel));
                return xml.Deserialize(stream) as ReplaceTabel;
            }
        }

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

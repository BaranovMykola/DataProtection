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

        public ReplaceTabel(List<CypherPair> cyhper)
        {
            Cyhper = cyhper;
        }

        public ReplaceTabel(string file)
        {
            this.Cyhper = ReplaceTabel.Read(file).Cyhper;
        }

        public List<CypherPair> Cyhper { get; set; }

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
    }
}

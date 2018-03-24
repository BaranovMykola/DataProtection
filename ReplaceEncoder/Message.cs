using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ReplaceEncoder
{
    [Serializable]
    public class Message
    {
        public ReplaceTabel Cypher { get; set; }

        public string EncodedText { get; set; }

        public int CesarShift { get; set; }

        public void Write(string file)
        {
            File.WriteAllText(file, string.Empty);
            using (var stream = File.Open(file, FileMode.OpenOrCreate))
            {
                var xml = new XmlSerializer(typeof(Message));
                xml.Serialize(stream, this);
            }
        }

        public static Message Read(string file)
        {
            using (var stream = File.Open(file, FileMode.OpenOrCreate))
            {
                var xml = new XmlSerializer(typeof(Message));
                return xml.Deserialize(stream) as Message;
            }
        }
    }
}

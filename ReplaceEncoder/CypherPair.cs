using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ReplaceEncoder
{
    [Serializable]
    public class CypherPair
    {
        public CypherPair()
        {
            
        }

        public CypherPair(string from, string to)
        {

            From = from;
            To = to;
        }

        public void Swap()
        {
            string tempFrom = From;
            From = To;
            To = tempFrom;
        }

        [XmlAttribute]
        public string From { get; set; }

        [XmlAttribute]
        public string To { get; set; }
    }
}

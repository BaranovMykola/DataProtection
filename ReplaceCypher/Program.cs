using System;
using System.Collections.Generic;
using System.IO;

namespace ReplaceCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Replace cypher:");
                Console.Write("Input file: ");
                string fileName = Console.ReadLine();
                string content = File.ReadAllText(fileName);

                int cesarShift = 1;
                var CesarRule = CypherRuleBuilder.BuildCesarCypher(cesarShift);
                var RandomCypher = CypherRuleBuilder.BuildRandomCypher(1);

                Console.WriteLine("Cesar cypher");
                PrintCypher(CesarRule);
                Console.WriteLine("Replace cypher");
                PrintCypher(RandomCypher);

                string encoded = Encoder.Encode(content, CesarRule, true);

                Console.WriteLine(content);
                Console.WriteLine("--->");
                Console.WriteLine(encoded);
                Console.WriteLine("--->");
                encoded = Encoder.Encode(encoded, RandomCypher, true);
                Console.WriteLine(encoded);
                Console.WriteLine("--->");

                string decoded = Encoder.Encode(encoded, CypherRuleBuilder.InvertCypher(RandomCypher, true), false);
                Console.WriteLine(decoded);
                Console.WriteLine("--->");
                decoded = Encoder.Encode(decoded, CypherRuleBuilder.InvertCypher(CesarRule), true);
                Console.WriteLine(decoded);
                Console.WriteLine("--->");

                Console.Write("Write to file: ");
                fileName = Console.ReadLine();
                File.WriteAllText(fileName,content);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error handled:");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }

        static void PrintCypher(Dictionary<string, string> rule)
        {
            foreach (var ch in rule)
            {
                Console.WriteLine($"{ch.Key} ---> {ch.Value}");
            }
        }
    }
}

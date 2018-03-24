using System;
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
                string encoded = Encoder.Encode(content, CesarRule, true);
                var RandomCypher = CypherRuleBuilder.BuildRandomCypher(1);
                encoded = Encoder.Encode(encoded, RandomCypher, true);

                string decoded = Encoder.Encode(encoded, CypherRuleBuilder.InvertCypher(RandomCypher, true), false);
                decoded = Encoder.Encode(decoded, CypherRuleBuilder.InvertCypher(CesarRule), true);

                Console.WriteLine(content);
                Console.WriteLine();
                Console.WriteLine(encoded);
                Console.WriteLine();
                Console.WriteLine(decoded);

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
    }
}

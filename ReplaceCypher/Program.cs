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
                var CesarRule = CypherRuleBuilder.BuildRandomCypher(cesarShift);

                string encoded = Encoder.Encode(content, CesarRule, true);
                //encoded = encoded.Replace("  ", " ");
                string decoded = Encoder.Encode(encoded, CypherRuleBuilder.InvertCypher(CesarRule), false);

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

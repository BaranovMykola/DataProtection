using System;
using System.Collections.Generic;

namespace ReplaceEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            const string text = "In physics string theory is a theoretical framework in which " +
                          "the pointlike particles of particle physics are replaced" +
                          " by onedimensional objects called strings";

            var cesar = ReplaceTabelBuilder.BuilderCesarCypheReplaceTabel(1);
            var random = ReplaceTabelBuilder.BuidRandomCypheReplaceTabel(1);

            var endoded = Encoder.Encode(text, cesar);
            endoded = Encoder.Encode(endoded, random);

            cesar.Invert();
            random.Invert();

            var decoded = Encoder.Decode(endoded, random);
            decoded = Encoder.Decode(decoded, cesar);

            Console.ReadKey();
        }
    }
}

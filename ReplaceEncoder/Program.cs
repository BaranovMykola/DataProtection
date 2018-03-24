using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Xml;

namespace ReplaceEncoder
{
    class Program
    {
        static void Help()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("\tencode <txt source> <xml destination> <cesar shift> <cesar direction [-l|-r]>");
            Console.WriteLine("\tdecode <xml source> <txt destination>");
        }

        static void Main(string[] args)
        {
            if (args.Length != 3 && args.Length != 5)
            {
                Help();
            }
            else
            {
                var src = args[1];
                var dst = args[2];

                if (args[0] == "encode" && args.Length == 5)
                {
                    int cesarShift;
                    bool isDigit = int.TryParse(args[3], out cesarShift);
                    if (!isDigit)
                    {
                        Console.WriteLine("Incorrect Cesar shift");
                        Help();
                        return;
                    }

                    if (args[4] == "-l")
                    {
                        cesarShift *= -1;
                    }
                    else if (args[4] != "-r")
                    {
                        Console.WriteLine("Incorrect Cesar shift direction");
                        Help();
                        return;
                    }

                    try
                    {
                        Console.WriteLine("Reading source text...");
                        string text = File.ReadAllText(src);
                        Console.WriteLine("Done. Building cyphers...");
                        var cesar = ReplaceTabelBuilder.BuilderCesarCypheReplaceTabel(cesarShift);
                        var random = ReplaceTabelBuilder.BuidRandomCypheReplaceTabel(0);
                        Console.WriteLine("Done. Encoding text...");
                        text = Encoder.Encode(text, cesar);
                        text = Encoder.Encode(text, random);
                        Console.WriteLine("Done. Generating message...");
                        Message mes = new Message();

                        mes.CesarShift = cesarShift;
                        mes.Cypher = random;
                        mes.EncodedText = text;
                        Console.WriteLine("Done. Writing message to the file...");
                        mes.Write(dst);
                        Console.WriteLine("Done. End.");
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                        Help();
                        return;
                    }
                    catch (XmlException e)
                    {
                        Console.WriteLine(e.Message);
                        Help();
                        return;
                    }

                }
                else if (args[0] == "decode" && args.Length == 3)
                {
                    try
                    {
                        Console.WriteLine("Reading source message...");
                        Message mes = Message.Read(src);
                        Console.WriteLine("Done. Building cyphers...");
                        ReplaceTabel cesar = ReplaceTabelBuilder.BuilderCesarCypheReplaceTabel(mes.CesarShift);
                        cesar.Invert();
                        mes.Cypher.Invert();
                        Console.WriteLine("Done. Decoding...");
                        string decoded = Encoder.Decode(mes.EncodedText, mes.Cypher);
                        decoded = Encoder.Decode(decoded, cesar);
                        File.WriteAllText(dst, decoded);
                        Console.WriteLine("Done. Source text:");
                        Console.WriteLine(decoded);
                        Console.WriteLine("End.");
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                        Help();
                        return;
                    }
                    catch (XmlException e)
                    {
                        Console.WriteLine(e.Message);
                        Help();
                        return;
                    }
                }
                else
                {
                    Help();
                }
            }
        }
    }
}

using System;
using System.IO;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main()
        {
            string directoryRead = "../Resources/text.txt";
            string directoryWrite = "../Resources/output.txt";

            using (StreamReader reader = new StreamReader(directoryRead))
            {
                using (StreamWriter writer = new StreamWriter(directoryWrite))
                {
                    string line;
                    var counter = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {counter}: {line}");
                        counter++;
                    }
                }
            }
        }
    }
}

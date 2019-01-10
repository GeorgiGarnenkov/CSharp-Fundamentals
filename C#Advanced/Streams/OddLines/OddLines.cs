using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;

namespace OddLines
{
    class OddLines
    {
        static void Main()
        {
            string directory = "../Resources/text.txt";
            using (StreamReader reader = new StreamReader(directory))
            {
                string line;
                var counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}


using System;
using System.IO;

namespace ReadFile
{
    class ReadFile
    {
        static void Main()
        {
            using(var readStream = new StreamReader("ReadFile.cs"))
            {
                using (var writeStream = new StreamWriter("reversed.txt"))
                {
                    string line;
                    while ((line = readStream.ReadLine()) != null)
                    {
                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            writeStream.Write(line[i]);
                        }
                        writeStream.WriteLine();
                    }
                }
                
            }
        }
    }
}

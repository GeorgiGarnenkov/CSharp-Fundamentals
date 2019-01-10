using System;
using System.IO;

namespace CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main()
        {
            string directoryRead = "../Resources/copyMe.png";
            string directoryCopy = "../Resources/copyMeResult.png";

            using (FileStream source = new FileStream(directoryRead, FileMode.Open))
            {
                using (FileStream destination = new FileStream(directoryCopy, FileMode.Create))
                {
                    byte[] buffer = new byte[source.Length];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}

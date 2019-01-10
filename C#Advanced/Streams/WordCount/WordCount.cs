using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class WordCount
    {
        static void Main()
        {
            string directoryRead = "../Resources/words.txt";
            string directoryRead2 = "../Resources/text.txt";
            string directoryWrite = "../Resources/result.txt";

            using (var readStream = new StreamReader(directoryRead))
            {
                var word = readStream.ReadLine();
                List<string> wordList = new List<string>();
                while (word != null)
                {
                    wordList.Add(word);
                    word = readStream.ReadLine();
                }
                var dict = new Dictionary<string, int>();
                for (int i = 0; i < wordList.Count; i++)
                {
                    var wordForCompare = wordList[i].ToLower();
                    var counter = 0;
                    using (var readStream2 = new StreamReader(directoryRead2))
                    {
                        var line = readStream2.ReadLine();
                        while (line != null)
                        {
                            var newline = line.Split(new string[] { " ", "-", ".", ",", "?", "!", "..." },
                                StringSplitOptions.RemoveEmptyEntries).ToArray();

                            for (int j = 0; j < newline.Length; j++)
                            {
                                var wordInLine = newline[j].ToLower();
                                if (wordForCompare.ToLower() == wordInLine)
                                {
                                    counter++;
                                }
                            }
                            line = readStream2.ReadLine();
                        }
                    }
                    dict.Add(wordForCompare, counter);
                }
                using (var writeStream = new StreamWriter(directoryWrite))
                {

                    foreach (var w in dict.OrderByDescending(a => a.Value))
                    {
                        writeStream.WriteLine($"{w.Key} - {w.Value}");
                    }
                }
            }
        }
    }
}

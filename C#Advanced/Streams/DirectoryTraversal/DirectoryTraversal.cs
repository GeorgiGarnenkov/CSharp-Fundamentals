using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();

            var filesDictinary = new Dictionary<string, List<FileInfo>>();

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;

                if (!filesDictinary.ContainsKey(extension))
                {
                    filesDictinary[extension] = new List<FileInfo>();
                }
                filesDictinary[extension].Add(fileInfo);
            }

            filesDictinary = filesDictinary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x=> x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string fullFileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDictinary)
                {
                    string extension = pair.Key;

                    writer.WriteLine(extension);

                    var fileInfos = pair.Value
                        .OrderByDescending(fi => fi.Length);
                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double) fileInfo.Length / 1024;
                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }
    }
}

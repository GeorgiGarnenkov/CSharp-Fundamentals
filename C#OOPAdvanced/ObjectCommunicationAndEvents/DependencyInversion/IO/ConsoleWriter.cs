﻿using DependencyInversion.Interfaces;
using System;

namespace DependencyInversion.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
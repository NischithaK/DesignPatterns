using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace DotNetDesignPatternDemos.SOLID.SRP
{
    // Single responsibility principle
    // Each class should take up single responsibility rather than taking multiple responsibility. When there is a requirement to change, each class to be changed only on single requirement.
    //Change the path of the file before editing
    public class Journal
    {
        private readonly List<String> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(String text)
        {
            entries.Add($"{count++}:{text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistance
    {
        public void SaveToFile(Journal J, string fileName, bool overwrite=false)
        {
            if(overwrite ||File.Exists(fileName))
            {
                File.WriteAllText(fileName, J.ToString());
            }
        }
    }

    class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
         
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);
            string fileName = @"..\..\sample.txt";
            Persistance perSis = new Persistance();
            perSis.SaveToFile(j, fileName, true);
            Process.Start(fileName);
        }
    }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz5
{
    class MyConsole
    {
        static string CommandsPath = "";
        Dictionary<string, string> Links { get; set; }
        Dictionary<string, int> LNKeys { get; set; }
        Dictionary<string, int> Commands { get; set; }
        string Directory { get; set; }
        public MyConsole()
        {
            Directory = "C:/";

            LNKeys = new Dictionary<string, int>();
            LNKeys.Add("-s", 1);
            LNKeys.Add("-f", 2);

            Commands = new Dictionary<string, int>();
            Commands.Add("cat", 1);
            Commands.Add("ln", 2);

            Links = new Dictionary<string, string>();
        }

        void Read()
        {
            var Lines = File.ReadAllLines(CommandsPath);
            foreach (var Line in Lines)
            {
                var elems = Line.Split();
                Links.Add(elems[0], elems[1]);
            }
        }
        void Write()
        {
            string Text = "";
            foreach (var el in Links)
            {
                Text += el.Key + " " + el.Value + "\n";
            }
            //Console.WriteLine(Text);
            File.WriteAllText(CommandsPath, Text);
        }

    }
}



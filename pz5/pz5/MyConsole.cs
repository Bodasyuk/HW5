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
        static string CommandsPath = "C:/Users/Dell/Desktop/HW5/pz5/Text.txt";
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
        public void Print()
        {
            Console.Write(Directory + ">");
        }
        public void LN(string NameForLink, string WhatLinked, string Key = "-s")
        {
            switch (LNKeys[Key])
            {
                case 1:
                    // standart
                    if (Links.ContainsKey(NameForLink))
                    {
                        Console.WriteLine("It name used for another link");
                        return;
                    }
                    else
                    {
                        Links.Add(NameForLink, WhatLinked);
                    }
                    break;
                case 2:
                    // rewrite if link with that name used
                    if (Links.ContainsKey(NameForLink))
                    {
                        Links[NameForLink] = WhatLinked;
                    }
                    else
                    {
                        Links.Add(NameForLink, WhatLinked);
                    }
                    break;
            }
        }
        public void CAT(string Link)
        {
            bool Exist = Links.ContainsKey(Link);
            if (!Exist)
            {
                Console.WriteLine("Cannot find that link");
            }
            else
            {
                while (Links.ContainsKey(Link))
                {
                    Link = Links[Link];
                }
                Console.WriteLine(Link);
            }
        }
        public void Work()
        {
            Read();
            while (true)
            {
                Print();
                string Line = Console.ReadLine();
                switch (Commands[Line.Split()[0]])
                {
                    case 1:
                        CAT(Line.Split()[1]);
                        Write();
                        break;
                    case 2:
                        switch (Line.Split().Length)
                        {
                            case 3:
                                LN(Line.Split()[1], Line.Split()[2]);
                                Write();
                                break;
                            case 4:
                                LN(Line.Split()[2], Line.Split()[3], Line.Split()[1]);
                                Write();
                                break;
                        }
                        break;
                }
            }
        }

    }
}



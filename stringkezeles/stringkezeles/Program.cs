using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace stringkezeles
{
    class Program
    {
        static List<string> ReadFile(string filename)
        {
            List<string> temp = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(filename);
                while(!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    foreach(string intem in line)
                    {
                        temp.Add(intem);
                    }
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Problem with file open.");
            }
            return temp;
        }

        static void WriteList(List<string> t)
        {
            foreach(string intem in t)
            {
                Console.WriteLine(intem);
            }
        }

        static bool Palindrom(string str)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            str = rgx.Replace(str, "");
            str = str.ToLower();
            string ReveseStr="";
            for(int i=str.Length-1;i>=0;i--)
            {
                ReveseStr += str[i];
            }
            return str == ReveseStr && str.Length!=0;
        }

        static void Main(string[] args)
        {
            /// Az eredetileg beolvasott szavak
            List<string> OriginalWords = ReadFile("in.txt");
            Console.WriteLine("Original text from file: ");
            WriteList(OriginalWords);



            //Lista a irasjelek nelkul
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            List<string> JustWords = new List<string>();
            JustWords.Clear();
            for (int i = 0; i < OriginalWords.Count(); i++)
            { 

                string temp= OriginalWords[i];
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                temp = rgx.Replace(temp, "");
                JustWords.Add(temp);
            }
           
            Console.WriteLine("Text withiut glyphs: ");
            WriteList(JustWords);

            /// Az összes szó egyszer előfordulva
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            List<string> DifferentWords = new List<string>();
            DifferentWords.Clear();

            for(int i=0;i< JustWords.Count();i++)
            {
                if(!DifferentWords.Contains(JustWords[i]))
                {
                    DifferentWords.Add(JustWords[i]);
                }
            }

            Console.WriteLine("Unique words: ");
            WriteList(DifferentWords);

            // A szavak megszamlalasa kis es nagybetus szavak egyformanak szamitanak
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Word: quantity");
            foreach (string word1 in DifferentWords)
                {
                    int count = 0;
                    foreach (string word2 in JustWords)
                    {
                        if (word2.ToLower() == word1.ToLower())
                        {
                            count++;
                        }
                    }

                Console.WriteLine(word1 + ": " + count);
                }
            // Palindrom szo
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Palindrom Word.");
            Console.WriteLine("Please give a word or sentence: ");

            string str = Console.ReadLine();
            if (Palindrom(str))
            {
                Console.WriteLine("Palindrom!");
            }
            else Console.WriteLine("Not Palindrom!");
               
           


            Console.ReadKey();
        }
    }
}

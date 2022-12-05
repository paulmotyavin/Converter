using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Converter
{
    public class EditingText
    {
        public static List<string> name;
        public static List<char> chars = new List<char>();
        public static string open;
        public static string[] words;
        public static List<Clothes> parseList= new List<Clothes>();
        public static List<string> jsonXml = new List<string>();
        public static void EditTxt()
        {
            open = Converter.open;
            words = open.Split('\n');

            ConsoleKeyInfo button;
            int pos = 0;
            int pos1 = 0;
            do
            {
                chars = words[pos1].ToString().ToCharArray().ToList();
                button = Console.ReadKey();
                if (button.Key == ConsoleKey.LeftArrow)
                {
                    pos = (pos - 1 == -1) ? pos : pos - 1;
                }
                else if (button.Key == ConsoleKey.RightArrow)
                {
                    pos = (pos + 1 == chars.Count + 1) ? pos : pos + 1;
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    pos1++;
                    chars = words[pos1].ToString().ToCharArray().ToList();
                }
                if (button.Key == ConsoleKey.UpArrow)
                {
                    pos1--;
                    chars = words[pos1].ToString().ToCharArray().ToList();
                }
                else if (button.Key == ConsoleKey.Backspace)
                {
                    chars.RemoveAt(pos - 1);
                    pos--;
                }
                if (button.Key == ConsoleKey.Spacebar)
                {
                    chars.Insert(pos, ' ');
                    pos++;
                }
                else if (Char.IsLetterOrDigit(button.KeyChar))
                {
                    chars.Insert(pos, button.KeyChar);
                    pos++;

                }
                words[pos1] = string.Join("", chars);
                chars = words[pos1].ToString().ToCharArray().ToList();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                                  ");
                Console.SetCursorPosition(0, 0);
                foreach (var item in words)
                    Console.WriteLine(item);
                Console.SetCursorPosition(pos, pos1);                
            } while (button.Key != ConsoleKey.F1);
            ParseForConstructorTxt();
            Converter.Save();
        }
        public static void Json()
        {
            foreach (var i in Converter.file)
            {
                jsonXml.Add(i.Name.ToString());
                jsonXml.Add(i.Size.ToString());
                jsonXml.Add(i.Price.ToString());
            }
            ConsoleKeyInfo button;
            int pos = 0;
            int pos1 = 0;
            do
            {
                chars = jsonXml[pos1].ToString().ToCharArray().ToList();
                button = Console.ReadKey();
                if (button.Key == ConsoleKey.LeftArrow)
                {
                    pos = (pos - 1 == -1) ? pos : pos - 1;
                }
                else if (button.Key == ConsoleKey.RightArrow)
                {
                    pos = (pos + 1 == chars.Count + 1) ? pos : pos + 1;
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    pos1++;
                    chars = jsonXml[pos1].ToString().ToCharArray().ToList();
                }
                if (button.Key == ConsoleKey.UpArrow)
                {
                    pos1--;
                    chars = jsonXml[pos1].ToString().ToCharArray().ToList();
                }
                else if (button.Key == ConsoleKey.Backspace)
                {
                    chars.RemoveAt(pos - 1);
                    pos--;
                }
                if (button.Key == ConsoleKey.Spacebar)
                {
                    chars.Insert(pos, ' ');
                    pos++;
                }
                else if (Char.IsLetterOrDigit(button.KeyChar))
                {
                    chars.Insert(pos, button.KeyChar);
                    pos++;
                }
                jsonXml[pos1] = string.Join("", chars);
                chars = jsonXml[pos1].ToString().ToCharArray().ToList();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                                  ");
                Console.SetCursorPosition(0, 0);
                foreach (var item in jsonXml)
                    Console.WriteLine(item);
                Console.SetCursorPosition(pos, pos1);
            } while (button.Key != ConsoleKey.F1);
            ParseForConstructorXmlJson();
            Converter.Save();
        }
        public static void EditXml()
        {
            foreach (var i in Converter.clothes)
            {
                jsonXml.Add(i.Name.ToString());
                jsonXml.Add(i.Size.ToString());
                jsonXml.Add(i.Price.ToString());
            }
            ConsoleKeyInfo button;
            int pos = 0;
            int pos1 = 0;
            do
            {
                chars = jsonXml[pos1].ToString().ToCharArray().ToList();
                button = Console.ReadKey();
                if (button.Key == ConsoleKey.LeftArrow)
                {
                    pos = (pos - 1 == -1) ? pos : pos - 1;
                }
                else if (button.Key == ConsoleKey.RightArrow)
                {
                    pos = (pos + 1 == chars.Count + 1) ? pos : pos + 1;
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    pos1++;
                    chars = jsonXml[pos1].ToString().ToCharArray().ToList();
                }
                if (button.Key == ConsoleKey.UpArrow)
                {
                    pos1--;
                    chars = jsonXml[pos1].ToString().ToCharArray().ToList();
                }
                else if (button.Key == ConsoleKey.Backspace)
                {
                    chars.RemoveAt(pos - 1);
                    pos--;
                }
                if (button.Key == ConsoleKey.Spacebar)
                {
                    chars.Insert(pos, ' ');
                    pos++;
                }
                else if (Char.IsLetterOrDigit(button.KeyChar))
                {
                    chars.Insert(pos, button.KeyChar);
                    pos++;
                }
                jsonXml[pos1] = string.Join("", chars);
                chars = jsonXml[pos1].ToString().ToCharArray().ToList();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                                  ");
                Console.SetCursorPosition(0, 0);
                foreach (var item in jsonXml)
                    Console.WriteLine(item);
                Console.SetCursorPosition(pos, pos1);
            } while (button.Key != ConsoleKey.F1);
            ParseForConstructorXmlJson();
            Converter.Save();
        }
        
        public static void ParseForConstructorTxt()
        {
            List<int> list1 = new List<int>();
            List<string> list2 = new List<string>();
            foreach (var word in words)
            {
                int n;
                bool Check = int.TryParse(word, out n);
                if (Check == true) list1.Add(Convert.ToInt32(word));
                else list2.Add(word.TrimEnd());
            }
            Converter.name1 = list2[0];
            Converter.name2 = list2[1];
            Converter.name3 = list2[2];
            Converter.size1 = list1[0];
            Converter.size2 = list1[2];
            Converter.size3 = list1[4];
            Converter.price1 = list1[1];
            Converter.price2 = list1[3];
            Converter.price3 = list1[5];

            Clothes firstvariant = new(Converter.name1, Converter.size1, Converter.price1);
            Clothes secondvariant = new(Converter.name2, Converter.size2, Converter.price2);
            Clothes thirdvariant = new(Converter.name3, Converter.size3, Converter.price3);

            Converter.list.Add(firstvariant);
            Converter.list.Add(secondvariant);
            Converter.list.Add(thirdvariant);

            foreach (Clothes item in Converter.list)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Size);
                Console.WriteLine(item.Price);
            }
        }
        public static void ParseForConstructorXmlJson()
        {
            List<int> list1 = new List<int>();
            List<string> list2 = new List<string>();
            foreach (var cloth in jsonXml)
            {
                int n;
                bool Check = int.TryParse(cloth, out n);
                if (Check == true) list1.Add(Convert.ToInt32(cloth));
                else list2.Add(cloth.TrimEnd());
            }

            Converter.name1 = list2[0];
            Converter.name2 = list2[1];
            Converter.name3 = list2[2];
            Converter.size1 = list1[0];
            Converter.size2 = list1[2];
            Converter.size3 = list1[4];
            Converter.price1 = list1[1];
            Converter.price2 = list1[3];
            Converter.price3 = list1[5];

            Clothes firstvariant = new(Converter.name1, Converter.size1, Converter.price1);
            Clothes secondvariant = new(Converter.name2, Converter.size2, Converter.price2);
            Clothes thirdvariant = new(Converter.name3, Converter.size3, Converter.price3);

            Converter.list.Add(firstvariant);
            Converter.list.Add(secondvariant);
            Converter.list.Add(thirdvariant);
        }
    }
}
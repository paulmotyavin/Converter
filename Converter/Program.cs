/*using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Converter
{
    public class Program
    {

        public static string name1;
        public static string name2;
        public static string name3;
        public static int size1;
        public static int size2;
        public static int size3;
        public static int price1;
        public static int price2;
        public static int price3;
        static public string open;
        static public List<Clothes> list = new List<Clothes>();

        static public void Main()
        {
            Console.WriteLine("Введите путь до файла (с названием), который вы хотите открыть");
            Console.WriteLine("--------------------------------------------------------------");
            string first_path = Console.ReadLine();
            FileInfo path = new FileInfo(first_path);
            if (File.Exists(first_path))
            {
                Console.Clear();
                Console.WriteLine("Нажмите F1, чтобы сохранить файл в одном из трех расширений(txt, json, xml). Для выхода нажмите Escape");
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                if (path.Extension == ".txt")
                {
                    open = File.ReadAllText(first_path);
                    *//*                    EditingClass.Edit();*//*
                    string[] words = open.Split("\n");
                    List<int> list1 = new List<int>();
                    List<string> list2 = new List<string>();
                    foreach (var word in words)
                    {
                        int n;
                        bool Check = int.TryParse(word, out n);
                        if (Check == true) list1.Add(Convert.ToInt32(word));
                        else list2.Add(word.TrimEnd());
                    }
                    name1 = list2[0];
                    name2 = list2[1];
                    name3 = list2[2];
                    size1 = list1[0];
                    size2 = list1[2];
                    size3 = list1[4];
                    price1 = list1[1];
                    price2 = list1[3];
                    price3 = list1[5];

                    Clothes firstvariant = new(name1, size1, price1);
                    Clothes secondvariant = new(name2, size2, price2);
                    Clothes thirdvariant = new(name3, size3, price3);

                    list.Add(firstvariant);
                    list.Add(secondvariant);
                    list.Add(thirdvariant);

                    foreach (Clothes item in list)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Size);
                        Console.WriteLine(item.Price);
                    }
                }
                if (path.Extension == ".json")
                {
                    open = File.ReadAllText(first_path);
                    List<Clothes> file = JsonConvert.DeserializeObject<List<Clothes>>(open);
                    foreach (var item in file)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Size);
                        Console.WriteLine(item.Price);
                    }
                    list = file;
                }
                if (path.Extension == ".xml")
                {
                    List<Clothes> clothes;

                    XmlSerializer xml = new XmlSerializer(typeof(List<Clothes>));
                    using (FileStream fs = new FileStream(first_path, FileMode.Open))
                    {
                        clothes = (List<Clothes>)xml.Deserialize(fs);
                    }
                    foreach (var item in clothes)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Size);
                        Console.WriteLine(item.Price);
                    }
                    list = clothes;
                }
            }
            else
            {
                Console.WriteLine("Данного пути не существует, попробуйте снова");
                Thread.Sleep(2500);
                Console.Clear();
                Main();
            }

            ConsoleKeyInfo button = Console.ReadKey();
            if (button.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Console.WriteLine("Введите путь до файла (с названием), куда вы хотите сохранить текст");
                Console.WriteLine("-------------------------------------------------------------------");
                string second_path = Console.ReadLine();
                FileInfo path2 = new FileInfo(second_path);
                if (path2.Extension == ".txt")
                {
                    if (path.Extension == ".txt")
                    {
                        File.WriteAllText(second_path, open);
                    }
                    else
                    {
                        foreach (var item in list)
                        {
                            File.AppendAllText(second_path, item.Name + "\n");
                            File.AppendAllText(second_path, item.Price.ToString() + "\n");
                            File.AppendAllText(second_path, item.Size.ToString() + "\n");
                        }

                    }
                }
                if (path2.Extension == ".json")
                {
                    string json = JsonConvert.SerializeObject(list);
                    File.WriteAllText(second_path, json);

                }
                if (path2.Extension == ".xml")
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Clothes>));
                    using (FileStream fs = new FileStream(second_path, FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, list);
                    }

                }
            }
        }
        static private void Read()
        {

        }
        static private void Save()
        {

        }
    }
}*/




namespace Converter
{
    public class Program
    {
        public static void Main()
        {
            Converter.MainFunction();
        }
    }
}

/*

namespace Converter
{
    public class EditingClass
    {
        public static void Main()
        {
            string txt = "Текст\n вот такой";

            Clothes firstvariant = new("футболка", 44, 599);
            Clothes secondvariant = new("шорты", 15, 999);
            Clothes thirdvariant = new("брюки", 41, 1399);
            List<Clothes> list = new List<Clothes>();
            list.Add(firstvariant);
            list.Add(secondvariant);
            list.Add(thirdvariant);
            List<char> chars = list.ToString().ToCharArray().ToList();
            foreach(var item in list) 
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Size);
                Console.WriteLine(item.Price);
            }
                

            ConsoleKeyInfo button;
            int pos = 0;
            int pos1 = 0;
            do
            {
                button = Console.ReadKey();
                if (button.Key == ConsoleKey.LeftArrow)
                {
                    pos = (pos - 1 == -1) ? pos : pos - 1;
                }
                else if (button.Key == ConsoleKey.RightArrow)
                {
                    pos = (pos + 1 == chars.Count + 1) ? pos : pos + 1;
                }
                if (button.Key == ConsoleKey.UpArrow)
                {
                    pos1 = (pos1 - 1 == -1) ? pos1 : pos1 - 1;
                }
                else if (button.Key == ConsoleKey.DownArrow)
                {
                    pos1 = (pos1 + 1 == chars.Count + 1) ? pos1 : pos1 + 1;
                }
                else if (button.Key == ConsoleKey.Backspace)
                {
                    chars.RemoveAt(pos);
                }
                else if (Char.IsLetterOrDigit(button.KeyChar))
                {
                    chars.Insert(pos, button.KeyChar);
                }


                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                                  ");
                Console.SetCursorPosition(0, 0);
                foreach (var item in chars)
                    Console.Write(item);

                Console.SetCursorPosition(pos, 0);
            } while (true);
        }
    }
}*/
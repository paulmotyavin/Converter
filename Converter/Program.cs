/*using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Converter
{
    public class Program
    {
        static public string open;

        private static Clothes firstvariant = new("Футболка", 48, 699);
        private static Clothes secondvariant = new("Джинсы", 30, 4500);
        private static Clothes thirdvariant = new("Кроссовки", 42, 5200);
        private static Clothes[] file = new Clothes[] { firstvariant, secondvariant, thirdvariant };

        static void Main()
        {
            List <Clothes> list = new List <Clothes>();
            list.Add(firstvariant);
            list.Add (secondvariant);
            list.Add(thirdvariant);
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
                    string[] words = open.Split("\n");
                    foreach (string word in words) Console.WriteLine(word);
                }
                if (path.Extension == ".json")
                {
                    open = File.ReadAllText(first_path);
                    string[] words = open.Split("\n");
                    foreach (string word in words) Console.WriteLine(word);

                    string json = File.ReadAllText("C:\\Users\\paulscriptum\\Desktop\\json.json");
                    List<Clothes> file = JsonConvert.DeserializeObject<List<Clothes>>(json);
                    *//*foreach (string cloth in words)
                    {
                        Console.WriteLine(cloth.Name);
                        Console.WriteLine(cloth.Size);
                        Console.WriteLine(cloth.Price);
                    }*//*
                }
                if (path.Extension == ".xml")
                {
                    Clothes clothes;
                    XmlSerializer xml = new XmlSerializer(typeof(Clothes));
                    using (FileStream fs = new FileStream(first_path, FileMode.Open))
                    {
                        clothes = (Clothes)xml.Deserialize(fs);
                    }
                }
            }
            else
            {
                Console.WriteLine("Данного пути не существует, попробуйте снова");
                first_path = Console.ReadLine();
            }
            *//*Console.Clear();
            Console.WriteLine("Нажмите F1, чтобы сохранить файл в одном из трех расширений(txt, json, xml). Для выхода нажмите Escape");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");*/
/*open = File.ReadAllText(first_path);
Console.WriteLine(open);
ConsoleKeyInfo button = Console.ReadKey();
if (button.Key == ConsoleKey.F1)
{
    Console.WriteLine("Введите путь до файла (с названием), куда вы хотите сохранить текст");
    Console.WriteLine("-------------------------------------------------------------------");
    string second_path = Console.ReadLine();
    if (File.Exists(first_path))
    {
        open = File.ReadAllText(first_path);

    }
    else
    {

    }
}
}*//*
}
}
}
*//*    C:\Users\paulscriptum\Desktop\Шаблон.txt
*/


/*using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArea
{
    public class Delo
    {
        public string Name { get; set; }
        public string Podpis { get; set; }
        public int Number { get; set; }
    }
    public static List<Delo> ReadFile(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<Delo>>(json);
    }
    public static void Print(List<Delo> elements)
    {
        foreach (var element in elements)
        {
            Console.WriteLine($"{element.Name}");
        }
    }
}
*/
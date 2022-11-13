using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace Converter
{
    internal class Program
    {
        static public string open;
        static void Main()
        {
            List<Clothes> file = new();
            Clothes firstvariant = new("Футболка", 48, 699);
            Clothes secondvariant = new("Джинсы", 30, 4500);
            Clothes thirdvariant = new("Кроссовки", 42, 5200);
            file.Add(firstvariant);
            file.Add(secondvariant);
            file.Add(thirdvariant);
            Console.WriteLine("Введите путь до файла (с названием), который вы хотите открыть");
            Console.WriteLine("--------------------------------------------------------------");
            string first_path = Console.ReadLine();
            FileInfo path = new FileInfo(first_path);
            string txt = JsonConvert.DeserializeObject(file);
                if (File.Exists(first_path))
                {
                    open = File.ReadAllText(first_path);
                    
                }
                else
                {
                    Console.WriteLine("Данного пути не существует, попробуйте снова");
                    first_path = Console.ReadLine();
                }
            Console.Clear();
            Console.WriteLine("Нажмите F1, чтобы сохранить файл в одном из трех расширений(txt, json, xml). Для выхода нажмите Escape");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            open = File.ReadAllText(first_path);
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
        }
    }
}




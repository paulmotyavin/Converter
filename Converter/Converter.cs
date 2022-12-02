using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Converter
{
    public class Converter
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
        static private FileInfo path;
        static public string first_path;

        static public void MainFunction()
        {
            Console.WriteLine("Введите путь до файла (с названием), который вы хотите открыть");
            Console.WriteLine("--------------------------------------------------------------");
            first_path = Console.ReadLine();
            path = new FileInfo(first_path);

            if (File.Exists(first_path))
            {
                Console.Clear();
                Console.WriteLine("Нажмите F1, чтобы сохранить файл в одном из трех расширений(txt, json, xml). Для выхода нажмите Escape");
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                if (path.Extension == ".txt")
                {
                    Read();
                }
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.Escape) Process.GetCurrentProcess().Kill(); ;
                if (button.Key == ConsoleKey.F1)
                {
                    Save();
                }
            }
            else
            {
                Console.WriteLine("Данного пути не существует, попробуйте снова");
                Thread.Sleep(2500);
                Console.Clear();
                MainFunction();
            }
        }
        private static void Read()
        {
            Console.Clear();
            Console.WriteLine("Нажмите F1, чтобы сохранить файл в одном из трех расширений(txt, json, xml). Для выхода нажмите Escape");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            if (path.Extension == ".txt")
            {
                open = File.ReadAllText(first_path);
                EditingText.Edit();
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
        private static void Save()
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
            Console.Clear();
            Console.WriteLine("Файл был успешно конвертирован.");
        }
    }
}
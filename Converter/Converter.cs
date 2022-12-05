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
        static public FileInfo path;
        static public FileInfo path2;
        static public string first_path;
        static public string second_path;
        static public List<Clothes> clothes;
        static public List<Clothes> file;
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
                Read();
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.Escape) Process.GetCurrentProcess().Kill();
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
            ReadTxt();
            ReadJson();
            ReadXml();
        }
        public static void Save()
        {
            Console.Clear();
            Console.WriteLine("Введите путь до файла (с названием), куда вы хотите сохранить текст");
            Console.WriteLine("-------------------------------------------------------------------");
            second_path = Console.ReadLine();
            path2 = new FileInfo(second_path);
            SaveTxt();
            SaveJson();
            SaveXml();
            
            
            Console.Clear();
            Console.WriteLine("Файл был успешно конвертирован.");
        }
        private static void ReadTxt()
        {
            if (path.Extension == ".txt")
            {
                open = File.ReadAllText(first_path);
                EditingText.EditTxt();
            }
        }
        private static void ReadJson() 
        {
            if (path.Extension == ".json")
            {
                open = File.ReadAllText(first_path);
                file = JsonConvert.DeserializeObject<List<Clothes>>(open);
                EditingText.Json();
            }
        }
        private static void ReadXml()
        {
            if (path.Extension == ".xml")
            {

                XmlSerializer xml = new XmlSerializer(typeof(List<Clothes>));
                using (FileStream fs = new FileStream(first_path, FileMode.Open))
                {
                    clothes = (List<Clothes>)xml.Deserialize(fs);
                }
                EditingText.EditXml();
            }
        }
        private static void SaveTxt()
        {
            if (path2.Extension == ".txt")
            {
                SaveTxtToTxt();
                SaveTxtToJsonXml();
                
            }
        }
        private static void SaveTxtToTxt()
        {
            if (path.Extension == ".txt")
            {
                File.WriteAllText(second_path, open);
            }
        }
        private static void SaveTxtToJsonXml()
        {
            if (path.Extension == ".json" || path.Extension == ".xml")
            {
                foreach (var item in list)
                {
                    File.AppendAllText(second_path, item.Name + "\n");
                    File.AppendAllText(second_path, item.Price.ToString() + "\n");
                    File.AppendAllText(second_path, item.Size.ToString() + "\n");
                }
            }
        }
        private static void SaveJson()
        {
            if (path2.Extension == ".json")
            {
                string json = JsonConvert.SerializeObject(list);
                File.WriteAllText(second_path, json);
            }
        }
        private static void SaveXml()
        {
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
}
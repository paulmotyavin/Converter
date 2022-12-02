using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class EditingText
    {
        public static void Edit()
        {

            List<char> chars = Converter.open.ToCharArray().ToList();
            Console.WriteLine(Converter.open);

            ConsoleKeyInfo button;
            int pos = 0;
            int pos1 = 2;
            Console.SetCursorPosition(0, 2);
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
                if (button.Key == ConsoleKey.LeftArrow)
                {
                    pos1 = (pos1 - 1 == -1) ? pos1 : pos1 - 1;
                }
                if (button.Key == ConsoleKey.LeftArrow)
                {
                    pos1 = (pos1 - 1 == -1) ? pos1 : pos1 + 1;
                }
                else if (button.Key == ConsoleKey.Backspace)
                {
                    chars.RemoveAt(pos - 1);
                    pos--;
                }
                else if (Char.IsLetterOrDigit(button.KeyChar) || Char.IsWhiteSpace(button.KeyChar))
                {
                    chars.Insert(pos, button.KeyChar);
                    pos++;
                }
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                                  ");
                Console.SetCursorPosition(0, 2);
                foreach (var item in chars)
                {
                    Console.Write(item);

                }

                Console.SetCursorPosition(pos, 2);
            } while (button.Key != ConsoleKey.F1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        static int SleepTime = 100;
        static int level = 1;

        public void StatusBar()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;

            for (int i = 0; i < Console.WindowHeight - 2; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.WindowWidth - 2, i);
                Console.WriteLine("|");
            }

            for (int i = 0; i < Console.WindowWidth - 1; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, Console.WindowHeight - 2);
                Console.WriteLine("-");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Console.WindowWidth - 1, 0);
            Console.Write("L");
            Console.SetCursorPosition(Console.WindowWidth - 1, 1);
            Console.Write("E");
            Console.SetCursorPosition(Console.WindowWidth - 1, 2);
            Console.Write("V");
            Console.SetCursorPosition(Console.WindowWidth - 1, 3);
            Console.Write("E");
            Console.SetCursorPosition(Console.WindowWidth - 1, 4);
            Console.Write("L");

        }

        public void Playgame()
        {
            
        }
    }
}

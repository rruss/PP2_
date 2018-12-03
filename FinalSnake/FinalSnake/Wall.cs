using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSnake
{
    [Serializable]
    class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Wall()
        {
            color = ConsoleColor.DarkMagenta;
            sign = '#';
            body = new List<Point>();
            LoadLevel(++Game.level);
        }

        public void LoadLevel(int level)
        {
            string filePath = string.Format(@"C:\Users\Disketa.kz\source\repos\FinalSnake\FinalSnake\Levels\level1.txt", level);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            int i = 0;
            int row = 0;
            while (i < 20)
            {
                line = sr.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                i++;
                row++;
            }

            Draw();
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}

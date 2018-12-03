using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeThread
{
    public class Wall : GameObject
    {
        public Wall(Point point, ConsoleColor color, char sign) : base(point, color, sign)
        {

        }

        public void LoadLevel(Gamelevel level)
        {
            string fname = "";

            switch (level)
            {
                case Gamelevel.First:
                    fname = @"C:\Users\Disketa.kz\source\repos\SnakeThread\SnakeThread\Levels\Level1.txt";
                    break;
                case Gamelevel.Second:
                    fname = @"Levels\Level2.txt";
                    break;
                case Gamelevel.Final:
                    fname = @"Levels\Level3.txt";
                    break;
            }

            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int j = 0;

            while((line = sr.ReadLine()) != null)
            {
                for(int i = 0; i < line.Length; ++i)
                {
                    if(line[i] == '#')
                    {
                        this.body.Add(new Point { X = i, Y = j });
                    }
                    j++;
                }
            }

            sr.Close();
            fs.Close();
        }
    }
}

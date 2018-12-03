using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeThread
{
    public class Worm : GameObject
    {
        public Worm(Point point, ConsoleColor color, char sign) : base(point, color, sign)
        {

        }

        public void Move(int dx, int dy)
        {
            Point NewHeadPos = new Point { X = body[0].X + dx, Y = body[0].Y };

            for(int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0] = NewHeadPos;

            body[0].X += dx;
            body[0].Y += dy;
            if (body[0].X < 0)
                body[0].X = Console.WindowWidth - 1;
            if (body[0].X >= Console.WindowWidth)
                body[0].X = 0;
            if (body[0].Y < 0)
                body[0].Y = Console.WindowHeight - 1;
            if (body[0].Y >= Console.WindowHeight)
                body[0].Y = 0;
        }
    }
}

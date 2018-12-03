using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Obstacles:Position
    {
        public Obstacles(int x, int y) : base(x, y)
        {

        }
        static void Wall()
        {

            //List<Position> obstacles = new List<Position>()
            {
               
            };


            /*foreach (Position obstacle in obstacles)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(
                    obstacle.col,
                    obstacle.row);
                Console.Write("#");
            }*/
        }
    }
}

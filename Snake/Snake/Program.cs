using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    /*public struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int level = 1;
            int right = 0;
            int left = 1;
            int down = 2;
            int up = 3;


            Console.CursorVisible = false;

            for(int i = 0; i < Console.WindowHeight - 2; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.WindowWidth - 2, i);
                Console.WriteLine("|");
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



            for (int i = 0; i < Console.WindowWidth - 1; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, Console.WindowHeight - 2);
                Console.WriteLine("-");
            }

            Position[] directions = new Position[]
            {
                new Position(0, 1), 
                new Position(0, -1), 
                new Position(1, 0), 
                new Position(-1, 0),
            };
            double sleepTime = 100;
            int direction = right;
            Random randomNumbersGenerator = new Random();
            Console.BufferHeight = Console.WindowHeight;

            List<Position> obstacles =
                new List<Position>()
            {
                new Position(12, 12),
                new Position(14, 20),
                new Position(7, 7),
                new Position(19, 19),
                new Position(6, 9),
            };
            foreach (Position obstacle in obstacles)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(
                    obstacle.col,
                    obstacle.row);
                Console.Write("#");
            }

            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = 0; i <= 2; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            Position food;
            do
            {
                food = new Position(
                    randomNumbersGenerator.Next(0,
                        Console.WindowHeight - 2),
                    randomNumbersGenerator.Next(0,
                        Console.WindowWidth - 2));
            }
            while (snakeElements.Contains(food) ||
                   obstacles.Contains(food));
            Console.SetCursorPosition(food.col, food.row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+");

            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(
                    position.col,
                    position.row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
            }

            FileStream fs = new FileStream(@"C:\Users\Disketa.kz\source\repos\Snake\Snake\Save\Save.xml", 
                FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Position));

            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressed = Console.ReadKey();
                    if (pressed.Key == ConsoleKey.Enter)
                    {
                       xs.Serialize(fs, snakeElements);
                    }
                    if (pressed.Key == ConsoleKey.Escape)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(0, (Console.WindowHeight / 2) - 1);
                        Console.WriteLine("If you want to save press ENTER...");
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if(keyInfo.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        else if(keyInfo.Key == ConsoleKey.Enter)
                        {
                            //xs.Serialize(fs, snakeElements);
                        }
                    }
                    if (pressed.Key == ConsoleKey.LeftArrow)
                    {
                        if (direction != right) direction = left;
                    }
                    if (pressed.Key == ConsoleKey.RightArrow)
                    {
                        if (direction != left) direction = right;
                    }
                    if (pressed.Key == ConsoleKey.UpArrow)
                    {
                        if (direction != down) direction = up;
                    }
                    if (pressed.Key == ConsoleKey.DownArrow)
                    {
                        if (direction != up) direction = down;
                    }
                }

                Position snakeHead = snakeElements.Last();
                Position nextDirection = directions[direction];

                Position snakeNewHead = new Position(
                    snakeHead.row + nextDirection.row,
                    snakeHead.col + nextDirection.col);

                if (snakeNewHead.col < 0)
                    snakeNewHead.col = Console.WindowWidth - 3;
                if (snakeNewHead.row < 0)
                    snakeNewHead.row = Console.WindowHeight - 3;
                if (snakeNewHead.row >= Console.WindowHeight - 2)
                    snakeNewHead.row = 0;
                if (snakeNewHead.col >= Console.WindowWidth - 2)
                    snakeNewHead.col = 0;

                int userPoints = (snakeElements.Count - 3) * 5;

                if (snakeElements.Contains(snakeNewHead)
                    || obstacles.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(0, (Console.WindowHeight / 2) - 1);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Game over!");
                    
                    userPoints = Math.Max(userPoints, 0);
                    Console.WriteLine("Your points are: {0}",
                        userPoints);
                    Console.ReadLine();
                    return;
                }

                Console.SetCursorPosition(
                    snakeHead.col,
                    snakeHead.row);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");

                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(
                    snakeNewHead.col,
                    snakeNewHead.row);
                Console.ForegroundColor = ConsoleColor.Gray;
                if (direction == right) Console.Write(">");
                if (direction == left) Console.Write("<");
                if (direction == up) Console.Write("^");
                if (direction == down) Console.Write("v");


                if (snakeNewHead.col == food.col &&
                    snakeNewHead.row == food.row)
                {
                    do
                    {
                        food = new Position(
                            randomNumbersGenerator.Next(0,
                                Console.WindowHeight - 2),
                            randomNumbersGenerator.Next(0,
                                Console.WindowWidth - 2));
                    }
                    while (snakeElements.Contains(food) ||
                        obstacles.Contains(food));
                    Console.SetCursorPosition(
                        food.col,
                        food.row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+");
                    sleepTime--;

                    Position obstacle = new Position();
                    do
                    {
                        obstacle = new Position(
                            randomNumbersGenerator.Next(0,
                                Console.WindowHeight - 2),
                            randomNumbersGenerator.Next(0,
                                Console.WindowWidth - 2));  
                    }
                    while (snakeElements.Contains(obstacle) ||
                        obstacles.Contains(obstacle) ||
                        (food.row != obstacle.row &&
                        food.col != obstacle.row));
                    obstacles.Add(obstacle);
                    Console.SetCursorPosition(
                        obstacle.col,
                        obstacle.row);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("#");
                }
                else
                {
                    Position last = snakeElements.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.Write(" ");
                }

                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("+");

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
                level = userPoints / 25 + 1;
                
                Console.SetCursorPosition(Console.WindowWidth - 1, 6);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(level);

                if(userPoints == 495)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("This game is too easy for you. Try to play another game.");
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write(userPoints);
            }
        }
    }*/
}

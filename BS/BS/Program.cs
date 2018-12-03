using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
    public abstract class GameObject
    {
        public List<Point> body { get; }
        public char sign { get; }
        public ConsoleColor color { get; }

        public GameObject(Point point, ConsoleColor color, char sign)
        {
            this.body = new List<Point>();
            if (point != null)
            {
                this.body.Add(point);
            }
            this.color = color;
            this.sign = sign;
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                int i = 0;
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
                ++i;
            }
        }
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            Point b = obj as Point;
            if (b.X == this.X && b.Y == this.Y) return true;
            return false;
        }
    }
    enum GameLevel
    {
        First,
        Second,
        Bonus
    }

    class Game
    {
        public static int boardW = 35;
        public static int boardH = 35;

        bool[,] field = new bool[10, 10];

        Worm worm;
        Food food;
        Wall wall;
        public bool isAlive;

        GameLevel gameLevel;

        List<GameObject> g_objects = new List<GameObject>();

        public void SetupBoard()
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;
        }

        public Game()
        {
            Random x1 = new Random();
            int x2 = x1.Next(1, 35);
            Random y1 = new Random();
            int y2 = y1.Next(1, 35);

            isAlive = true;
            gameLevel = GameLevel.First;

            worm = new Worm(new Point { X = 10, Y = 10 },
                            ConsoleColor.Green, '@');
            food = new Food(new Point { X = x2, Y = y2 },
                           ConsoleColor.Blue, '+');
            wall = new Wall(null, ConsoleColor.White, '#');

            wall.LoadLevel(GameLevel.First);

            g_objects.Add(worm);
            g_objects.Add(food);
            g_objects.Add(wall);
        }
        
        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in g_objects)
            {
                g.Draw();
            }
        }

        public void Exit()
        {

        }

        public void Start()
        {

        }
        int a = 0;

        public void Process(ConsoleKeyInfo pressedButton)
        {
            
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    if (a != 2)
                    {
                        worm.Move(0, -1);
                        a = 1;
                        break;
                    }
                    else
                    {
                        break;
                    }
                    
                     
                case ConsoleKey.DownArrow:
                    if (a != 1)
                    {
                        worm.Move(0, 1);
                        a = 2;
                        break;
                    }
                    else
                    {
                        break;
                    } 
                case ConsoleKey.LeftArrow:
                    if (a != 4)
                    {
                        worm.Move(-1, 0);
                        a = 3;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case ConsoleKey.RightArrow:
                    if (a != 3)
                    {
                        worm.Move(1, 0);
                        a = 4;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case ConsoleKey.Escape:
                    break;
            }

            if (worm.body[0].Equals(food.body[0]))
            {
                int b = 0;
                Random x1 = new Random();
                int x2 = x1.Next(1, 34);
                Random y1 = new Random();
                int y2 = y1.Next(1, 34);
                worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                food.body.Clear();
                food.body[0].X = x2;
                food.body[0].Y = y2;
                Console.SetCursorPosition(x2, y2);
                food.Draw();
            }
            else
            {
                for (int i = 0; i < wall.body.Count; i++)
                {
                    if (worm.body[0].Equals(wall.body[i]))
                    {
                        Console.Clear();
                        Console.SetCursorPosition(12, 16);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("GAME OVER!!!");
                        isAlive = false;
                        Console.ReadKey();
                        break;
                        
                    }
                }
            }
        }
    }
    class Wall : GameObject
    {
        public Wall(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {

        }

        public void LoadLevel(GameLevel level)
        {
            string fname = "";

            switch (level)
            {
                case GameLevel.First:
                    fname = @"C:\Users\Disketa.kz\source\repos\BS\BS\Levels\Level1.txt";
                    break;
                case GameLevel.Second:
                    break;
                case GameLevel.Bonus:
                    break;
                default:
                    break;
            }

            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int y = 0;

            while ((line = sr.ReadLine()) != null)
            {
                for (int x = 0; x < line.Length; ++x)
                {
                    if (line[x] == '#')
                    {
                        this.body.Add(new Point { X = x, Y = y });
                    }
                }
                y++;
            }

            sr.Close();
            fs.Close();
        }
    }
    public class Worm : GameObject
    {
        public Worm(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {

        }
        public void Move(int dx, int dy)
        {
            Point newHeadPos = new Point { X = body[0].X + dx, Y = body[0].Y + dy };

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
           
                if (body[0].X < 1)
                {
                    body[0].X = Console.WindowWidth - 1;
                }
                if (body[0].X > Console.WindowWidth - 1)
                {
                    body[0].X = 1;
                }
                if (body[0].Y < 1)
                {
                    body[0].Y = Console.WindowHeight - 1;
                }
                if (body[0].Y > Console.WindowHeight - 1)
                {
                    body[0].Y = 1;
                }

            body[0] = newHeadPos;
            
        }
    }
    public class Food : GameObject
    {
        public Food(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.SetupBoard();

            while (game.isAlive)
            {
                game.Draw();
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                game.Process(pressedButton);
            }
        }
    }
}
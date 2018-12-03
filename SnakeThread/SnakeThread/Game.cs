using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeThread
{
    public enum GameMode
    {
        Menu,
        NewGame,
        LoadGame,
        SaveGame,
        Quit
    }
    public enum Gamelevel
    {
        First,
        Second,
        Final
    }
    class Game
    {
        public static int BoardW = 30;
        public static int BoardH = 30;

        bool[,] field = new bool[10, 10];

        static Worm worm;
        static Food food;
        static Wall wall;
        static Gamelevel level;
        static GameMode mode;
        static int right = 1;
        static int left = 2;
        static int up = 3;
        static int down = 4;
        static int direction = right;
        static int speed = 150;

        Random number = new Random();

        static public bool isAlive = true;

        public void SetupBoard()
        {
            Console.SetWindowSize(Game.BoardW, Game.BoardH);
            Console.SetBufferSize(Game.BoardW, Game.BoardH);
            Console.CursorVisible = false;
        }


        public void PlayGame()
        {

            level = Gamelevel.First;

            worm = new Worm(new Point { X = 10, Y = 10 }, ConsoleColor.Gray, '*');

            food = new Food(new Point { X = 10, Y = 20 }, ConsoleColor.Green, '+');

            wall = new Wall(null, ConsoleColor.DarkMagenta, '#');

            food.Draw();
            wall.LoadLevel(Gamelevel.First);
            wall.Draw();

            while (isAlive)
            {
                if (direction == right)
                    worm.Move(1, 0);
                if (direction == left)
                    worm.Move(-1, 0);
                if (direction == up)
                    worm.Move(0, -1);
                if (direction == down)
                    worm.Move(0, 1);
                if (worm.body.Count == 15)
                {
                    level = Gamelevel.Second;
                    wall.LoadLevel(Gamelevel.Second);
                }
                if (worm.body.Count == 30)
                {
                    level = Gamelevel.Final;
                    wall.LoadLevel(Gamelevel.Final);
                }

                Console.Clear();
                worm.Draw();
                if (worm.body.Count % 5 == 0)
                {
                    speed = Math.Max(speed - 10, 1);
                }
                Thread.Sleep(speed);
            }

            Thread thread = new Thread(PlayGame);
            thread.Start();

            while (isAlive)
            {
                ConsoleKeyInfo pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.UpArrow)
                {
                    if(direction != down) direction = up;
                }
                if (pressed.Key == ConsoleKey.DownArrow)
                {
                    if (direction != up) direction = down;
                }
                if (pressed.Key == ConsoleKey.RightArrow)
                {
                    if (direction != left) direction = right;
                }
                if (pressed.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != right) direction = left;
                }
                if (pressed.Key == ConsoleKey.Escape)
                {
                    mode = GameMode.Menu;
                }
            }
            if (worm.body[0].Equals(food.body[0]))
            {
                worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                do
                {
                    food.body[0] = new Point { X = number.Next(0, BoardW - 2), Y = number.Next(0, BoardH - 2) };
                }
                while (worm.body.Contains(food.body[0]) || wall.body.Contains(food.body[0]));
            }

        }

        public void Quit()
        {
            isAlive = false;
        }

        public void Menu()
        {
            int cursor = 0;
            string[] menu = { "New Game", "Load Game", "Save Game", "Quit" };

            while (true)
            {

                for (int i = 0; i <= 3; i++)
                {
                    Console.SetCursorPosition((BoardW / 2)- 10, 10 + 2*i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (i == cursor)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(menu[i]);
                }
                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        cursor--;
                        if (cursor < 0)
                        {
                            cursor = 3;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        cursor++;
                        if (cursor > 3)
                        {
                            cursor = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if(cursor == 0)
                        {
                            mode = GameMode.NewGame;
                        }
                        if (cursor == 1)
                        {
                            mode = GameMode.LoadGame;
                        }
                        if (cursor == 2)
                        {
                            mode = GameMode.SaveGame;
                        }
                        if (cursor == 3)
                        {
                            mode = GameMode.Quit;
                        }
                        break;
                }

                if (button.Key == ConsoleKey.Enter)
                {
                    PlayGame();
                }
            }

        }

    }
}

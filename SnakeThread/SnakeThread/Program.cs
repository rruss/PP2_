using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeThread
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMode mode = GameMode.Menu;
            Game game = new Game();
            game.SetupBoard();
            game.Menu();
            if(mode == GameMode.NewGame)
            {
                game.PlayGame();
            }
            if (mode == GameMode.Quit)
            {
                game.Quit();
            }
            if (mode == GameMode.LoadGame)
            {
                
            }
        }
    }
}

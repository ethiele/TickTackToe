using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TickTackToe
{
    class Program
    {


        static void Main(string[] args)
        {

            Game g = new Game();
            Console.Write(g.ShowGameState());
            Console.ReadLine();
            AI ai1 = new AI();
            AI ai2 = new AI();
            ai1.Init("X");
            ai2.Init("O");

            while (g.StateOfGame == GameState.Running)
            {
                ai1.MakeMove(new GameControl(g));
                Console.Write(g.ShowGameState());
                Console.ReadLine();
                if (g.StateOfGame != GameState.Running) break;
                ai2.MakeMove(new GameControl(g));
                Console.Write(g.ShowGameState());
                Console.ReadLine();
            }

            Console.WriteLine("STATUS: " + g.StateOfGame);
            Console.WriteLine("Game Terminated");
            Console.ReadLine();

        }
    }
}

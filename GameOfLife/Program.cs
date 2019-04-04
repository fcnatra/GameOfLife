using System;
using System.Collections.Generic;
using static GameOfLife.BoardFactory;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> boardPattern = BoardFactory.BuildBoard(GameOfLifePatterns.CellularAutomationGosperGliderGun);

            GameOfLifeGameLogic.Game game = new GameOfLifeGameLogic.Game();
            game.BoardPainter = new GameOfLifeWinformsUI();
            game.InitializeGame(boardPattern);
            game.Play();

            PressAKeyToExit(game);
        }

        private static void PressAKeyToExit(GameOfLifeGameLogic.Game game)
        {
            Console.WriteLine();
            Console.WriteLine("END.\r\nPress a key to exit...");
            do {/*System.Threading.Thread.SpinWait(10);*/} while (!Console.KeyAvailable);

            game.Stop();
        }


    }
}

using System;
using System.Collections.Generic;
using static GameOfLife.BoardFactory;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameOfLifeGameLogic.Game();

            SetupUI(game);
            SetUpBoard(game);
            SetUpGame(game);
            game.Play();

            PressEnterToExit(game);
            game.Stop();
        }

        private static void SetUpGame(GameOfLifeGameLogic.Game game)
        {
            game.DelayBetweenGenerationsInMs = 80;
        }

        private static void SetUpBoard(GameOfLifeGameLogic.Game game)
        {
            List<string> boardPattern = BoardFactory.BuildBoard(GameOfLifePatterns.CellularAutomationGosperGliderGun);
            game.InitializeGame(boardPattern);
        }

        private static void SetupUI(GameOfLifeGameLogic.Game game)
        {
            game.BoardPainter = new GameOfLifeConsoleUI();
            //game.BoardPainter = new GameOfLifeWinformsUI { PointSize = 5 };
        }

        private static void PressEnterToExit(GameOfLifeGameLogic.Game game)
        {
            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to exit...");
            Console.ReadLine();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using static GameOfLife.BoardFactory;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = BoardFactory.BoardPattern(GameOfLifePatterns.CellularAutomationGosperGliderGun);

            GameOfLifeCoreLogic gameOfLife = InitializeGame(board);

            IGameOfLifeUI gameUi = new GameOfLifeConsoleUI();
            gameUi.RunLife(gameOfLife);

            PressEnterToExit();
        }

        private static GameOfLifeCoreLogic InitializeGame(List<string> pattern)
        {
            var gameOfLife = new GameOfLifeCoreLogic();
            gameOfLife.InitializeBoard(pattern.Count + 15, pattern.Max(x => x.Length) + 20);
            gameOfLife.SetRows(pattern);
            return gameOfLife;
        }

        private static void PressEnterToExit()
        {
            Console.WriteLine();
            Console.WriteLine("END.\r\nPress enter to exit...");
            Console.ReadLine();
        }


    }
}

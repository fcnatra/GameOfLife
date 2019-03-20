using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        private enum GameOfLifePatterns
        {
            // Oscilators
            Blinker,
            Toad,
            Beacon,

            // Spaceships
            Glider,

            // Cellular automaton
            GosperGliderGun
        }

        static void Main(string[] args)
        {
            var pattern = PatterbBoard(GameOfLifePatterns.GosperGliderGun);

            var gameOfLife = new GameOfLifeCoreLogic();
            gameOfLife.InitializeBoard(pattern.Count + 15, pattern.Max(x => x.Length) + 20);
            gameOfLife.SetRows(pattern);

            RunLife(gameOfLife);

            PressEnterToExit();
        }

        private static void RunLife(GameOfLifeCoreLogic gameOfLife)
        {
            do
            {
                SetTitle(gameOfLife.GenerationNumber);
                DrawBoard(gameOfLife.Board);
                Thread.Sleep(100);
                gameOfLife.NextGeneration();
            } while (!Console.KeyAvailable);
        }

        private static List<String> PatterbBoard(GameOfLifePatterns pattern)
        {
            // https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
            List<String> resultPattern = null;

            switch (pattern)
            {
                case GameOfLifePatterns.Blinker:
                    resultPattern = new List<String>
                    {
                        "",
                        "",
                        ".***."
                    };
                    break;
                case GameOfLifePatterns.Toad:
                    resultPattern = new List<String>
                    {
                        "",
                        "",
                        "..***.",
                        ".***.."
                    };
                    break;
                case GameOfLifePatterns.Beacon:
                    resultPattern = new List<String>
                    {
                        "",
                        ".**...",
                        ".**...",
                        "...**.",
                        "...**."
                    };
                    break;
                case GameOfLifePatterns.Glider:
                    resultPattern = new List<String>
                    {
                        "",
                        "..*.",
                        "...*.",
                        ".***.",
                    };
                    break;
                case GameOfLifePatterns.GosperGliderGun:
                    // https://en.wikipedia.org/wiki/Gun_(cellular_automaton)#/media/File:Game_of_life_glider_gun.svg
                    resultPattern = new List<String>
                    {
                        "",
                        ".........................*............",
                        ".......................*.*............",
                        ".............**......**............**.",
                        "............*...*....**............**.",
                        ".**........*.....*...**...............",
                        ".**........*...*.**....*.*............",
                        "...........*.....*.......*............",
                        "............*...*.....................",
                        ".............**.......................",
                    };
                    break;
                default:
                    break;
            }
            return resultPattern;
        }

        private static void SetTitle(long generationNumber)
        {
            Console.SetCursorPosition(1, 1);
            Console.Write($"Generation number: {generationNumber}");
        }

        private static void PressEnterToExit()
        {
            Console.WriteLine();
            Console.WriteLine("END.\r\nPress enter to exit...");
            Console.ReadLine();
        }

        private static void DrawBoard(StringBuilder[] board)
        {
            var rows = board.Length;
            var columns = board[0].Length;

            var rowOffset = 5;
            var columnOffset = 5;

            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    Console.SetCursorPosition(column + columnOffset, row + rowOffset);
                    Console.Write(board[row][column]);
                }
        }
    }
}

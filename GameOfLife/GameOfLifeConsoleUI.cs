using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    public class GameOfLifeConsoleUI : IGameOfLifeUI
    {
        public void RunLife(GameOfLifeCoreLogic gameOfLife)
        {
            do
            {
                SetTitle(gameOfLife.GenerationNumber);
                DrawBoard(gameOfLife.Board);
                Thread.Sleep(100);
                gameOfLife.NextGeneration();
            } while (!Console.KeyAvailable);
        }

        private void SetTitle(long generationNumber)
        {
            Console.SetCursorPosition(1, 1);
            Console.Write($"Generation number: {generationNumber}");
        }

        private void DrawBoard(StringBuilder[] board)
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

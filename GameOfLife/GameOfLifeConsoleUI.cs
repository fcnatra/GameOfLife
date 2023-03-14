using System;
using System.Text;
using System.Threading;
using GameOfLifeGameLogic;

namespace GameOfLife
{
    public class GameOfLifeConsoleUI : IGameOfLifeUI
    {
        public void GenerationHasChanged(long iterationNumber, StringBuilder[] board)
        {
            new Thread(new ThreadStart(() =>
            {
                lock (this)
                {
                    DrawGenerationNumber(iterationNumber);
                    DrawBoard(board);
                }
            }))
            .Start();
        }

        private void DrawGenerationNumber(long generationNumber)
        {
            Console.SetCursorPosition(1, 2);
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

        public void Dispose()
        {
            Console.Clear();
        }
    }
}

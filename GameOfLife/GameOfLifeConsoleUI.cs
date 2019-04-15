using System;
using System.Text;
using GameOfLifeGameLogic;

namespace GameOfLife
{
    public class GameOfLifeConsoleUI : IGameOfLifeUI
    {
        public void GenerationHasChanged(long generationNumber)
        {
            Console.SetCursorPosition(1, 1);
            Console.Write($"Generation number: {generationNumber}");
        }

        public void DrawBoard(StringBuilder[] board)
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

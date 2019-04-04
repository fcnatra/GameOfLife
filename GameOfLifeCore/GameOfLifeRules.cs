using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GameOfLifeGameLogic
{
    public class GameOfLifeRules
    {
        public const char DEAD_CELLCHAR = '.';
        public const char ALIVE_CELLCHAR = '*';
        public StringBuilder[] Board { get; private set; }
        public long GenerationNumber { get; set; } = 0;
        private int Rows { get; set; }
        private int Columns { get; set; }

        public void NextGeneration()
        {
            var newBoard = BuildBoard(this.Rows);
            PopulateBoardWithDeadCells(newBoard);
            SetNextGenerationForEachCell(newBoard);

            this.Board = newBoard;
            GenerationNumber++;
        }

        private void SetNextGenerationForEachCell(StringBuilder[] newBoard)
        {
            for (int row = 0; row < this.Rows; row++)
                for (int column = 0; column < this.Columns; column++)
                    newBoard[row][column] = GetNextGeneration(row, column);
        }

        private char GetNextGeneration(int row, int column)
        {
            int livingNeighbours = GetLivingNeighbours(row, column);

            char nextGeneration = Board[row][column];
            if (IsDead(row, column) && livingNeighbours == 3)
                nextGeneration = ALIVE_CELLCHAR;
            else if (livingNeighbours < 2 || livingNeighbours > 3)
                nextGeneration = DEAD_CELLCHAR;

            return nextGeneration;
        }

        private int GetLivingNeighbours(int row, int column)
        {
            int livingNeighbours = 0
                + (IsAlive(row - 1, column - 1) ? 1 : 0)
                + (IsAlive(row - 1, column) ? 1 : 0)
                + (IsAlive(row - 1, column + 1) ? 1 : 0)
                + (IsAlive(row, column - 1) ? 1 : 0)
                + (IsAlive(row, column + 1) ? 1 : 0)
                + (IsAlive(row + 1, column - 1) ? 1 : 0)
                + (IsAlive(row + 1, column) ? 1 : 0)
                + (IsAlive(row + 1, column + 1) ? 1 : 0);

            return livingNeighbours;
        }

        private StringBuilder[] BuildBoard(int rows)
        {
            return new StringBuilder[rows];
        }

        private void PopulateBoardWithDeadCells(StringBuilder[] board)
        {
            for (int row = 0; row < Rows; row++)
                board[row] = new StringBuilder("".PadLeft(Columns, DEAD_CELLCHAR));
        }

        public void InitializeBoard(int rows, int columns)
        {
            this.Board = BuildBoard(rows);
            this.Rows = rows;
            this.Columns = columns;
            PopulateBoardWithDeadCells(this.Board);
        }

        public void SetLivingCells(List<Point> livingCells)
        {
            foreach (var livingCell in livingCells)
                this.Board[livingCell.X][livingCell.Y] = ALIVE_CELLCHAR;
        }

        public void SetRows(List<string> rows)
        {
            for (int row = 0; row < rows.Count; row++)
                for (int column = 0; column < rows[row].Length; column++)
                    this.Board[row][column] = rows[row][column];
        }

        public bool IsAlive(int row, int column)
        {
            return CellIsInsideLimits(row, column)
                && this.Board[row][column] == ALIVE_CELLCHAR;
        }

        public bool IsDead(int row, int column)
        {
            return CellIsBeyondLimits(row, column) 
                || this.Board[row][column] == DEAD_CELLCHAR;
        }

        private bool CellIsBeyondLimits(int row, int column)
        {
            return row < 0 || row >= Rows
                || column < 0 || column >= Columns;
        }

        private bool CellIsInsideLimits(int row, int column)
        {
            return !CellIsBeyondLimits(row, column);
        }
    }
}

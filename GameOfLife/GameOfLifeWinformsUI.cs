using System.Text;
using GameOfLifeGameLogic;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameOfLifeWinformsUI : IGameOfLifeUI
    {
        private Dictionary<char, Brush> _brushes;
        private Form _formBoard;
        private Form FormBoard { get
            {
                if (_formBoard == null) InitializeForm();
                return _formBoard;
            }
        }

        public GameOfLifeWinformsUI()
        {
        }

        private void InitializeForm()
        {
            _formBoard = new Form();
            _formBoard.ControlBox = false;
            _formBoard.ShowInTaskbar = false;
            _formBoard.FormClosing += _formBoard_FormClosing;
            _formBoard.StartPosition = FormStartPosition.CenterScreen;
            _formBoard.Show();

            _brushes = new Dictionary<char, Brush>
            {
                {'.',  new Pen(_formBoard.BackColor).Brush},
                {'*',  Pens.Black.Brush }
            };
        }

        private void _formBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formBoard.Close();
        }

        public void SetGenerationNumber(long generationNumber)
        {
            //Console.SetCursorPosition(1, 1);
            //Console.Write($"Generation number: {generationNumber}");
        }

        private delegate void DrawBoardSafeCall(StringBuilder[] board);

        public void DrawBoard(StringBuilder[] board)
        {
            if (FormBoard.InvokeRequired)
            {
                var drawDelegate = new DrawBoardSafeCall(DrawBoard);
                FormBoard.Invoke(drawDelegate, board);
            }
            else
            {
                var rows = board.Length;
                var columns = board[0].Length;

                var rowOffset = 5;
                var columnOffset = 5;

                FormBoard.Height = rows;
                FormBoard.Width = columns;
                var graphics = FormBoard.CreateGraphics();

                for (int row = 0; row < rows; row++)
                    for (int column = 0; column < columns; column++)
                        graphics.FillRectangle(_brushes[board[row][column]], column + columnOffset, row + rowOffset, 1, 1);

                Application.DoEvents();
            }
        }

        public void Dispose()
        {
            
        }
    }
}

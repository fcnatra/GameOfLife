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
        public int PointSize { get; set; }

        public GameOfLifeWinformsUI()
        {
        }

        private void InitializeForm()
        {
            _formBoard = new Form
            {
                ControlBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.Black
            };
            _formBoard.FormClosing += OnFormClosing;
            _formBoard.Show();

            _brushes = new Dictionary<char, Brush>
            {
                {'.',  new Pen(_formBoard.BackColor).Brush},
                {'*',  Pens.White.Brush }
            };
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            _formBoard.Close();
        }

        public void SetGenerationNumber(long generationNumber)
        {
            //FormBoard.Tag = $"Generation {generationNumber}";
        }

        private delegate void DrawBoardSafeCall(StringBuilder[] board);

        public void DrawBoard(StringBuilder[] board)
        {
            var rows = board.Length;
            var columns = board[0].Length;

            FormBoard.Size = new Size(TransformCoord(rows, columns));
            FormBoard.Width += PointSize;
            FormBoard.Height += PointSize;

            var graphics = FormBoard.CreateGraphics();

            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    var transformation = TransformCoord(row, column);
                    graphics.FillRectangle(_brushes[board[row][column]], transformation.X, transformation.Y, PointSize, PointSize);
                }
        }

        private Point TransformCoord(int row, int col)
        {
            var rowstransformed = row * PointSize;
            var colsTransformed = col * PointSize;

            return new Point(colsTransformed, rowstransformed);
        }

        public void Dispose()
        {
            
        }
    }
}

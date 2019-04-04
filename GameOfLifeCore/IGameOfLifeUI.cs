using System;
using System.Text;

namespace GameOfLifeGameLogic
{
    public interface IGameOfLifeUI : IDisposable
    {
        void SetGenerationNumber(long iterationNumber);
        void DrawBoard(StringBuilder[] board);
    }
}

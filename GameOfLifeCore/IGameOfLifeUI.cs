﻿using System;
using System.Text;

namespace GameOfLifeGameLogic
{
    public interface IGameOfLifeUI : IDisposable
    {
        void GenerationHasChanged(long iterationNumber, StringBuilder[] board);
    }
}

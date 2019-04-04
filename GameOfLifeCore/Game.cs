using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLifeGameLogic
{
    public class Game
    {
        private GameOfLifeRules _gameRules;
        private CancellationTokenSource _cancellationToken;

        public IGameOfLifeUI BoardPainter { get; set; }
        public long GenerationNumber { get; private set; }

        public void InitializeGame(List<string> boardPattern)
        {
            var gameRules = new GameOfLifeRules();
            gameRules.InitializeBoard(boardPattern.Count + 15, boardPattern.Max(x => x.Length) + 20);
            gameRules.SetRows(boardPattern);

            _gameRules = gameRules;
        }

        public void Play()
        {
            CheckGameIsInitialized();

            _cancellationToken = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncPlayGame), _cancellationToken.Token);
        }

        private void CheckGameIsInitialized()
        {
            if (_gameRules == null) throw new InvalidOperationException("Game is not initialized yet");
        }

        public void Stop()
        {
            _cancellationToken?.Cancel();
        }

        private void AsyncPlayGame(object cancellationToken)
        {
            do
            {
                BoardPainter.SetGenerationNumber(GenerationNumber);
                BoardPainter.DrawBoard(_gameRules.Board);
                Thread.SpinWait(200);
                _gameRules.NextGeneration();
                GenerationNumber++;

            } while (!_cancellationToken.IsCancellationRequested);

            _cancellationToken.Dispose();
            _cancellationToken = null;
            BoardPainter.Dispose();
        }
    }
}

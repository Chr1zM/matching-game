using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MemoryGame.GameModes
{
    internal class RageRageGameMode : RageGameMode
    {
        private DispatcherTimer shuffleTimer;

        public RageRageGameMode(Grid grid, TextBlock timeText, TextBlock holderText) : base(grid, timeText, holderText) { }

        protected override void InitializeGame()
        {
            base.InitializeGame();
            InitializeShuffleTimer();
        }

        private void InitializeShuffleTimer()
        {
            shuffleTimer = new DispatcherTimer();
            shuffleTimer.Interval = TimeSpan.FromSeconds(1.5);
            shuffleTimer.Tick += ShuffleTimer_Tick;
            shuffleTimer.Start();
        }

        private void ShuffleTimer_Tick(object sender, EventArgs e)
        {
            shuffle();
        }
    }
}

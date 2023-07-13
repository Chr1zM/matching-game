using MemoryGame.GameModes;
using System;
using System.Windows.Controls;

namespace MemoryGame
{
    public class GameModeFactory
    {
        private GameMode gameMode;
        private Grid grid;
        private TextBlock timeText;
        private TextBlock holderText;

        public GameModeFactory(GameMode gameMode, Grid grid, TextBlock timeText, TextBlock holderText)
        {
            this.gameMode = gameMode;
            this.grid = grid;
            this.timeText = timeText;
            this.holderText = holderText;
        }

        public BaseGameMode create()
        {
            switch (gameMode)
            {
                case GameMode.Base: return new BaseGameMode(grid, timeText, holderText);
                case GameMode.Rage: return new RageGameMode(grid, timeText, holderText);
                case GameMode.RageRage: return new RageRageGameMode(grid, timeText, holderText);
                default: throw new ArgumentException("");
            }
        }
    }
}

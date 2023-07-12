using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoryGame
{
    using System.Windows.Threading;

    /// <summary>
    /// Interaktionslogik für GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public const int REQUIRED_MATCHES = 8;

        private BaseGameMode gameMode;

        public GamePage()
        {
            InitializeComponent();

            InitializeGame();
        }

        private void InitializeGame()
        {
            gameMode = new BaseGameMode(mainGrid, timeTextBlock, holderTextBlock);
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gameMode.TextBlock_MouseDown(sender, e);
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (gameMode.MatchesFound == REQUIRED_MATCHES)
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.ShowMenuPage();
            }
        }

        private static List<string> getAnimalList()
        {
            return new List<string>
            {
                "🐕", "🐈", "🐅", "🐎", "🦌", "🦏", "🦛", "🐂", "🐃", "🐄", "🐖", "🐏", "🐐", "🐪", "🐫", "🦙", "🦘",
                "🦥", "🦨", "🦡", "🐘", "🐁", "🐀", "🦔", "🐇", "🐿", "🦎", "🐊", "🐢", "🐍", "🐉", "🦕", "🦖", "🦦",
                "🦈", "🐳", "🐠", "🦐", "🦑", "🐙", "🦞", "🦀", "🦆", "🐓", "🕊", "🦢", "🦜", "🦩", "🦚", "🦉", "🐦",
                "🐧", "🐤", "🦇", "🦋", "🐌", "🐛", "🦟", "🐜",
            };
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoryGame
{
    /// <summary>
    /// Interaktionslogik für GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public const int REQUIRED_MATCHES = 8;

        private BaseGameMode gameMode;

        public GamePage(GameMode selectedGameMode)
        {
            InitializeComponent();

            InitializeGame(selectedGameMode);
        }

        private void InitializeGame(GameMode selectedGameMode)
        {
            gameMode = new GameModeFactory(selectedGameMode, mainGrid, timeTextBlock, holderTextBlock).create();
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
    }
}

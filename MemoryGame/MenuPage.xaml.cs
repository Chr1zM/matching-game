using System.Windows;
using System.Windows.Controls;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private HighScoreManager highScoreManager;

        public MenuPage()
        {
            InitializeComponent();

            InitializeHighScore();
        }

        private void InitializeHighScore()
        {
            highScoreManager = new HighScoreManager("./HighScore.txt");
            HighScoreEntry highScore = highScoreManager.LoadHighScore();
            if (highScore.Score != float.MaxValue)
            {
                highScoreTextBlock.Text = "HighScore: " + highScore.Score.ToString("0.0s");
            }
            else
            {
                highScoreTextBlock.Text = "HighScore: /";
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.InitializeGame(GameMode.Base);
        }

        private void RageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.InitializeGame(GameMode.Rage);
        }

        private void RageRageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.InitializeGame(GameMode.RageRage);
        }
    }
}

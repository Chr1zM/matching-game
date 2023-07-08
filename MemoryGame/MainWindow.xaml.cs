using System.Windows;

namespace MemoryGame
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GamePage gamePage;
        private HighScoreManager highScoreManager;

        public MainWindow()
        {
            InitializeComponent();

            highScoreManager = new HighScoreManager("./HighScore.txt");
            HighScoreEntry highScore = highScoreManager.LoadHighScore();
            if(highScore.Score != float.MaxValue)
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
            InitializeGame();
        }

        private void InitializeGame()
        {
            gamePage = new GamePage();
            Content = gamePage;
        }
    }
}

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
            ShowMenuPage();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeGame();
        }

        public void InitializeGame()
        {
            gamePage = new GamePage();
            Content = gamePage;
        }

        public void ShowMenuPage()
        {
            MenuPage menuPage = new MenuPage();
            Content = menuPage;
        }
    }
}

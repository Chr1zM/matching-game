using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            mainWindow.InitializeGame();
        }
    }
}

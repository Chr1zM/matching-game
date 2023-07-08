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
    using System.Windows.Controls.Primitives;
    using System.Windows.Threading;

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

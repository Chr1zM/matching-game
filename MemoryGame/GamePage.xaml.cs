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
        private DispatcherTimer timer;
        private int tenthsOfSecondsElapsed;
        private int matchesFound;
        private TextBlock lastTextBlockClicked;
        private bool findingMatch = false;
        private HighScoreManager highScoreManager;

        private const int REQUIRED_MATCHES = 8;

        public GamePage()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;

            highScoreManager = new HighScoreManager("./HighScore.txt");
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            if (matchesFound == REQUIRED_MATCHES)
            {
                timer.Stop();
                timeTextBlock.Text = $"{timeTextBlock.Text} - Zurück zum Hauptmenü?";


                float finalTime = tenthsOfSecondsElapsed / 10F;
                HighScoreEntry highScoreEntry = new HighScoreEntry(finalTime);

                if (highScoreEntry.Score < highScoreManager.LoadHighScore().Score)
                    highScoreManager.SaveHighScore(highScoreEntry);
            }
        }

        private void SetUpGame()
        {
            List<string> animalList = getAnimalList();

            Random random = new Random();

            // filter auf 8 Paare
            List<string> filteredList = new List<string>();
            while (filteredList.Count < 16)
            {
                int index = random.Next(animalList.Count);
                string emoji = animalList[index];
                animalList.RemoveAll(elem => elem.Equals(emoji));

                filteredList.Add(emoji);
                filteredList.Add(emoji);
            }

            foreach (TextBlock textBlock in GetMatchingTextBlocks())
            {
                textBlock.Visibility = Visibility.Visible;
                int index = random.Next(filteredList.Count);
                string nextAnimal = filteredList[index];
                textBlock.Text = nextAnimal;
                filteredList.RemoveAt(index);
            }

            holderTextBlock.Visibility = Visibility.Hidden;

            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
            timer.Start();
        }

        private IEnumerable<TextBlock> GetMatchingTextBlocks()
        {
            return mainGrid.Children.OfType<TextBlock>()
                .Where(tb => tb.Name != "timeTextBlock" && tb.Name != "holderTextBlock");
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (!findingMatch)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;

                holderTextBlock.Visibility = Visibility.Visible;
                holderTextBlock.Text = textBlock.Text;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;

                holderTextBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;

                holderTextBlock.Visibility = Visibility.Hidden;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == REQUIRED_MATCHES)
            {
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.ShowMenuPage();
            }
        }

        private static List<string> getAnimalList()
        {
            return new List<string>
            {
                "🐕","🐕",
                "🐈","🐈",
                "🐅","🐅",
                "🐎","🐎",
                "🦌","🦌",
                "🦏","🦏",
                "🦛","🦛",
                "🐂","🐂",
                "🐃","🐃",
                "🐄","🐄",
                "🐖","🐖",
                "🐏","🐏",
                "🐐","🐐",
                "🐪","🐪",
                "🐫","🐫",
                "🦙","🦙",
                "🦘","🦘",
                "🦥","🦥",
                "🦨","🦨",
                "🦡","🦡",
                "🐘","🐘",
                "🐁","🐁",
                "🐀","🐀",
                "🦔","🦔",
                "🐇","🐇",
                "🐿","🐿",
                "🦎","🦎",
                "🐊","🐊",
                "🐢","🐢",
                "🐍","🐍",
                "🐉","🐉",
                "🦕","🦕",
                "🦖","🦖",
                "🦦","🦦",
                "🦈","🦈",
                "🐳", "🐳",
                "🐠","🐠",
                "🦐","🦐",
                "🦑","🦑",
                "🐙","🐙",
                "🦞","🦞",
                "🦀","🦀",
                "🦆","🦆",
                "🐓","🐓",
                "🕊","🕊",
                "🦢","🦢",
                "🦜","🦜",
                "🦩","🦩",
                "🦚","🦚",
                "🦉","🦉",
                "🐦","🐦",
                "🐧","🐧",
                "🐤","🐤",
                "🦇","🦇",
                "🦋","🦋",
                "🐌","🐌",
                "🐛","🐛",
                "🦟","🦟",
                "🐜","🐜",
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoryGame
{
    using System.Windows.Threading;

    public class BaseGameMode
    {
        private DispatcherTimer timer;

        private int tenthsOfSecondsElapsed;

        private int matchesFound;
        public int MatchesFound { get { return matchesFound; } }

        private TextBlock lastTextBlockClicked;
        private bool findingMatch = false;
        private HighScoreManager highScoreManager;

        private Grid mainGrid;
        private TextBlock timeTextBlock;
        private TextBlock holderTextBlock;

        public BaseGameMode(Grid grid, TextBlock timeText, TextBlock holderText)
        {
            mainGrid = grid;
            timeTextBlock = timeText;
            holderTextBlock = holderText;

            InitializeGame();
        }

        private void InitializeGame()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;

            highScoreManager = new HighScoreManager("./../HighScore.txt");

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalList = GetAnimalList();

            Random random = new Random();

            // Filter auf 8 Paare
            List<string> filteredList = new List<string>();
            while (filteredList.Count < 16)
            {
                int index = random.Next(animalList.Count);
                string emoji = animalList[index];
                animalList.RemoveAt(index);

                filteredList.Add(emoji);
                filteredList.Add(emoji);
            }

            foreach (TextBlock textBlock in GetMatchingTextBlocks(mainGrid))
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

        public virtual void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            if (matchesFound == GamePage.REQUIRED_MATCHES)
            {
                timer.Stop();
                timeTextBlock.Text = $"{timeTextBlock.Text} - Zurück zum Hauptmenü?";


                float finalTime = tenthsOfSecondsElapsed / 10F;
                HighScoreEntry highScoreEntry = new HighScoreEntry(finalTime);

                if (highScoreEntry.Score < highScoreManager.LoadHighScore().Score)
                    highScoreManager.SaveHighScore(highScoreEntry);
            }
        }

        private IEnumerable<TextBlock> GetMatchingTextBlocks(Grid mainGrid)
        {
            return mainGrid.Children.OfType<TextBlock>()
                .Where(tb => tb.Name != "timeTextBlock" && tb.Name != "holderTextBlock");
        }

        public void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
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

        protected List<string> GetAnimalList()
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoryGame.GameModes
{
    internal class RageGameMode : BaseGameMode
    {
        public RageGameMode(Grid grid, TextBlock timeText, TextBlock holderText) : base(grid, timeText, holderText) { }

        override public void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
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

                shuffle();
            }
        }

        protected void shuffle()
        {
            List<string> animalList = new List<string>();

            foreach (TextBlock tb in GetMatchingTextBlocks(mainGrid))
            {
                animalList.Add(tb.Text);
                tb.Text = string.Empty;
            }

            Random random = new Random();

            foreach (TextBlock tb in GetMatchingTextBlocks(mainGrid))
            {
                int index = random.Next(animalList.Count);
                string nextEmoji = animalList[index];
                tb.Text = nextEmoji;
                animalList.RemoveAt(index);
            }
        }

    }
}

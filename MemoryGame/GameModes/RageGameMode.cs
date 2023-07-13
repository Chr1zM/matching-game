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
            IEnumerable<TextBlock> textBlocks = GetVisibleTextBlocks(mainGrid);

            List<string> animalList = textBlocks.Select(tb => tb.Text).ToList();

            Random random = new Random();

            GetVisibleTextBlocks(mainGrid).ToList().ForEach(tb =>
            {
                int index = random.Next(animalList.Count);
                tb.Text = animalList[index];
                animalList.RemoveAt(index);
            });
        }

        protected IEnumerable<TextBlock> GetVisibleTextBlocks(Grid mainGrid)
        {
            return GetMatchingTextBlocks(mainGrid)
                .Where(tb => tb.Visibility == Visibility.Visible);
        }
    }
}

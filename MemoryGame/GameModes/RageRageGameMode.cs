using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoryGame.GameModes
{
    internal class RageRageGameMode : BaseGameMode
    {
        public RageRageGameMode(Grid grid, TextBlock timeText, TextBlock holderText) : base(grid, timeText, holderText) { }


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

                // TODO: Shuffle
            }
        }
    }
}

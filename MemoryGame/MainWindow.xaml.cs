﻿using System.Windows;

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

        public void InitializeGame(GameMode selectedGameMode)
        {
            gamePage = new GamePage(selectedGameMode);
            Content = gamePage;
        }

        public void ShowMenuPage()
        {
            MenuPage menuPage = new MenuPage();
            Content = menuPage;
        }
    }
}

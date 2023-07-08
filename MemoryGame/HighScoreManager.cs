using System.IO;

namespace MemoryGame
{
    internal class HighScoreManager
    {
        private string highScoreFilePath;

        public HighScoreManager(string filePath)
        {
            highScoreFilePath = filePath;
        }

        public HighScoreEntry LoadHighScore()
        {
            if (!File.Exists(highScoreFilePath)) return new HighScoreEntry(float.MaxValue);

            string scoreString = File.ReadAllText(highScoreFilePath);
            if (string.IsNullOrWhiteSpace(scoreString)) return new HighScoreEntry(float.MaxValue);

            return new HighScoreEntry(float.Parse(scoreString));
        }

        public void SaveHighScore(HighScoreEntry highScore)
        {
            File.WriteAllText(highScoreFilePath, $"{highScore.Score}");
        }
    }

    public class HighScoreEntry
    {
        public float Score { get; set; }

        public HighScoreEntry(float score)
        {
            Score = score;
        }
    }
}

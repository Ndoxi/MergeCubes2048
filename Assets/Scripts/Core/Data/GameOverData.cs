namespace Core.Data
{
    public readonly struct GameOverData
    {
        public readonly int score;
        public readonly float totalPlaytime;

        public GameOverData(int score, float totalPlaytime)
        {
            this.score = score;
            this.totalPlaytime = totalPlaytime;
        }
    }
}
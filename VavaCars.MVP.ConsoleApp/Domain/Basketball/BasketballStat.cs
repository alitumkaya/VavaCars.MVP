namespace VavaCars.MVP.ConsoleApp.Domain.Basketball
{
    public class BasketballStat
    {
        public BasketballPosition Position { get; init; }
        public int ScoredPoint { get; init; }
        public int Rebound { get; init; }
        public int Assist { get; init; }
        public BasketballStat(BasketballPosition position, int scoredPoint, int rebound, int assist)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            ScoredPoint = scoredPoint;
            Rebound = rebound;
            Assist = assist;
        }

        public decimal GetRatingPoint()
        {
            return ScoredPoint * Position.ScoredPoint + Rebound * Position.Rebound + Assist * Position.Assist;
        }
    }

    public class BasketballPosition
    {
        public static BasketballPosition Guard = new BasketballPosition("Guard", 2, 3, 1);
        public static BasketballPosition Forward = new BasketballPosition("Forward", 2, 2, 2);
        public static BasketballPosition Center = new BasketballPosition("Center", 2, 1, 3);
        private BasketballPosition() { }
        private BasketballPosition(string position, int scoredPoint, int rebound, int assist)
        {
            Position = position;
            ScoredPoint = scoredPoint;
            Rebound = rebound;
            Assist = assist;
        }
        public string Position { get; init; }
        public int ScoredPoint { get; init; }
        public int Rebound { get; init; }
        public int Assist { get; init; }
    }
}

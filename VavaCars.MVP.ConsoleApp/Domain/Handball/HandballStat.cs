namespace VavaCars.MVP.ConsoleApp.Domain.Handball
{
    internal class HandballStat
    {
        public HandballPosition Position { get; init; }
        public int GoalMade { get; init; }
        public int GoalReceived { get; init; }
        public HandballStat(HandballPosition position, int goalMade, int goalReceived)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            GoalMade = goalMade;
            GoalReceived = goalReceived;
        }

        public decimal GetRatingPoints()
        {
            return (Position.InitialRaitingPoints + GoalMade * Position.GoalMade + GoalReceived * Position.GoalReceived);
        }
    }

    public class HandballPosition
    {
        public static HandballPosition Goalkeeper = new HandballPosition("Goalkeeper", 50, 5, -1);
        public static HandballPosition FieldPlayer = new HandballPosition("FieldPlayer", 20, 1, -1);
        private HandballPosition() { }
        private HandballPosition(string position, int initialRaitingPoints, int goalMade, int goalReceived)
        {
            Position = position;
            InitialRaitingPoints = initialRaitingPoints;
            GoalMade = goalMade;
            GoalReceived = goalReceived;
        }
        public string Position { get; init; }
        public int InitialRaitingPoints { get; init; }
        public int GoalMade { get; init; }
        public int GoalReceived { get; init; }
    }
}

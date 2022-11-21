namespace VavaCars.MVP.ConsoleApp.Domain.Handball
{
    internal class HandballPlayer : PlayerBase
    {
        private ICollection<HandballStat> _stats;
        private decimal _ratingPoints { get; set; }
        private decimal _winnerRatingPoint { get; set; }
        public HandballPlayer(string playerName, string nickName, string number) : base(playerName, nickName, number)
        {
            _stats = new List<HandballStat>();
        }
        public void AddStat(HandballStat handballStat)
        {
            _stats.Add(handballStat);
            _ratingPoints += handballStat.GetRatingPoints();
        }
        internal override void AddWinnerRaitingPoint()
        {
            _winnerRatingPoint += WINNER_RAITING_POINT;
        }
        public override decimal GetRatingPoints()
        {
            return _ratingPoints + _winnerRatingPoint;
        }
    }
}

namespace VavaCars.MVP.ConsoleApp.Domain.Basketball
{
    internal class BasketballPlayer : PlayerBase
    {
        private ICollection<BasketballStat> _stats;
        private decimal _ratingPoints { get; set; }
        private decimal _winnerRatingPoint { get; set; }
        public BasketballPlayer(string playerName, string nickName, string number) : base(playerName, nickName, number)
        {
            _stats = new List<BasketballStat>();
        }
        public void AddStat(BasketballStat basketballStat)
        {
            _stats.Add(basketballStat);
            _ratingPoints += basketballStat.GetRatingPoint();
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

using System.Runtime.CompilerServices;

namespace VavaCars.MVP.ConsoleApp.Domain
{
    public abstract class PlayerBase
    {
        protected const int WINNER_RAITING_POINT = 10;
        public string PlayerName { get; private set; }
        public string NickName { get; private set; }
        public string Number { get; private set; }
        public PlayerBase(string playerName, string nickName, string number)
        {
            PlayerName = playerName ?? throw new ArgumentNullException(nameof(playerName));
            NickName = nickName ?? throw new ArgumentNullException(nameof(nickName));
            Number = number ?? throw new ArgumentNullException(nameof(number));
        }

        internal abstract void AddWinnerRaitingPoint();
        public abstract decimal GetRatingPoints();
    }
}

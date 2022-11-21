namespace VavaCars.MVP.ConsoleApp.Domain.Basketball
{
    internal class BasketballPlayerReader : IPlayerReader
    {
        public string ReaderUniqueuKey => "BASKETBALL";
        private readonly IPlayerRepository _playerRepository;

        private readonly Dictionary<string, BasketballPosition> _positions;
        public BasketballPlayerReader(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            _positions = new Dictionary<string, BasketballPosition>()
            {
                { "G",BasketballPosition.Guard },
                { "C",BasketballPosition.Center },
                { "F",BasketballPosition.Forward }
            };
        }

        public async Task<PlayerBase> ReadPlayerStatsFromAsync(string line)
        {
            var splittedLine = line.Split(';');

            if (splittedLine.Length != 8)
                throw new BasketballMathStatsFileFormatException();

            var playerName = splittedLine[0];
            var nickname = splittedLine[1];
            var number = splittedLine[2];
            var position = _positions[splittedLine[4]];
            var scoredPoints = int.Parse(splittedLine[5]);
            var rebound = int.Parse(splittedLine[6]);
            var assist = int.Parse(splittedLine[7]);

            var player = await _playerRepository.GetPlayerWithNicknameAsync(nickname);
            if (player == null)
                player = new BasketballPlayer(playerName, nickname, number);

            ((BasketballPlayer)player).AddStat(new BasketballStat(position, scoredPoints, rebound, assist));

            return player;
        }
    }
}

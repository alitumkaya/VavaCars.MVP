namespace VavaCars.MVP.ConsoleApp.Domain.Handball
{
    internal class HandballPlayerReader : IPlayerReader
    {
        public string ReaderUniqueuKey => "HANDBALL";
        private readonly IPlayerRepository _playerRepository;

        private readonly Dictionary<string, HandballPosition> _positions;
        public HandballPlayerReader(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            _positions = new Dictionary<string, HandballPosition>()
            {
                { "F",HandballPosition.FieldPlayer },
                { "G",HandballPosition.Goalkeeper },
            };
        }

        public async Task<PlayerBase> ReadPlayerStatsFromAsync(string line)
        {
            var splittedLine = line.Split(';');

            if (splittedLine.Length != 7)
                throw new HandballMathStatsFileFormatException();

            var playerName = splittedLine[0];
            var nickname = splittedLine[1];
            var number = splittedLine[2];
            var position = _positions[splittedLine[4]];
            var goalsMade = int.Parse(splittedLine[5]);
            var goalsReceived = int.Parse(splittedLine[6]);

            var player = await _playerRepository.GetPlayerWithNicknameAsync(nickname);
            if (player == null)
                player = new HandballPlayer(playerName, nickname, number);

            ((HandballPlayer)player).AddStat(new HandballStat(position, goalsMade, goalsReceived));

            return player;
        }
    }
}

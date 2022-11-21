using AutoMapper;
using VavaCars.MVP.ConsoleApp.Domain;

namespace VavaCars.MVP.ConsoleApp.AppServices
{
    internal class MvpAppService : IMvpAppService
    {
        private readonly IEnumerable<IPlayerReader> _playerReaders;
        private readonly IPlayerRepository _players;
        private readonly IMapper _mapper;

        public MvpAppService(IEnumerable<IPlayerReader> playerReaders,
                             IPlayerRepository players,
                             IMapper mapper)
        {
            this._playerReaders = playerReaders;
            _players = players;
            _mapper = mapper;
        }

        public async Task<PlayerDto> FindMvp()
        {
            var players = await _players.ListAllPlayersAsync();
            var mvp = players.MaxBy(m => m.GetRatingPoints());

            return _mapper.Map<PlayerDto>(mvp);
        }

        public async Task ReadMatchStatsFromFiles(string filePath)
        {
            var files = Directory.GetFiles(filePath);
            Match match;
            foreach (var file in files)
            {
                match = new Match();
                using (var reader = new StreamReader(file))
                {
                    var firstLineOfFile = await reader.ReadLineAsync();
                    var playerReader = ResolvePlayerReader(firstLineOfFile);

                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        var player = await playerReader.ReadPlayerStatsFromAsync(line);
                        var teamName = line.Split(';')[3];
                        match.AddPlayer(teamName, player);
                    }
                    var players = match.ReturnPlayersMatchStats();
                    await _players.SavePlayersAsync(players);
                }
            }
        }

        private IPlayerReader ResolvePlayerReader(string readerUniqueuKey)
        {
            return _playerReaders.First(f => f.ReaderUniqueuKey == readerUniqueuKey);
        }
    }
}

using System.Collections.Concurrent;
using VavaCars.MVP.ConsoleApp.Domain;

namespace VavaCars.MVP.ConsoleApp.Persistence
{
    internal class PlayerRepository : IPlayerRepository
    {
        private readonly ConcurrentDictionary<string, PlayerBase> _players = new();

        public async Task SavePlayerAsync(PlayerBase player)
        {
            if (_players.ContainsKey(player.NickName))
                _players[player.NickName] = player;
            else
                _players.TryAdd(player.NickName, player);
            await Task.CompletedTask;
        }
        public async Task SavePlayersAsync(IList<PlayerBase> players)
        {
            foreach (PlayerBase player in players)
                await SavePlayerAsync(player);

            await Task.CompletedTask;
        }
        public async Task<PlayerBase> GetPlayerWithNicknameAsync(string nickname)
        {
            _players.TryGetValue(nickname, out var player);
            return await Task.FromResult(player);
        }

        public async Task<List<PlayerBase>> ListAllPlayersAsync()
        {
            return _players.Values.ToList();
        }

    }
}

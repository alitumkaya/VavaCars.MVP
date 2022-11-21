namespace VavaCars.MVP.ConsoleApp.Domain
{
    internal class Match
    {
        private readonly Dictionary<string, List<PlayerBase>> _players = new();

        public void AddPlayer(string teamName, PlayerBase player)
        {
            if (_players.ContainsKey(teamName))
                _players[teamName].Add(player);
            else
                _players.Add(teamName, new[] { player }.ToList());
        }
        internal IList<PlayerBase> ReturnPlayersMatchStats()
        {
            if (_players.Keys.Count != 2)
                throw new MatchTeamCountException();

            var teamsScoredPoints = _players.ToDictionary(
                k => k.Key,
                v => v.Value
                .Sum(s => s.GetRatingPoints())
                );

            var winnerTeam = teamsScoredPoints
                .OrderByDescending(o => o.Value)
                .FirstOrDefault();

            _players[winnerTeam.Key].ForEach(f => f.AddWinnerRaitingPoint());

            return _players
                .Values
                .SelectMany(s => s).ToList();
        }
    }
}

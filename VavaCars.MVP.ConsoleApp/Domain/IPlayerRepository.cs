namespace VavaCars.MVP.ConsoleApp.Domain
{
    internal interface IPlayerRepository
    {
        Task<PlayerBase> GetPlayerWithNicknameAsync(string nickname);
        Task<List<PlayerBase>> ListAllPlayersAsync();
        Task SavePlayerAsync(PlayerBase player);
        Task SavePlayersAsync(IList<PlayerBase> players);
    }
}

namespace VavaCars.MVP.ConsoleApp.Domain
{
    internal interface IPlayerReader
    {
        string ReaderUniqueuKey { get; }
        Task<PlayerBase> ReadPlayerStatsFromAsync(string line);
    }
}

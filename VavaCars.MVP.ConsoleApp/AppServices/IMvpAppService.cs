using VavaCars.MVP.ConsoleApp.Domain;

namespace VavaCars.MVP.ConsoleApp.AppServices
{
    internal interface IMvpAppService
    {
        Task ReadMatchStatsFromFiles(string filePath);
        Task<PlayerDto> FindMvp();
    }
}

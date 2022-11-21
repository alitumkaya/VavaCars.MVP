using Microsoft.Extensions.DependencyInjection;
using VavaCars.MVP.ConsoleApp.AppServices;
using VavaCars.MVP.ConsoleApp.Domain;
using VavaCars.MVP.ConsoleApp.Domain.Basketball;
using VavaCars.MVP.ConsoleApp.Domain.Handball;
using VavaCars.MVP.ConsoleApp.Persistence;
namespace VavaCars.MVP.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            AddServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var mvpAppService = serviceProvider.GetService<IMvpAppService>();
            try
            {

                await mvpAppService.ReadMatchStatsFromFiles("MatchFiles");
                var mvp = await mvpAppService.FindMvp();

                Console.WriteLine("Most Valuable Player information is;");
                Console.WriteLine($"Name : {mvp.PlayerName}");
                Console.WriteLine($"NickName : {mvp.NickName}");
                Console.WriteLine($"Raiting Points : {mvp.RatingPoints}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The files could not be processed because an error occurred during the process.");
                Console.WriteLine("You can see the error details below.");
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddServices(ServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
            services.AddScoped<IPlayerReader, BasketballPlayerReader>();
            services.AddScoped<IPlayerReader, HandballPlayerReader>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IMvpAppService, MvpAppService>();
        }
    }
}
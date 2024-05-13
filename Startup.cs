using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    internal static class Utils
    {
        public static string LogsDirectory { get; set; }
    }
    public static class Startup
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            DAL.Startup.RegisterServices(services, configuration);
            services.AddScoped<INotesService,NotesServices>();
        }
        public static void Start(string logsDir,
            string connectionString)
        {
            Utils.LogsDirectory = logsDir;
            DAL.Startup.StartApp(connectionString);
        }
    }
}
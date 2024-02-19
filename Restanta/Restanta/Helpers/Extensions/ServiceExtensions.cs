using Restanta.Repositories.ActoriFilmeRepository;
using Restanta.Repositories.ActorRepository;
using Restanta.Repositories.FilmRepository;
using Restanta.Services.ActoriFilmeService;
using Restanta.Services.ActorService;
using Restanta.Services.FilmService;

namespace Restanta.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddActorRepositories();
            services.AddFilmRepositories();
            services.AddActoriFilmeRepositories();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddActorServices();
            services.AddFilmServices();
            services.AddActoriFilmeServices();
        }

        public static IServiceCollection AddActorRepositories(this IServiceCollection services)
        {
            services.AddTransient<IActorRepository, ActorRepository>();
            return services;
        }

        public static IServiceCollection AddActorServices(this IServiceCollection services)
        {
            services.AddTransient<IActorService, ActorService>();
            return services;
        }

        public static IServiceCollection AddFilmRepositories(this IServiceCollection services)
        {
            services.AddTransient<IFilmRepository, FilmRepository>();
            return services;
        }

        public static IServiceCollection AddFilmServices(this IServiceCollection services)
        {
            services.AddTransient<IFilmService, FilmService>();
            return services;
        }

        public static IServiceCollection AddActoriFilmeRepositories(this IServiceCollection services)
        {
            services.AddTransient<IActoriFilmeRepository, ActoriFilmeRepository>();
            return services;
        }

        public static IServiceCollection AddActoriFilmeServices(this IServiceCollection services)
        {
            services.AddTransient<IActoriFilmeService, ActoriFilmeService>();
            return services;
        }

    }
}

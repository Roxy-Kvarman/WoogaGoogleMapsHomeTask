using Microsoft.Extensions.DependencyInjection;
using WoogaGoogleMapsHomeTask.Reports;

namespace WoogaGoogleMapsHomeTask.DependencyInjection
{
    /// <summary>
    /// Provides dependency injection configuration for test services
    /// </summary>
    public static class TestDependencyInjection
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Static constructor to initialize the service provider with configured services
        /// </summary>
        static TestDependencyInjection()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// This method configures the services to be registered with the dependency injection container
        /// </summary>
        /// <param name="services">The service collection to register services with</param>
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Reporter>();
        }
    }
}


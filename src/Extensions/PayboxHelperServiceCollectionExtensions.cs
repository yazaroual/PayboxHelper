using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;

using PayboxHelper.IO;

namespace PayboxHelper
{
    /// <summary>
    /// Extension method to register IPayboxService within the application
    /// </summary>
    public static class PayboxHelperServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Paybox service to the specified IServiceCollection
        /// </summary>
        /// <param name="services">Application IServiceCollection</param>
        /// <param name="payboxConfig">Provide a scoped IConfiguration instance with only Paybox configurations</param>
        /// <returns>The IServiceCollection so that additionnal calls can be chained</returns>
        public static IServiceCollection AddPayboxHelper(this IServiceCollection services, IConfiguration payboxConfig)
        {
            services.Configure<PayboxConfigOptions>(payboxConfig);
            services.AddScoped<IFileIOWrapper, FileIOWrapper>();
            services.AddScoped<IPayboxService, PayboxService>();

            return services;
        }
    }
}
using MCWrapper.CLI.Extensions;
using MCWrapper.CLI.Options;
using MCWrapper.Factory;
using MCWrapper.Ledger.Entities.Options;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;

namespace MCWrapper.Extensions
{
    /// <summary>
    /// Extension methods for adding both MCWrapper.CLI and MCWrapper.RPC client collections to an application's IServiceCollection dependency injection pipeline service container.
    /// </summary>
    public static class MultiChainCoreServices
    {
        /// <summary>
        /// Extension method for adding both MCWrapper.CLI and MCWrapper.RPC client collections to an application's IServiceCollection dependency injection pipeline service container.
        /// <para>RpcOptions, CliOptions, and RuntimeParamOptions are parsed from the local machine's environment variable store or Secret Manager.</para>
        /// </summary>
        /// <param name="services">Service collection comprised of various services</param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services)
        {
            services.AddMultiChainCoreCliServices();
            services.AddMultiChainCoreRpcServices();

            services.AddTransient<IMultiChainClientFactory, MultiChainClientFactory>();

            return services;
        }

        /// <summary>
        /// Extension method for adding both MCWrapper.CLI and MCWrapper.RPC client collections to an application's IServiceCollection dependency injection pipeline service container.
        /// <para>RpcOptions, CliOptions, and RuntimeParamOptions are parsed from the local IConfiguration pipeline passed via <paramref name="configuration"/> parameter.</para>
        /// </summary>
        /// <param name="services">Service collection comprised of various services</param>
        /// <param name="configuration">Configuration pipeline is used to access configuration files and Secret Manager</param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMultiChainCoreCliServices(configuration);
            services.AddMultiChainCoreRpcServices(configuration);

            services.AddTransient<IMultiChainClientFactory, MultiChainClientFactory>();

            return services;
        }

        /// <summary>
        /// Extension method for adding both MCWrapper.CLI and MCWrapper.RPC client collections to an application's IServiceCollection dependency injection pipeline service container.
        /// <para>RpcOptions, CliOptions, and RuntimeParamOptions are parsed from explicitily configured and passed via <paramref name="rpcOptions"/>, <paramref name="cliOptions"/>, and <paramref name="runtimeParamOptions"/> Action parameters.</para>
        /// </summary>
        /// <param name="services">Service collection comprised of various services</param>
        /// <param name="rpcOptions">JSON-RPC option values are used to configure blockchain clients</param>
        /// <param name="cliOptions">Command Line Interface options values are used to configure blockchain clients</param>
        /// <param name="runtimeParamOptions">Runtime parameters are used to configure the blockchain during runtime</param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services, Action<RpcOptions> rpcOptions, 
            Action<CliOptions> cliOptions, [Optional] Action<RuntimeParamOptions> runtimeParamOptions)
        {
            services.AddMultiChainCoreCliServices(cliOptions, runtimeParamOptions);
            services.AddMultiChainCoreRpcServices(rpcOptions, runtimeParamOptions);

            services.AddTransient<IMultiChainClientFactory, MultiChainClientFactory>();

            return services;
        }
    }
}
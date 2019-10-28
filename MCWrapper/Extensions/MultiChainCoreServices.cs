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
    /// Extension methods for adding both MCWrapper.CLI and MCWrapper.RPC client libraries to an application's service container.
    /// </summary>
    public static class MultiChainCoreServices
    {
        /// <summary>
        /// Add both MCWrapper.CLI and MCWrapper.RPC client libraries to an application service container.
        /// <para>RpcOptions, CliOptions, and RuntimeParamOptions are parsed from the local environment variable store.</para>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services)
        {
            services.AddMultiChainCoreCliServices();
            services.AddMultiChainCoreRPCServices();

            services.AddTransient<MCWrapperClientFactory>();

            return services;
        }

        /// <summary>
        /// Add both MCWrapper.CLI and MCWrapper.RPC client libraries to an application service container.
        /// <para>RpcOptions, CliOptions, and RuntimeParamOptions are parsed from the local IConfiguration pipeline.</para>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMultiChainCoreCliServices(configuration);
            services.AddMultiChainCoreRPCServices(configuration);

            services.AddTransient<MCWrapperClientFactory>();

            return services;
        }

        /// <summary>
        /// Add both MCWrapper.CLI and MCWrapper.RPC client libraries to an application service container.
        /// <para>RpcOptions, CliOptions, and RuntimeParamOptions are parsed from explicitily configured and passed Action parameters.</para>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="rpcOptions"></param>
        /// <param name="cliOptions"></param>
        /// <param name="runtimeParamOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services, Action<RpcOptions> rpcOptions, 
            Action<CliOptions> cliOptions, [Optional] Action<RuntimeParamOptions> runtimeParamOptions)
        {
            services.AddMultiChainCoreCliServices(cliOptions, runtimeParamOptions);
            services.AddMultiChainCoreRPCServices(rpcOptions, runtimeParamOptions);

            services.AddTransient<MCWrapperClientFactory>();

            return services;
        }
    }
}
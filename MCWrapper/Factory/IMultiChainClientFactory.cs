using MCWrapper.CLI.Ledger.Clients;
using MCWrapper.RPC.Ledger.Clients;

namespace MCWrapper.Factory
{
    /// <summary>
    /// MCWrapper MultiChain Core client factory
    /// </summary>
    public interface IMultiChainClientFactory
    {
        /// <summary>
        /// Supports all Command Line Interface-based clients
        /// </summary>
        IMultiChainCliClientFactory MultiChainCliClients { get; }

        /// <summary>
        /// Supports all JSON-RPC-based clients
        /// </summary>
        IMultiChainRpcClientFactory MultiChainRpcClients { get; }
    }
}
using MCWrapper.CLI.Ledger.Clients;
using MCWrapper.RPC.Ledger.Clients;

namespace MCWrapper.Factory
{
    /// <summary>
    /// MCWrapper client factory produces instances of the RpcClientFactory and the CliClientFactory
    /// </summary>
    public class MultiChainClientFactory : IMultiChainClientFactory
    {
        /// <summary>
        /// Create a new MCWrapperClientFactory instance
        /// </summary>
        /// <param name="multiChainRpcClientFactory"></param>
        /// <param name="multiChainCliClientFactory"></param>
        public MultiChainClientFactory(IMultiChainRpcClientFactory multiChainRpcClientFactory,
            IMultiChainCliClientFactory multiChainCliClientFactory)
        {
            _multiChainRpcClientFactory = multiChainRpcClientFactory;
            _multiChainCliClientFactory = multiChainCliClientFactory;
        }

        /// <summary>
        /// GET: MCWrapper Remote Procedure Call (RPC) client factory
        /// </summary>
        /// <returns></returns>
        public IMultiChainRpcClientFactory MultiChainRpcClients => _multiChainRpcClientFactory;
        private readonly IMultiChainRpcClientFactory _multiChainRpcClientFactory;

        /// <summary>
        /// GET: MCWrapper Command Line Interface (CLI) client factory
        /// </summary>
        /// <returns></returns>
        public IMultiChainCliClientFactory MultiChainCliClients => _multiChainCliClientFactory;
        private readonly IMultiChainCliClientFactory _multiChainCliClientFactory;
    }
}
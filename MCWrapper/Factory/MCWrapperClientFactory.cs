using MCWrapper.CLI.Ledger.Clients;
using MCWrapper.RPC.Ledger.Clients;

namespace MCWrapper.Factory
{
    /// <summary>
    /// MCWrapper client factory produces instances of the RpcClientFactory and the CliClientFactory
    /// </summary>
    public class MCWrapperClientFactory
    {
        /// <summary>
        /// Create a new MCWrapperClientFactory instance
        /// </summary>
        /// <param name="rpcClientFactory"></param>
        /// <param name="cliClientFactory"></param>
        public MCWrapperClientFactory(RpcClientFactory rpcClientFactory, CliClientFactory cliClientFactory)
        {
            RpcClientFactory = rpcClientFactory;
            CliClientFactory = cliClientFactory;
        }

        /// <summary>
        /// GET: MCWrapper Remote Procedure Call (RPC) client factory
        /// </summary>
        /// <returns></returns>
        public RpcClientFactory RpcClients => RpcClientFactory;
        private readonly RpcClientFactory RpcClientFactory;

        /// <summary>
        /// GET: MCWrapper Command Line Interface (CLI) client factory
        /// </summary>
        /// <returns></returns>
        public CliClientFactory CliClients => CliClientFactory;
        private readonly CliClientFactory CliClientFactory;
    }
}
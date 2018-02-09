using System;
using Amazon;
using Amazon.Runtime;
using Cuemon;
using Cuemon.Reflection;

namespace WBPA.Amazon.Runtime
{
    /// <summary>
    /// Provides a base-class for AWS implementations.
    /// </summary>
    /// <typeparam name="TClient">The type of the <see cref="AmazonServiceClient"/> to implement.</typeparam>
    /// <typeparam name="TConfig">The type of the <see cref="ClientConfig"/> to implement.</typeparam>
    /// <seealso cref="IDisposable" />
    public abstract class Manager<TClient, TConfig> : IDisposable 
        where TClient : AmazonServiceClient
        where TConfig : ClientConfig
    {
        private volatile bool _isDisposed;
        private readonly Lazy<TClient> _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager{TClient,TConfig}"/> class.
        /// </summary>
        /// <param name="credentials">The credentials used to authenticate with AWS.</param>
        /// <param name="regionEndpointParser">The function delegate that will resolve a <see cref="RegionEndpoint"/>.</param>
        /// <param name="setup">The <see cref="ManagerOptions"/> which need to be configured.</param>
        protected Manager(AWSCredentials credentials, Func<RegionEndpoint> regionEndpointParser, Action<ManagerOptions> setup = null)
        {
            Validator.ThrowIfNull(credentials, nameof(credentials));
            Validator.ThrowIfNull(regionEndpointParser, nameof(regionEndpointParser));
            var options = setup.ConfigureOptions();
            _client = new Lazy<TClient>(() =>
            {
                var config = Initializer.Create(ActivatorUtility.CreateInstance<TConfig>())
                    .IgnoreMissingMethod(c => c.RegionEndpoint = regionEndpointParser())
                    .IgnoreMissingMethod(c => c.AllowAutoRedirect = options.AllowAutoRedirect)
                    .IgnoreMissingMethod(c => c.ResignRetries = options.ResignRetries)
                    .IgnoreMissingMethod(c => c.AuthenticationRegion = options.AuthenticationRegion)
                    .IgnoreMissingMethod(c => c.AuthenticationServiceName = options.AuthenticationServiceName)
                    .IgnoreMissingMethod(c => c.BufferSize = options.BufferSize)
                    .IgnoreMissingMethod(c => c.DisableLogging = options.DisableLogging)
                    .IgnoreMissingMethod(c => c.LogMetrics = options.LogMetrics)
                    .IgnoreMissingMethod(c => c.MaxConnectionsPerServer = options.MaxConnectionsPerServer)
                    .IgnoreMissingMethod(c => c.LogResponse = options.LogResponse)
                    .IgnoreMissingMethod(c => c.MaxErrorRetry = options.MaxErrorRetry)
                    .IgnoreMissingMethod(c => c.ProgressUpdateInterval = options.ProgressUpdateInterval)
                    .IgnoreMissingMethod(c => c.ProxyCredentials = options.ProxyCredentials)
                    .IgnoreMissingMethod(c => c.ProxyHost = options.ProxyHost)
                    .IgnoreMissingMethod(c => c.ProxyPort = options.ProxyPort)
                    .IgnoreMissingMethod(c => c.SignatureMethod = options.SignatureMethod)
                    .IgnoreMissingMethod(c => c.ThrottleRetries = options.ThrottleRetries)
                    .IgnoreMissingMethod(c => c.Timeout = options.Timeout)
                    .IgnoreMissingMethod(c => c.UseDualstackEndpoint = options.UseDualStackEndpoint)
                    .IgnoreMissingMethod(c => c.UseHttp = options.UseHttp);
                return ActivatorUtility.CreateInstance<AWSCredentials, ClientConfig, TClient>(credentials, config.Instance);
            });
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed || !disposing) { return; }
            _isDisposed = true;
            Client?.Dispose();
        }

        /// <summary>
        /// Gets a reference to the configured <typeparamref name="TClient"/>.
        /// </summary>
        /// <value>The configured <typeparamref name="TClient"/>.</value>
        protected TClient Client => _client.Value;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
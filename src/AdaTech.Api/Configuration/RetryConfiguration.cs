using Polly.Retry;
using Polly;
using Polly.CircuitBreaker;

namespace AdaTech.Api.Configuration
{
    public static class RetryConfiguration
    {
        public static AsyncRetryPolicy<HttpResponseMessage> CreateRetryPolicy(int retryCount)
        {
            return Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .RetryAsync(retryCount, onRetry: (message, retryCount) =>
                {
                    string msg = $"Retentativa: {retryCount}";
                    Console.Out.WriteLineAsync(msg);
                });
        }

        
    }
}

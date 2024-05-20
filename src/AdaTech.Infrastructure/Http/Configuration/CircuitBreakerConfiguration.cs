using Polly.CircuitBreaker;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Infrastructure.Http.Configuration
{
    public static class CircuitBreakerConfiguration
    {
        public static AsyncCircuitBreakerPolicy CreateCircuitBreakerPolicy(
            int numberOfExceptionsBeforeBreaking,
            int durationOfBreakInSeconds)
        {
            return Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(
                    numberOfExceptionsBeforeBreaking,
                    TimeSpan.FromSeconds(durationOfBreakInSeconds),
                    onBreak: (_, _) =>
                    {

                    },
                    onReset: () =>
                    {

                    },
                    onHalfOpen: () =>
                    {

                    });
        }
    }
}

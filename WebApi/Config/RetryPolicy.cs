using System;
using System.Net.Http;
using Polly;
using Polly.Extensions.Http;

namespace WebApi.Config
{
    public class RetryPolicy
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                            .HandleTransientHttpError()
                            .OrTransientHttpStatusCode()
                            .WaitAndRetryAsync(3, (retryAttempt) =>
                            {
                                return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                            });
        }
    }
}

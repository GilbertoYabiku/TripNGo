using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polly;

namespace Infrastructure.Resilience
{
    public class ResilientExecutor<ExecutorType>
    {
        private readonly IEnumerable<IAsyncPolicy> _policies;

        public ResilientExecutor(IEnumerable<IAsyncPolicy> policies)
        {
            _policies = policies;
        }

        public Task<T> ExecuteAsync<T>(Func<Task<T>> action)
        {
            return Executor(async () =>
            {
                var response = await action.Invoke();
                return response;
            });
        }

        private async Task<T> Executor<T>(Func<Task<T>> action)
        {
            var policyWrap = Policy.WrapAsync(_policies.ToArray());
            return await policyWrap.ExecuteAsync(async () => await action());
        }
    } 
}
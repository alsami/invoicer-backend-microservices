using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Invoicer.Common.Handlers;

namespace Invoicer.Common
{
    public interface IQueryBus
    {
        Task<TResponse> Query<TRequest, TResponse>(TRequest query) where TRequest : IQuery<TResponse>;
    }
    public class QueryBus : IQueryBus
    {
        private Assembly ExecutingAssembly { get; set; }
        public QueryBus(Assembly assembly)
        {
            ExecutingAssembly = assembly;
        }

        public Task<TResponse> Query<TRequest, TResponse>(TRequest query) where TRequest : IQuery<TResponse>
        {
            using (var scope = ContainerConfigurator.GetInstance(ExecutingAssembly).Container.BeginLifetimeScope())
            {
                var handlers = scope.Resolve<IEnumerable<IQueryHandler<TRequest, TResponse>>>().ToList();
                if (handlers.Count == 1)
                {
                    return handlers[0].Handle(query);
                }
                else if (handlers.Count == 0)
                {
                    throw new Exception($"Query does not have any handler {query.GetType().Name}");
                }
                else
                {
                    throw new Exception($"Too many registred handlers - {handlers.Count} for Query {query.GetType().Name}");
                }
            }
        }
    }
}

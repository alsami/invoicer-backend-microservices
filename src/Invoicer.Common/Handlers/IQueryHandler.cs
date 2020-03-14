using System;
using System.Threading.Tasks;

namespace Invoicer.Common.Handlers
{
    public interface IQueryHandler
    {
    }
    public interface IQueryHandler<in TRequest, TResponse> where TRequest : IQuery<TResponse> {

        Task<TResponse> Handle(TRequest query);
    }
}

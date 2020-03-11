using System;
namespace Invoicer.Common.Handlers
{
    public interface IQueryHandler
    {
    }
    public interface IQueryHandler<T> : IQueryHandler where T : IQuery { }
}

using System;
namespace Invoicer.Common
{
    public interface IQueryBus
    {
        void Query<T>(T query) where T : IQuery;
    }
    public class QueryBus : IQueryBus
    {
        public QueryBus()
        {
        }

        public void Query<T>(T query) where T : IQuery
        {
            throw new NotImplementedException();
        }
    }
}

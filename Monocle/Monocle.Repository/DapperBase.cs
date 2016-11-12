using System;
using System.Data.Common;

namespace Monocle.Repository
{
    public abstract class DapperBase
    {
        protected abstract DbConnection OpenConnection();

        protected T Get<T>(Func<DbConnection, T> queryFunc)
        {
            using (var connection = OpenConnection())
            {
                return queryFunc(connection);
            }
        }

        protected int? Execute(Func<DbConnection, int?> queryFunc)
        {
            using (var connection = OpenConnection())
            {
                return queryFunc(connection);
            }
        }
    }
}

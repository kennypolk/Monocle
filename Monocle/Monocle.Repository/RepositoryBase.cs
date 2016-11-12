using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Monocle.Repository
{
    public class RepositoryBase : DapperBase
    {
        private readonly IRepositoryConfiguration _repositoryConfiguration;

        protected RepositoryBase(IRepositoryConfiguration repositoryConfiguration)
        {
            _repositoryConfiguration = repositoryConfiguration;
        }

        protected override DbConnection OpenConnection()
        {
            var connection = new SqlConnection(_repositoryConfiguration.ConnectionString);
            if (connection.State.Equals(ConnectionState.Open))
            {
                return connection;
            }

            connection.Open();

            return connection;
        }
    }
}

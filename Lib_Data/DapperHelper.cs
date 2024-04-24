using Dapper;
using Lib_Data.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Data
{
    public class DapperHelper : IDapperHelper
    {
        private readonly string connectionString = string.Empty;
        private IDbConnection _dbConnection; 
        public DapperHelper(IConfiguration configuration)

        {
            connectionString = configuration.GetConnectionString("OnionArchitecture");
            _dbConnection = new SqlConnection(connectionString);
        }

        public async Task ExcuteNotReturn(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = _dbConnection)
            {
               await dbConnection.ExecuteAsync(query, parameters, dbTransaction, commandType: CommandType.Text);
            }
        }

        public async Task<T1> ExecuteReturn<T1>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = _dbConnection)
            {
                var result = await dbConnection.ExecuteScalarAsync<T1>(query, parameters, dbTransaction, commandType: System.Data.CommandType.Text);
                return (T1)Convert.ChangeType(result, typeof(T1))!;
            }
        }

        public async Task<IEnumerable<T1>> ExcuteSqlReturnList<T1>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = _dbConnection)
            {
                return await dbConnection.QueryAsync<T1>(query,parameters,dbTransaction,commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<IEnumerable<T1>> ExcuteStoreProcedureReturnList<T1>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null)
        {
            using (var dbConnection = _dbConnection)
            {
                return await dbConnection.QueryAsync<T1>(query, parameters, dbTransaction, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

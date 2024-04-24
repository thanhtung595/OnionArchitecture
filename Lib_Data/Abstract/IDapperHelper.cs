using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Data.Abstract
{
    public interface IDapperHelper
    {
        Task ExcuteNotReturn(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
        Task<IEnumerable<T1>> ExcuteSqlReturnList<T1>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
        Task<IEnumerable<T1>> ExcuteStoreProcedureReturnList<T1>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
        Task<T1> ExecuteReturn<T1>(string query, DynamicParameters parameters = null, IDbTransaction dbTransaction = null);
    }
}

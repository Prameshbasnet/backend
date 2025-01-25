using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data.Data.Contracts
{
    public interface ISPDBContext
    {
        Task<IEnumerable<T>> GetDataAsync<T, P>(string sqlQuery, P parameters);

        Task<IEnumerable<T1>> GetAllDataAsync<T1, T2>(string query);

        Task<T> GetFirstResultAsync<T, P>(string sqlQuery, P parameters);

        Task<bool> ExecuteProcedureAsync<P>(string sqlQuery, P parameters);
    }
}

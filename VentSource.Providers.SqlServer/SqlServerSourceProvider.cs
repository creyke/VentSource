using System.Collections.Generic;
using System.Threading.Tasks;

namespace VentSource.Providers.SqlServer
{
    public class SqlServerSourceProvider : ISourceProvider
    {
        private readonly string connectionString;

        public SqlServerSourceProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<long> UpdateSourcesAsync(List<Source> sources)
        {
            return 0;
        }
    }
}

namespace VentSource.Providers.SqlServer
{
    public class SqlServerSourceProvider : ISourceProvider
    {
        private readonly string connectionString;

        public SqlServerSourceProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}

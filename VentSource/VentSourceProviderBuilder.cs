namespace VentSource
{
    public class VentSourceProviderBuilder
    {
        private readonly VentBuilder ventBuilder;

        public VentSourceProviderBuilder(VentBuilder ventBuilder)
        {
            this.ventBuilder = ventBuilder;
        }

        public VentSourceProviderBuilder AddSource<TSourceType>()
        {
            return AddSource<TSourceType>($"{typeof(TSourceType).Name}s");
        }

        public VentSourceProviderBuilder AddSource<TSourceType>(string tableName)
        {
            return this;
        }

        public VentBuilder BuildSourceProvider()
        {
            return ventBuilder;
        }
    }
}

namespace VentSource
{
    public class VentSourceProviderBuilder
    {
        private readonly VentBuilder ventBuilder;
        private readonly ISourceProvider sourceProvider;

        public VentSourceProviderBuilder(VentBuilder ventBuilder, ISourceProvider sourceProvider)
        {
            this.ventBuilder = ventBuilder;
            this.sourceProvider = sourceProvider;
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

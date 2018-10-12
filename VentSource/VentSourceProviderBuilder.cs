namespace VentSource
{
    public class VentSourceProviderBuilder
    {
        private readonly VentBuilder ventBuilder;
        private readonly SourceProviderHost sourceProviderHost;

        public VentSourceProviderBuilder(VentBuilder ventBuilder, SourceProviderHost sourceProviderHost)
        {
            this.ventBuilder = ventBuilder;
            this.sourceProviderHost = sourceProviderHost;
        }

        public VentSourceProviderBuilder AddSource<TSourceType>()
        {
            return AddSource<TSourceType>($"{typeof(TSourceType).Name}s");
        }

        public VentSourceProviderBuilder AddSource<TSourceType>(string tableName)
        {
            sourceProviderHost.AddSource(new Source<TSourceType>(tableName));
            return this;
        }

        public VentBuilder BuildSourceProvider()
        {
            return ventBuilder;
        }
    }
}

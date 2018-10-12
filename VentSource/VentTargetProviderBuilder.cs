namespace VentSource
{
    public class VentTargetProviderBuilder
    {
        private readonly VentBuilder ventBuilder;

        public VentTargetProviderBuilder(VentBuilder ventBuilder)
        {
            this.ventBuilder = ventBuilder;
        }

        public VentBuilder BuildTargetProvider()
        {
            return ventBuilder;
        }
    }
}

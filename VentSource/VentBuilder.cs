using System;

namespace VentSource
{
    public class VentBuilder
    {
        private readonly Vent vent;

        public VentBuilder()
        {
            vent = new Vent();
        }

        public VentSourceProviderBuilder AddSourceProvider(ISourceProvider sourceProvider)
        {
            return new VentSourceProviderBuilder(this);
        }

        public Vent Build()
        {
            return vent;
        }

        public VentTargetProviderBuilder AddTargetProvider(ITargetProvider targetProvider)
        {
            return new VentTargetProviderBuilder(this);
        }
    }
}

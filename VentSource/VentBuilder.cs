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

        public VentBuilder SetWatermarkProvider(IWatermarkProvider watermarkProvider)
        {
            vent.SetWatermarkProvider(watermarkProvider);
            return this;
        }

        public VentSourceProviderBuilder AddSourceProvider(ISourceProvider sourceProvider)
        {
            var sourceProviderHost = new SourceProviderHost(sourceProvider);
            vent.AddSourceProviderHost(sourceProviderHost);
            return new VentSourceProviderBuilder(this, sourceProviderHost);
        }

        public VentTargetProviderBuilder AddTargetProvider(ITargetProvider targetProvider)
        {
            return new VentTargetProviderBuilder(this);
        }

        public IVent Build()
        {
            return vent;
        }
    }
}

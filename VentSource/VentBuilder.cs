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
            vent.AddSourceProvider(sourceProvider);
            return new VentSourceProviderBuilder(this, sourceProvider);
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VentSource
{
    public class SourceProviderHost
    {
        private readonly ISourceProvider sourceProvider;
        private List<Source> sources;

        public SourceProviderHost(ISourceProvider sourceProvider)
        {
            this.sourceProvider = sourceProvider;
            sources = new List<Source>();
        }

        public void AddSource(Source source)
        {
            sources.Add(source);
        }

        public async Task UpdateAsync(ProviderWatermark providerWatermark)
        {
            providerWatermark.Version = await sourceProvider.UpdateSourcesAsync(sources);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace VentSource
{
    public class Vent : IVent
    {
        private List<ISourceProvider> sourceProviders;
        private IWatermarkProvider watermarkProvider;
        private Watermark watermark;

        public Vent()
        {
            sourceProviders = new List<ISourceProvider>();
        }

        public void AddSourceProvider(ISourceProvider sourceProvider)
        {
            sourceProviders.Add(sourceProvider);
        }

        public void SetWatermarkProvider(IWatermarkProvider watermarkProvider)
        {
            this.watermarkProvider = watermarkProvider;
        }

        public async Task StreamAsync()
        {
            do
            {
                await LoopAsync();
                await Task.Delay(2 * 1000);
            }
            while (true);
        }

        private async Task LoopAsync()
        {
            await ReadWatermarkAsync();
            await UpdateAsync();
            await WriteWatermarkAsync();
        }

        private async Task ReadWatermarkAsync()
        {
            if (watermark != null)
            {
                return;
            }

            watermark = await watermarkProvider.ReadAsync();
        }

        private async Task UpdateAsync()
        {
            foreach (var sourceProvider in sourceProviders)
            {
                await UpdateProviderAsync(sourceProvider);
            }
        }

        private async Task UpdateProviderAsync(ISourceProvider sourceProvider)
        {

        }

        private async Task WriteWatermarkAsync()
        {
            await watermarkProvider.WriteAsync(watermark);
        }
    }
}

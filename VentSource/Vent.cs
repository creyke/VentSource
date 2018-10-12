using System.Collections.Generic;
using System.Threading.Tasks;

namespace VentSource
{
    public class Vent : IVent
    {
        private List<SourceProviderHost> sourceProviderHosts;
        private IWatermarkProvider watermarkProvider;
        private Watermark currentWatermark;

        public Vent()
        {
            sourceProviderHosts = new List<SourceProviderHost>();
        }

        public void SetWatermarkProvider(IWatermarkProvider watermarkProvider)
        {
            this.watermarkProvider = watermarkProvider;
        }

        public async Task StreamAsync()
        {
            await ReadWatermarkAsync();

            do
            {
                await LoopAsync();
                await Task.Delay(2 * 1000);
            }
            while (true);
        }

        public void AddSourceProviderHost(SourceProviderHost sourceProviderHost)
        {
            sourceProviderHosts.Add(sourceProviderHost);
        }

        private async Task LoopAsync()
        {
            await UpdateAsync();
        }

        private async Task ReadWatermarkAsync()
        {
            if (currentWatermark != null)
            {
                return;
            }

            currentWatermark = await watermarkProvider.ReadAsync();

            if (currentWatermark.ProviderWatermarks == null)
            {
                currentWatermark.ProviderWatermarks = new List<ProviderWatermark>();
            }

            while (currentWatermark.ProviderWatermarks.Count < sourceProviderHosts.Count)
            {
                currentWatermark.ProviderWatermarks.Add(new ProviderWatermark());
            }
        }

        private async Task UpdateAsync()
        {
            var watermark = currentWatermark.Clone();

            for (int i = 0; i < sourceProviderHosts.Count; i++)
            {
                await UpdateProviderAsync(sourceProviderHosts[i], i, watermark);
            }

            await WriteWatermarkAsync(watermark);
        }

        private async Task UpdateProviderAsync(SourceProviderHost sourceProviderHost, int providerId, Watermark nextWatermark)
        {
            await sourceProviderHost.UpdateAsync(nextWatermark.ProviderWatermarks[providerId]);
        }

        private async Task WriteWatermarkAsync(Watermark watermark)
        {
            await watermarkProvider.WriteAsync(watermark);
        }
    }
}

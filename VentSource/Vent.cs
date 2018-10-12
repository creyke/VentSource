using System.Collections.Generic;
using System.Threading.Tasks;

namespace VentSource
{
    public class Vent : IVent
    {
        private List<SourceProviderHost> sourceProviderHosts;
        private IWatermarkProvider watermarkProvider;
        private Watermark watermark;

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
            for (int i = 0; i < sourceProviderHosts.Count; i++)
            {
                await UpdateProviderAsync(sourceProviderHosts[i], i);
            }
        }

        private async Task UpdateProviderAsync(SourceProviderHost sourceProviderHost, int providerId)
        {
            if (watermark.ProviderWatermarks == null)
            {
                watermark.ProviderWatermarks = new List<ProviderWatermark>();
            }

            if (watermark.ProviderWatermarks.Count <= providerId)
            {
                watermark.ProviderWatermarks.Add(new ProviderWatermark());
            }

            await sourceProviderHost.UpdateAsync(watermark.ProviderWatermarks[providerId]);
        }

        private async Task WriteWatermarkAsync()
        {
            await watermarkProvider.WriteAsync(watermark);
        }
    }
}

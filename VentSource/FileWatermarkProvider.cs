using System.Threading.Tasks;

namespace VentSource
{
    public class FileWatermarkProvider : IWatermarkProvider
    {
        public Task<Watermark> ReadAsync()
        {
            return Task.FromResult(new Watermark());
        }

        public Task WriteAsync(Watermark watermark)
        {
            return Task.CompletedTask;
        }
    }
}

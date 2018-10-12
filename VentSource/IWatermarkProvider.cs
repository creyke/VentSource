using System.Threading.Tasks;

namespace VentSource
{
    public interface IWatermarkProvider
    {
        Task<Watermark> ReadAsync();
        Task WriteAsync(Watermark watermark);
    }
}

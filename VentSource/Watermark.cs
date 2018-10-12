using System.Collections.Generic;
using System.Linq;

namespace VentSource
{
    public class Watermark
    {
        public List<ProviderWatermark> ProviderWatermarks { get; set; }

        public Watermark Clone()
        {
            return new Watermark
            {
                ProviderWatermarks = ProviderWatermarks.Select(x => new ProviderWatermark
                {
                    Version = x.Version
                }).ToList()
            };
        }
    }
}

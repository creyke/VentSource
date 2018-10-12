namespace VentSource
{
    public class VentEvent<T>
    {
        public T Delta { get; set; }
        public long TotalVersion { get; set; }
        public long Version { get; set; }
    }
}

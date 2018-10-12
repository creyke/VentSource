namespace VentSource
{
    public class Source
    {
    }

    public class Source<TSourceType> : Source
    {
        private readonly string tableName;

        public Source(string tableName)
        {
            this.tableName = tableName;
        }
    }
}
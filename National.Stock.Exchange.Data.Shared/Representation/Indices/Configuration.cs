namespace National.Stock.Exchange.Data.Shared.Representation.Indices
{
    public class Configuration
    {
        public Configuration(long period, int header)
        {
            Period = period;
            Header = header;
        }

        public long Period { get; private set; }
        public int Header { get; private set; }

    }
}
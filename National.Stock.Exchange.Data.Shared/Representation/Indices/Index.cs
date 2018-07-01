namespace National.Stock.Exchange.Data.Shared.Representation.Indices
{
    public class Index
    {
        public static Symbol Nifty50 => new Symbol("NIFTY 50", "NIFTY 50", new Category("Broad Market Indices"), new Configuration(100,3));
        public static Symbol NiftyAAACorporateBond => new Symbol("NIFTY AAA Corporate Bond", "NIFTY AAA Corporate Bond", new Category("Corporate Bond Indices"), new Configuration(100, 3));
    }
}
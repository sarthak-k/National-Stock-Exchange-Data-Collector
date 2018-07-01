using System;

namespace National.Stock.Exchange.Data.Shared.Representation.Indices
{
    public class Symbol
    {
        internal Symbol(string name, string value, Category category, Configuration configuration)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));

            Name = name;
            Value = value;
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public Category Category { get; set; }
        public Configuration Configuration { get; set; }

    }
}
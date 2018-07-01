using System;

namespace National.Stock.Exchange.Data.Shared.Representation.Indices
{
    public class Category
    {
        public Category(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));
            }

            Description = description;
        }

        public string Description { get; set; }
    }
}
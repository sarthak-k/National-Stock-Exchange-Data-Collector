using System;
using National.Stock.Exchange.Data.Shared.Representation.Indices;

namespace National.Stock.Exchange.Data.Shared.Model.Request
{
    public class RequestForIndexInformation
    {
        public RequestForIndexInformation(Symbol symbol, DateTime start, DateTime end)
        {
            if (end < start)
            {
                throw new ArgumentException("End Date Should Be Less Than Start Date");
            }

            Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
            Start = start;
            End = end;
        }

        public Symbol Symbol { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
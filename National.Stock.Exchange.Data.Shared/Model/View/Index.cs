using System;

namespace National.Stock.Exchange.Data.Shared.Model.View
{
    public class Index
    {
        public Index(DateTime date, decimal? open, decimal? high, decimal? low, decimal? close, long? quantity, decimal? turnover)
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Quantity = quantity;
            Turnover = turnover;
        }

        public Index(string date, string open, string high, string low, string close, string quantity, string turnover)
        {
            Date = DateTime.Parse(date);

            try
            {
                Open = decimal.Parse(open);
            }
            catch (Exception)
            {
                Open = null;
            };

            try
            {
                High = decimal.Parse(high);
            }
            catch (Exception)
            {
                High = null;
            };


            try
            {
                Low = decimal.Parse(low);
            }
            catch (Exception)
            {
                Low = null;
            };

            try
            {
                Close = decimal.Parse(close);
            }
            catch (Exception)
            {
                Close = null;
            };

            try
            {
                Quantity = long.Parse(quantity);
            }
            catch (Exception)
            {
                Quantity = null;
            };

            try
            {
                Turnover = long.Parse(turnover);
            }
            catch (Exception)
            {
                Turnover = null;
            };

        }

        public DateTime Date { get; set; }
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? Close { get; set; }
        public long? Quantity { get; set; }
        public decimal? Turnover { get; set; }

    }
}
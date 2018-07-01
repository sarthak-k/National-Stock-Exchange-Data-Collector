using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using National.Stock.Exchange.Data.Shared.Model.Request;
using National.Stock.Exchange.Data.Shared.Model.View;

namespace National.Stock.Exchange.Data.Business.Indices
{
    public class History
    {
        public History(RequestForIndexInformation requestForIndexInformation)
        {
            RequestForIndexInformation = requestForIndexInformation ?? throw new ArgumentNullException(nameof(requestForIndexInformation));
        }

        public RequestForIndexInformation RequestForIndexInformation { get; set; }

        public List<Index> Get()
        {
            if (RequestForIndexInformation.End.Subtract(RequestForIndexInformation.Start).Days > RequestForIndexInformation.Symbol.Configuration.Period)
            {
                var history = new List<Index>();

                while (RequestForIndexInformation.Start < RequestForIndexInformation.End)
                {
                    var difference = RequestForIndexInformation.End.Subtract(RequestForIndexInformation.Start).Days;

                    var end = difference > RequestForIndexInformation.Symbol.Configuration.Period ? RequestForIndexInformation.Start.AddDays(RequestForIndexInformation.Symbol.Configuration.Period) : RequestForIndexInformation.End;

                    history.AddRange(Retrieve(RequestForIndexInformation.Start, end));

                    RequestForIndexInformation.Start = RequestForIndexInformation.Start.AddDays(difference > RequestForIndexInformation.Symbol.Configuration.Period ? RequestForIndexInformation.Symbol.Configuration.Period : difference).AddDays(1);
                }

                return history;
            }
            else
            {
                return Retrieve(RequestForIndexInformation.Start, RequestForIndexInformation.End);
            }

        }

        private List<Index> Retrieve(DateTime start, DateTime end)
        {
            var webClient = new WebClient
            {
                Headers = new WebHeaderCollection()
                {
                    {HttpRequestHeader.Host,"www.nseindia.com" },
                    {HttpRequestHeader.Referer,"https://www.nseindia.com/products/content/equities/equities/eq_security.htm" }
                }
            };

            var page = webClient.DownloadString(
                $"https://www.nseindia.com/products/dynaContent/equities/indices/historicalindices.jsp?indexType={RequestForIndexInformation.Symbol.Value}&fromDate={start:dd-MM-yyyy}&toDate={end:dd-MM-yyyy}");

            var doc = new HtmlDocument();

            doc.LoadHtml(page);

            var table = doc.DocumentNode.SelectSingleNode("table")
                .Descendants("tr")
                .Skip(RequestForIndexInformation.Symbol.Configuration.Header)
                .Where(tr => tr.Elements("td").Count() == 7)
                .Select(tr => new Index(tr.Elements("td").ElementAt(0).InnerText,
                    tr.Elements("td").ElementAt(1).InnerText.Replace(",", ""),
                    tr.Elements("td").ElementAt(2).InnerText.Replace(",", ""),
                    tr.Elements("td").ElementAt(3).InnerText.Replace(",", ""),
                    tr.Elements("td").ElementAt(4).InnerText.Replace(",", ""),
                    tr.Elements("td").ElementAt(5).InnerText.Replace(",", ""),
                    tr.Elements("td").ElementAt(6).InnerText.Replace(",", "")))
                .ToList();

            return table;
        }
    }
}

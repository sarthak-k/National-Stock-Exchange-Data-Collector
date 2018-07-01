using System;
using National.Stock.Exchange.Data.Business.Indices;
using National.Stock.Exchange.Data.Shared.Model.Request;
using National.Stock.Exchange.Data.Shared.Representation.Indices;
using Xunit;

namespace National.Stock.Exchange.Data.Tests.Business.Indices
{
    public class HistoryTests
    {
        [Fact]
        public void Nifty50HistoryShouldExactCountAsExpected()
        {
            var start = new DateTime(2017, 04, 01);
            var end = start.AddDays(364);
            var requestInformation = new RequestForIndexInformation(Index.Nifty50, start, end);
            var history = new History(requestInformation).Get();
            Assert.Equal(246, history.Count);
        }

        [Fact]
        public void Nifty50HistoryShouldQueryDirectInCaseOfLessThanConfigurationPeriod()
        {
            var start = new DateTime(2017, 04, 01);
            var end = start.AddDays(50);
            var requestInformation = new RequestForIndexInformation(Index.Nifty50, start, end);
            var history = new History(requestInformation).Get();
            Assert.Equal(32, history.Count);
        }

        [Fact]
        public void NiftyAaaCorporateBondHistoryShouldQueryDirectInCaseOfLessThanConfigurationPeriod()
        {
            var start = new DateTime(2017, 04, 01);
            var end = start.AddDays(50);
            var requestInformation = new RequestForIndexInformation(Index.NiftyAAACorporateBond, start, end);
            var history = new History(requestInformation).Get();
            Assert.Equal(51, history.Count);
        }

        [Fact]
        public void HistoryShouldThrowExceptionWhenRequestIndexInformationIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var history = new History(null);
            });
        }
        

        [Fact]
        public void RequestForIndexInformationShouldNotAcceptEndDateGreaterThanStartDate()
        {
            var start = new DateTime(2017, 04, 01);
            var end = start.AddDays(-364);
            Assert.Throws<ArgumentException>(() =>
            {
                var requestForIndexInformation = new RequestForIndexInformation(Index.Nifty50, start, end);
            });
        }
    }
}
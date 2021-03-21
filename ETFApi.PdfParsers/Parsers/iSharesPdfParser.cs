using System;
using System.Collections.Generic;
using ETFApi.Domain.Entities;

namespace ETFApi.PdfParsers.Parsers
{
    public class iSharesPdfParser : PdfParser
    {
        public iSharesPdfParser(byte[] pdfBytes) : base(pdfBytes)
        {
        }

        protected override List<KeyValuePair<string, (string, string)>> ContentParts { get; set; } = new()
        {
            new KeyValuePair<string, (string, string)>("Performance", ("12 MONTH PERFORMANCE PERIODS (% EUR)", "ANNUALISED PERFORMANCE (% EUR)")),
            new KeyValuePair<string, (string, string)>("AnnualisedPerformance", ("ANNUALISED PERFORMANCE (% EUR)", "The figures shown")),
            new KeyValuePair<string, (string, string)>("KeyFacts", ("KEY FACTS", "TOP HOLDINGS (%)")),
            new KeyValuePair<string, (string, string)>("TopHoldings", ("TOP HOLDINGS (%)", "Holdings are subject to change")),
            new KeyValuePair<string, (string, string)>("PortfolioCharacteristics", ("PORTFOLIO CHARACTERISTICS", "DEALING INFORMATION")),
            new KeyValuePair<string, (string, string)>("DealingInformation", ("DEALING INFORMATION", "GEOGRAPHIC BREAKDOWN")),
        };

        private protected override Etf ParseContentToEtfObject()
        {
            throw new NotImplementedException();
        }
    }
}
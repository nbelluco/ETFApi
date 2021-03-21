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
            return new Etf
            {
                FundPerformances = ExtractPerformanceValues()
            };
        }

        private List<FundPerformanceValue> ExtractPerformanceValues()
        {
            var performances = new List<FundPerformanceValue>();
            
            var performanceSpan = ContentPairs["Performance"].AsSpan();
            
            var fundIndex = performanceSpan.IndexOf("Fund");
            var benchmarkIndex = performanceSpan.IndexOf("Benchmark");

            var fundSpan = performanceSpan
                .Slice(fundIndex + 4, benchmarkIndex - fundIndex - 4);
            
            var benchmarkSpan = performanceSpan
                .Slice(benchmarkIndex + 9);

            var periodsSpan = performanceSpan.Slice(0, fundIndex);

            var periods = new List<string>
            {
                periodsSpan.Slice(0, 23).ToString(),
                periodsSpan.Slice(24, 23).ToString(),
                periodsSpan.Slice(47, 23).ToString(),
                periodsSpan.Slice(71, 23).ToString(),
                periodsSpan.Slice(95, 23).ToString(),
                periodsSpan.Slice(109).ToString(),
            };

            var fundPerformances = ExtractPerformanceRow(fundSpan);
            var benchmarkPerformances = ExtractPerformanceRow(benchmarkSpan);
            
            for (int i = 0; i < periods.Count; i++)
            {
                performances.Add(new FundPerformanceValue
                {
                    Period = periods[i],
                    Performance = fundPerformances[i],
                    BenchmarkPerformance = benchmarkPerformances[i]
                });
            }

            return performances;
        }

        private List<string> ExtractAnnualisedPerformanceValues()
        {
            var performances = new List<string>();
            return performances;
        }

        private List<string> ExtractPerformanceRow(ReadOnlySpan<char> span)
        {
            var charIndex = 0;
            var lastFoundIndex = 0;
            
            var performanceRow = new List<string>();
            
            while (charIndex < span.Length)
            {
                switch (span[charIndex])
                {
                    case 'N':
                        performanceRow.Add("N/A");
                        lastFoundIndex = charIndex += 3;
                        charIndex += 3;
                        break;
                    case '%':
                        performanceRow.Add(
                            span
                                .Slice(lastFoundIndex, charIndex - lastFoundIndex)
                                .ToString()
                        );
                        break;
                    default:
                        charIndex += 1;
                        break;
                }
            }

            return performanceRow;
        }
    }
}
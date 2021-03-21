using System;
using System.Collections.Generic;

namespace ETFApi.Domain.Entities
{
    public class Etf : BaseEntity
    {
        public string Name { get; set; }
        public string ISIN { get; set; }
        public string WKN { get; set; }
        public string Ticker { get; set; }
        public string Benchmark { get; set; }
        public string BenchmarkTicker { get; set; }
        
        // Characteristics
        
        public short StocksNumber { get; set; } // TODO: controllare nome (NumberOfHoldings, NumberOfShares)
        public double MedianMarketCap { get; set; }
        public double PriceEarningsRatio { get; set; }
        public double PriceBookRatio { get; set; }
        public double ReturnOnEquity { get; set; }
        public double EarningsGrowthRate { get; set; }
        public double TurnoverRate { get; set; }
        public double EquityYield { get; set; }
        public string AssetClass { get; set; }
        public string RebalanceFrequency { get; set; }
        
        // Risk
        
        public double FundSize { get; set; } // TODO: controllare se meglio chiarmarlo NetAssetValue
        public string Replication { get; set; }
        public string LegalStructure { get; set; }
        public string StrategyRisk { get; set; }
        public string FundCurrency { get; set; }
        public string CurrencyRisk { get; set; }
        public double VolatilityIn1Year { get; set; }
        public DateTime ListingDate { get; set; } // TODO: controllare se meglio chiarmala FundLaunch
        
        // Fees

        public int MinimumInvestment { get; set; }
        public double Ter { get; set; }
        public string DistributionPolicy { get; set; }
        public string TaxData { get; set; }
        public string FundDomicile { get; set; }

        #nullable enable
        public string? DistributionFrequency { get; set; }
        #nullable disable

        
        // Legal Structure

        public string FundStructure { get; set; }
        public bool UCITSCompliant { get; set; }
        public bool ISACompliant { get; set; }
        public bool SIPPCompliant  { get; set; }
        public string Provider { get; set; }
        public string Administrator { get; set; }

        #nullable enable
        public string? InvestmentAdvisor { get; set; } // TODO: controllare se corrisponde con Investment Manager di Vanguard
        #nullable disable

        public string RevisionCompany { get; set; } // TODO: controllare se meglio chiarmarlo IndipendentAuditor
        public string SwissRepresentative { get; set; }
        public string SwissPayingAgent { get; set; }

        // Tax status

        public string Switzerland { get; set; }
        public string Austria { get; set; }
        public string UnitedKingdom { get; set; }
        
        // Replication, swap, securities lending

        public string IndexType { get; set; }
        public bool SecuritiesLending { get; set; }
        
        #nullable enable
        public string? SwapCounterparty { get; set; }
        public string? CollateralManager { get; set; }
        public string? SecuritiesLendingCounterparty { get; set; }
        #nullable disable

        public List<Listing> ExchangeListings { get; set; }
        public List<Holding> TopTenHoldings { get; set; }
        
        // TODO check if annualised performances required separated property
        public List<FundPerformanceValue> FundPerformances { get; set; }
    }
}
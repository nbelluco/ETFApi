namespace ETFApi.Domain.Entities
{
    public class Listing : BaseEntity
    {
        public string Name { get; set; }
        public string TradeCurrency { get; set; }
        public string ExchangeTicker { get; set; }
        public bool? Distribution { get; set; }
        
        #nullable enable
        public string? SEDOLCode { get; set; }
        public string? BloombergCode { get; set; }
        public string? BloombergiNavCode { get; set; }
        public string? ReutersCode { get; set; }
        public string? ValorenCode { get; set; }
        #nullable disable

        public string MarketMaker { get; set; }
    }
}
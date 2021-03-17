namespace ETFApi.Domain.Entities
{
    public class FundPerformanceValue : BaseEntity
    {
        public string Period { get; set; }
        public string Performance { get; set; }
        public string BenchmarkPerformance { get; set; }
    }
}
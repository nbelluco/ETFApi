namespace ETFApi.Domain.Entities
{
    public class SectorBreakdown : BaseEntity
    {
        public string Name { get; set; }
        public double Percentages { get; set; }
    }
}
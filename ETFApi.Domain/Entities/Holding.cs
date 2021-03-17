namespace ETFApi.Domain.Entities
{
    public class Holding : BaseEntity
    {
        public string Name { get; set; }
        public double Percentages { get; set; }
    }
}
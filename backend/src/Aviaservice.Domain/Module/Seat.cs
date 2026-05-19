namespace Aviaservice.Domain.Module
{
    public class Seat
    {
        public string SeatNumber { get; set; }
        public Enum Class { get; set; }
        public bool IsAvailable { get; set; }
        public decimal PriceModifier { get; set; }
    }
}
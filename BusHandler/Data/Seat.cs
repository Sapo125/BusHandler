namespace BusHandler.Data
{
    public class Seat
    {
        public int SeatId { get; set; }
        public required string Code { get; set; }
        public List<Reservations>? Reservations { get; set; }
    }
}

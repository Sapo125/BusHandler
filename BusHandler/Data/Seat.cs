namespace BusHandler.Data
{
    public class Seat
    {
        public int SeatId { get; set; }
        public required string Code { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}

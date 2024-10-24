using Microsoft.EntityFrameworkCore;

namespace BusHandler.Data
{
    [PrimaryKey(nameof(ChildrenId), nameof(SeatId))]
    public class Reservation
    {
        public int ChildrenId { get; set; }
        public int SeatId { get; set; }
        public DateOnly Date { get; set; }
        public bool IsMorning;
    }
}

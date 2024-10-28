using System.ComponentModel.DataAnnotations.Schema;

namespace BusHandler.Data
{
    public class Children
    {
        public int ChildrenId { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public int FamilyUserId { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}

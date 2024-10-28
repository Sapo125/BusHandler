using System.ComponentModel.DataAnnotations.Schema;

namespace BusHandler.Data
{
    public class Children
    {
        public int ChildrenId { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        [ForeignKey("FamilyUser")]
        public string? FamilyUserId { get; set; }
        public FamilyUser? FamilyUser { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}

using System;
using BusHandler.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly BusDbContext _ctx;

        public ReservationController(BusDbContext context)
        {
            _ctx = context;
        }

        [HttpDelete("{childrenId}/{seatId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReservation(int childrenId, int seatId)
        {
            var res = await _ctx.Reservations.FirstOrDefaultAsync(r => r.ChildrenId == childrenId && r.SeatId == seatId);

            if (res == null)
            {
                return NotFound("Reservation not found.");
            }

            _ctx.Reservations.Remove(res);
            await _ctx.SaveChangesAsync();

            return Ok("Reservation deleted successfully.");
        }
    }
}

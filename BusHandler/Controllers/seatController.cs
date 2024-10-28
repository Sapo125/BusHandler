using BusHandler.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace BusHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class seatController : ControllerBase
    {
        private readonly BusDbContext _ctx;
        public seatController(BusDbContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [Route("GetSeatsByDate/{date}")]
        public async Task<IActionResult> GetSeatsByDate(DateOnly date) 
        {
            var boolean = await _ctx.Seats.Select(s => s.Reservations.Where(r=>r.Date==date)).ToListAsync();
            if (boolean.Any())
            {
                return Ok(boolean);
            }
            else
            {
                //post con prenotazione di account privilegiati
                var priviligedUsers=_ctx.Users.Take(28).ToList();//temporaneo
                int i = 0;
                List<Reservation> reservations = new List<Reservation>();
                priviligedUsers.ForEach(p => p.Childrens.ForEach(c =>
                {
                    reservations.Add(new Reservation
                    {
                        ChildrenId = c.Id,
                        SeatId = i,
                        Date = date,
                        IsMorning = true
                    });
                    reservations.Add(new Reservation
                    {
                        ChildrenId = c.Id,
                        SeatId = i,
                        Date = date,
                        IsMorning = false
                    });
                    i++;
                }));
                _ctx.Reservations.AddRange(reservations);
                return Ok(reservations);    
            }
        }
    }
}   

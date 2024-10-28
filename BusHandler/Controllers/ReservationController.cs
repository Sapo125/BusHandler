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

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllForFamily([FromRoute]int familyUserId)
        {
            // Recupero i figli della famiglia e le loro prenotazioni
            var reservations = await _ctx.Childrens
                .Where(child => child.FamilyUserId == familyUserId)
                .Select(child => new
                {
                    child.Name,
                    child.Surname,
                    Reservations = child.Reservations.Select(reservation => new
                    {
                        reservation.Seat.Code,
                        reservation.Date
                    }).ToList()
                })
                .ToListAsync();

            if (reservations == null || reservations.Count() == 0)
                return NotFound("Nessuna prenotazione trovata per la famiglia.");

            return Ok(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] int childrenId, DateOnly date, bool isMorning)
        {
            // Verifico se il bambino esiste
            var child = await _ctx.Childrens.FindAsync(childrenId);
            if (child == null)
                return NotFound("Bambino non trovato.");

            // Verifico la disponibilità di un posto per la data e il turno specificati
            var existingReservations = await _ctx.Reservations
                .Where(r => r.Date == date && r.IsMorning == isMorning)
                .ToListAsync();

            // Trova un posto libero
            var availableSeat = await _ctx.Seats
                .FirstOrDefaultAsync(seat => !existingReservations.Any(r => r.SeatId == seat.SeatId));

            if (availableSeat == null)
                return BadRequest("Non ci sono posti liberi disponibili per la data e il turno specificati.");

            // Creo una nuova prenotazione
            var reservation = new Reservation
            {
                ChildrenId = childrenId,
                SeatId = availableSeat.SeatId,
                Date = date,
                IsMorning = isMorning
            };

            _ctx.Reservations.Add(reservation);
            await _ctx.SaveChangesAsync();

            return Ok(reservation);
        }
    }
}

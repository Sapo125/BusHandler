using System;
using BusHandler.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}

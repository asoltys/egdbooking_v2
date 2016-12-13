using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using egdbooking_v2.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace src.ApiControllers
{
    [Produces("application/json")]
    [Route("api/Bookings")]
    public class BookingsController : Controller
    {

        public class SimpleBooking
        {
            public int ID { get; set; }
            public int VID { get; set; } // VesselID
            public DateTime SD { get; set; } // StartDate
            public DateTime ED { get; set; } // EndDate
            public DateTime BT { get; set; } // BookingTime
            public string ST { get; set; } // Status

            [JsonIgnore]
            public Boolean S1 { get; set; } // Section1?
            [JsonIgnore]
            public Boolean S2 { get; set; } // Section2?
            [JsonIgnore]
            public Boolean S3 { get; set; } // Section3?
            [JsonIgnore]
            public Boolean NJ { get; set; } // NorthJetty?
            [JsonIgnore]
            public Boolean SJ { get; set; } // SouthJetty?

        }

        public class SimpleRow
        {
            public int Id { get; set; } // Row id
            public string desc { get; set; } // Row description
            public List<SimpleBooking> bookings { get; set; } // A list of SimpleBookings
        }

        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        [EnableCors("AllowAll")]
        public List<SimpleRow> GetBookings()
        {
            List<SimpleBooking> simpleBookings = new List<SimpleBooking>();
            var bookings = _context.Bookings.AsEnumerable()
                .Where(b => b.StartDate >= DateTime.Now.AddDays(-30))
                .Where(b => b.Status.Equals("C") || b.Status.Equals("T"));
            foreach (var booking in bookings)
            {
                simpleBookings.Add(new SimpleBooking()
                {
                    ID = booking.Id,
                    VID = booking.VesselId,
                    SD = booking.StartDate,
                    ED = booking.EndDate,
                    BT = booking.BookingTime,
                    ST = booking.Status,
                    S1 = booking.Section1 ?? false,
                    S2 = booking.Section2 ?? false,
                    S3 = booking.Section3 ?? false,
                    NJ = booking.NorthJetty ?? false,
                    SJ = booking.SouthJetty ?? false
                });
            }
            List<SimpleRow> result = new List<SimpleRow>();
            result.Add(new SimpleRow()
            {
                Id = result.Count,
                desc = "Section 1",
                bookings = simpleBookings.Where(sb => sb.S1 == true).ToList()
            });
            result.Add(new SimpleRow()
            {
                Id = result.Count,
                desc = "Section 2",
                bookings = simpleBookings.Where(sb => sb.S2 == true).ToList()
            });
            result.Add(new SimpleRow()
            {
                Id = result.Count,
                desc = "Section 3",
                bookings = simpleBookings.Where(sb => sb.S3 == true).ToList()
            });
            result.Add(new SimpleRow()
            {
                Id = result.Count,
                desc = "North Jetty",
                bookings = simpleBookings.Where(sb => sb.NJ == true).ToList()
            });
            result.Add(new SimpleRow()
            {
                Id = result.Count,
                desc = "South Jetty",
                bookings = simpleBookings.Where(sb => sb.SJ == true).ToList()
            });
            return result;
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booking = await _context.Bookings.SingleOrDefaultAsync(m => m.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
        /*
        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking([FromRoute] int id, [FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.ID)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<IActionResult> PostBooking([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bookings.Add(booking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingExists(booking.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBooking", new { id = booking.ID }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booking = await _context.Bookings.SingleOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }
        */
        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
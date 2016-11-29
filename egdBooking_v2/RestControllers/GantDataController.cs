using egdBooking_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace egdBooking_v2.RestControllers
{
    public class GantDataController : ApiController
    {
        private BookingContext db = new BookingContext();

        // GET: api/GantData
        public IQueryable<GantData> Get()
        {
            List<GantData> data = new List<GantData>();
            data.Add(new GantData(db));
            return data.AsQueryable();
        }

        // GET: api/GantData/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GantData
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GantData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GantData/5
        public void Delete(int id)
        {
        }
    }
}

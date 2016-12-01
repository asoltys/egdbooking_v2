using egdBooking_v2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace egdBooking_v2.Controllers
{
    public class BaseController : Controller
    {
        protected const string APPLICATION_CULTURE_EN = "en";
        protected const string APPLICATION_CULTURE_FR = "fr";
        protected const string QUERY_CULTURE_EN = "eng";
        protected const string QUERY_CULTURE_FR = "fra";

        protected BookingContext db;
        public BaseController(BookingContext _db)
        {
            db = _db;
        }
    }
}

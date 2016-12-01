using egdbooking_v2.Data;
using Microsoft.AspNetCore.Mvc;

namespace egdbooking_v2.Controllers
{
    public class BaseController : Controller
    {
        protected const string APPLICATION_CULTURE_EN = "en";
        protected const string APPLICATION_CULTURE_FR = "fr";
        protected const string QUERY_CULTURE_EN = "eng";
        protected const string QUERY_CULTURE_FR = "fra";

        protected ApplicationDbContext db;
        public BaseController(ApplicationDbContext _db)
        {
            db = _db;
        }
    }
}

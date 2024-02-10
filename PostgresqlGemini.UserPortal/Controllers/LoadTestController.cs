using Microsoft.AspNetCore.Mvc;

namespace PostgresqlGemini.UserPortal.Controllers
{
    public class LoadTestController : Controller
    {
        public LoadTestController()
        {
            
        }
        public IActionResult Add30kDataToPostgres()
        {
            return View();
        }
        public IActionResult Add30kDataToSqlServer()
        {
            return View();
        }
    }
}

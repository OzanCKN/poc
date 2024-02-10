using Microsoft.AspNetCore.Mvc;

namespace PostgresqlGemini.UserPortal.Controllers
{
    public class MediatrInjector : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

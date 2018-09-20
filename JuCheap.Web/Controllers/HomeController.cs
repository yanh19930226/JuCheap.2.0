using System.Web.Mvc;

namespace JuCheap.Web.Controllers
{
    /// <summary>
    /// home page
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
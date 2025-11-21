uusing Microsoft.AspNetCore.Mvc;

namespaOrderSystemHW5.Controllers
{
    /// <summary>
    /// Basic home controller that serves the default landing page. You can add additional actions here as your site grows (e.g. About, Contact).
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

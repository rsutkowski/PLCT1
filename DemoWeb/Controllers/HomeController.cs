using System.Web.Mvc;
using DemoWeb.Models;

namespace DemoWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMessageRepository _repository = new MessageRepository(new DataStore());

        public ActionResult Index()
        {
            return View();
        }
    }
}
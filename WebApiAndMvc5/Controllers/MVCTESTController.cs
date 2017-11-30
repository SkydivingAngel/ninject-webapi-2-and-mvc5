using System.Web.Mvc;

namespace WebApiAndMvc5.Controllers
{
    public class MvctestController : Controller
    {
        private readonly IRepo repo;

        public MvctestController(IRepo repo)
        {
            this.repo = repo;
        }
        public ActionResult Index()
        {
            ViewBag.Nome = repo.Name;
            return View();
        }
    }
}

using System.Web.Mvc;

namespace BindingApp.Controllers
{
    public class HomeController : Controller
    {
        VisitorModel model = new VisitorModel();

        // GET: Home
        public ActionResult Index()
        {
            return View(model.ReadVisitors());
        }

        [HttpPost]
        public ActionResult Index(string visitorName)
        {
            model.WriteVisitor(visitorName);
            return Index();
        }
    }
}
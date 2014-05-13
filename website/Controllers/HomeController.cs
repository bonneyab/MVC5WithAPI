using System.Threading.Tasks;
using System.Web.Mvc;
using WebSiteServices.ViewModelProviders.Interfaces;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBirthdayViewModelProvider _birthdayViewModelProvider;

        public HomeController(IBirthdayViewModelProvider birthdayViewModelProvider)
        {
            _birthdayViewModelProvider = birthdayViewModelProvider;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _birthdayViewModelProvider.GetBirthdayModel();
            return View(model);
        }
    }
}
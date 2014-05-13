using System.Collections.Generic;
using System.Web.Http;
using Contract.DTO;
using WebApiServices;

namespace TestSite.Controllers
{
    //Seriously, just goofing around
    public class BirthdayController : ApiController
    {
        private readonly IBirthdayService _birthdayService;

        public BirthdayController(IBirthdayService birthdayService)
        {
            _birthdayService = birthdayService;
        }

        // GET api/values
        public IEnumerable<Birthday> Get()
        {
            return _birthdayService.GetBirthdays();
        }
    }
}

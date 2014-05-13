using System.Collections.Generic;
using System.Web.Http;
using DataAccess.Models;
using DataAccess.Repository;

namespace TestSite.Controllers
{
    public class LunchController : ApiController
    {
        private readonly IRepository<Lunch> _lunchRepository;

        public LunchController(IRepository<Lunch> lunchRepository)
        {
            _lunchRepository = lunchRepository;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        public Contract.DTO.Lunch Get(int id)
        {
            //TODO: Method logging and Response Generation?
            //TODO: introduce a layer that handles getting/transforming data, that's really where 
            //I'd like to start getting into the testing.
            var lunch = _lunchRepository.Get(l => l.LunchId == id);
            //TODO: Automapper time!
            return new Contract.DTO.Lunch{Location = lunch.Location, LunchId = lunch.LunchId, Time = lunch.Time};
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

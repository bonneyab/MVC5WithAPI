using System.Collections.Generic;
using System.Threading.Tasks;
using Contract.DTO;
using Core;

namespace WebSiteServices.ApiWrappers.Interfaces
{
    public interface IBirthdayApi : IDependency
    {
        Task<List<Birthday>> GetBirthdaysAsync();
    }
}

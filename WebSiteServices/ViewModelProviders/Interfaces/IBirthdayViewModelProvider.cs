using System.Threading.Tasks;
using Core;
using WebSiteServices.ViewModels;

namespace WebSiteServices.ViewModelProviders.Interfaces
{
    public interface IBirthdayViewModelProvider : IDependency
    {
        Task<BirthdayViewModel> GetBirthdayModel();
    }
}

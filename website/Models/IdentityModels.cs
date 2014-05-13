using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }

    public class CustomUserStore : IUserStore<ApplicationUser>
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(ApplicationUser user)
        {
            //throw new System.NotImplementedException();
            return null;
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            return null;
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            return null;
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return await GetFauxUser();
        }

        private async Task<ApplicationUser> GetFauxUser()
        {
            return new ApplicationUser{UserName = "bill"};
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using WebSiteServices.ApiWrappers.Interfaces;
using WebSiteServices.ViewModelProviders.Interfaces;
using WebSiteServices.ViewModels;

namespace WebSiteServices.ViewModelProviders
{
    public class BirthdayViewModelProvider : IBirthdayViewModelProvider
    {
        private readonly IBirthdayApi _birthdayApi;

        public BirthdayViewModelProvider(IBirthdayApi birthdayApi)
        {
            _birthdayApi = birthdayApi;
        }

        public async Task<BirthdayViewModel> GetBirthdayModel()
        {
            var birthdays = await _birthdayApi.GetBirthdaysAsync();

            var nextBirthday = birthdays.Any(b => b.Date > DateTime.Now) ? birthdays.First(b => b.Date > DateTime.Now) 
                : birthdays.First();
            return new BirthdayViewModel
            {
                Birthdays = birthdays.ToList(),
                NextBirthday = nextBirthday,
                DaysToGo = (int) (nextBirthday != null ? (nextBirthday.Date - DateTime.Now).TotalDays : 9999),
                ClosestThursday = nextBirthday != null ? GetClosestThursday(nextBirthday.Date) : DateTime.MinValue
            };
        }

        protected DateTime GetClosestThursday(DateTime date, int total = 0)
        {
            if (date.DayOfWeek == DayOfWeek.Thursday)
            {
                return date;
            }
            return GetClosestThursday(total > 3 ? date.AddDays(-1) : date.AddDays(1), total + 1);
        }
    }
}

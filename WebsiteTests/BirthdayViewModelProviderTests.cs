using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contract.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebSiteServices.ApiWrappers.Interfaces;
using WebSiteServices.ViewModelProviders;

namespace WebsiteTests
{
    [TestClass]
    public class BirthdayViewModelProviderTests
    {
        [TestMethod]
        public void GetBirthdayModel_ReturnsModelWithBirthdays()
        {
            //assemble
            var birthdays = new List<Birthday>
            {
                new Birthday {Date = new DateTime(1980, 10, 10), Name = "Bill"},
                new Birthday {Date = new DateTime(1970, 9, 9), Name = "bob"}
            };
            var birthdayViewModelProvider = SetupBirthdayViewModelProvider(birthdays);

            //act
            var result = birthdayViewModelProvider.GetBirthdayModel().Result;

            //assert
            Assert.AreEqual(2, result.Birthdays.Count);
        }

        //TODO add tests for next birthday, etc.

        private static BirthdayViewModelProvider SetupBirthdayViewModelProvider(List<Birthday> birthdays)
        {
            var birthdayApi = new Mock<IBirthdayApi>();
            birthdayApi.Setup(m => m.GetBirthdaysAsync()).ReturnsAsync(birthdays);
            var birthdayViewModelProvider = new BirthdayViewModelProvider(birthdayApi.Object);
            return birthdayViewModelProvider;
        }
    }
}

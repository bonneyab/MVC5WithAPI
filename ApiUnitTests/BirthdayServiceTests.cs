using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiServices;

namespace ApiUnitTests
{
    [TestClass]
    public class BirthdayServiceTests
    {
        //Little goofy since it just reads from a file and I don't want to get too out of control.
        [TestMethod]
        public void GetBirthdays_ReturnsBirthdays()
        {
            var birthdayService = new BirthdayService();
            var birthdays = birthdayService.GetBirthdays();
            Assert.IsTrue(birthdays.Any());
        }

        [TestMethod]
        public void GetBirthdays_ReturnsInOrder()
        {
            var birthdayService = new BirthdayService();
            var actualBirthdays = birthdayService.GetBirthdays();
            var expectedBirthdays = actualBirthdays.OrderBy(e => e.Date);
            Assert.IsTrue(expectedBirthdays.Select(d => d.Date).SequenceEqual(actualBirthdays.Select(d => d.Date)));
        }
    }
}

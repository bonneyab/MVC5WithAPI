using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Contract.DTO;
using Core;

namespace WebApiServices
{
    public class BirthdayService : IBirthdayService
    {
        public List<Birthday> GetBirthdays()
        {
            Func<string, Birthday> birthdayFromText = x =>
            {
                var line = x.Split('|');
                var month = Convert.ToInt32(line[1]);
                var day = Convert.ToInt32(line[2]);
                return new Birthday
                {
                    Name = line[0],
                    Date = new DateTime(DateTime.Now.Year, month, day)
                };
            };
            return
                File.ReadAllLines(@"C:\BirthdayList.txt")
                    .Select(birthdayFromText)
                    .OrderBy(b => b.Date)
                    .ToList();
        }
    }

    public interface IBirthdayService : IDependency
    {
        List<Birthday> GetBirthdays();
    }
}

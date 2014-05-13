using System;
using System.Collections.Generic;
using Contract.DTO;

namespace WebSiteServices.ViewModels
{
    public class BirthdayViewModel
    {
        public List<Birthday> Birthdays { get; set; }
        public Birthday NextBirthday { get; set; }
        public int DaysToGo { get; set; }
        public DateTime ClosestThursday { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using DataAccess.Models;

namespace DataAccess.DataAccessLayer
{
    public class LunchInitializer : DropCreateDatabaseIfModelChanges<LunchContext>
    {
        protected override void Seed(LunchContext context)
        {
            var people = new List<Person>
            {
                new Person {FirstName = "Bob", LastName = "Marley"},
                new Person {FirstName = "Bill", LastName = "Murry"}
            };
            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();

            var lunches = new List<Lunch>
            {
                new Lunch {Location = "Atrium", Time = DateTime.Now},
                new Lunch {Location = "Kodiak", Time = DateTime.Now}
            };
            lunches.ForEach(l => context.Lunches.Add(l));
            context.SaveChanges();

            var peopleToLunches = new List<PersonToLunch>
            {
                new PersonToLunch {LunchId = 1, PersonId = 1},
                new PersonToLunch {LunchId = 2, PersonId = 3},
                new PersonToLunch {LunchId = 2, PersonId = 1}
            };
            peopleToLunches.ForEach(p => context.PersonToLunches.Add(p));
            context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<test2> allRecords = new List<test2>();

            //Puts some test data into the DB (and resets it)
            SeedData();

            //This shows that within the same data context EF keeps track of the record so you can update it even from a list and it will work
            using (AppsDevErrorsEntities dc = new AppsDevErrorsEntities())
            {
                allRecords = dc.test2.ToList();

                var toUpdate = allRecords.Where(a => a.address == "1 Willow drive").FirstOrDefault();

                toUpdate.name = "Mr Aa";

                dc.SaveChanges();
            }

            allRecords = null;

            //Here we demonstrate that if we get the list in one context....            
            using (AppsDevErrorsEntities dc = new AppsDevErrorsEntities())
            {
                allRecords = dc.test2.ToList();
            }
            //...but edit it in another, it will not save back!
            using (AppsDevErrorsEntities dc = new AppsDevErrorsEntities())
            {
                var toUpdate = allRecords.Where(a => a.address == "1 Willow drive").FirstOrDefault();

                toUpdate.name = "Mr Aab";

                dc.SaveChanges(); //You will not get an error here, but the change will not save back to the DB!

                //query to check what is there (will still be "Mr A")
                var record = dc.test2.Where(a => a.address == "1 Willow drive").FirstOrDefault();
                Console.WriteLine(record.name);
            }

            //Now we try the seperate contexts again...
            using (AppsDevErrorsEntities dc = new AppsDevErrorsEntities())
            {
                allRecords = dc.test2.ToList();
            }
            using (AppsDevErrorsEntities dc = new AppsDevErrorsEntities())
            {
                var toUpdate = allRecords.Where(a => a.address == "1 Willow drive").FirstOrDefault();

                //this time we attach the record back to the db record via EF
                dc.test2.Attach(toUpdate);

                //Then perform our updates (anything updated before the "attach" call will not be tracked!)
                toUpdate.name = "Mr Aac";

                dc.SaveChanges();

                //query to check what is there
                var record = dc.test2.Where(a => a.address == "1 Willow drive").FirstOrDefault();
                Console.WriteLine(record.name);

            }
        }

        private static void SeedData()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "Mr A", Address = "1 Willow drive" });
            people.Add(new Person() { Name = "Mr B", Address = "350 Calmore Road" });
            people.Add(new Person() { Name = "Mr C", Address = "14 Daniels Walk" });
            people.Add(new Person() { Name = "Mr D", Address = "220b Baker Street" });
            people.Add(new Person() { Name = "Mr E", Address = "50 Kings Road" });

            using (AppsDevErrorsEntities dc = new AppsDevErrorsEntities())
            {
                var toRemove = dc.test2.ToList();
                dc.test2.RemoveRange(toRemove);
                dc.SaveChanges();

                foreach (var person in people)
                {
                    var toAdd = new test2();
                    toAdd.name = person.Name;
                    toAdd.address = person.Address;

                    dc.test2.Add(toAdd);
                }

                dc.SaveChanges();
            }
        }
    }

    struct Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}

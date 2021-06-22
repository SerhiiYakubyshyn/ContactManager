using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class PeopleRepository : IRepository<People>
    {
        PeopleContext peopleContext;
        public PeopleRepository(PeopleContext context)
        {
            this.peopleContext = context;
        }
        public void Create(People item)
        {
            if (item != null)
            {
                peopleContext.Peoples.Add(item);
                peopleContext.SaveChangesAsync();
            }        
        }

        public void Delete(int? id)
        {
            var people = peopleContext.Peoples.Find(id);
            if (people != null)
            {
                peopleContext.Peoples.Remove(people);
                peopleContext.SaveChangesAsync();
            }
        }

        public People Find(int? id)
        {
            var people = peopleContext.Peoples.Find(id);
            if (people != null)
                return people;
            throw new InvalidOperationException();
        }

        public IEnumerable<People> GetAll()
        {
            return peopleContext.Peoples;
        }

        public void Update(People item)
        {
            peopleContext.Peoples.Update(item);
            peopleContext.SaveChangesAsync();
        }
    }
}

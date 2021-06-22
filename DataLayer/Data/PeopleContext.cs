using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class PeopleContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }
        public PeopleContext(DbContextOptions<PeopleContext> connectionString): base(connectionString)
        {
            Database.EnsureCreated();
        }
    }
}

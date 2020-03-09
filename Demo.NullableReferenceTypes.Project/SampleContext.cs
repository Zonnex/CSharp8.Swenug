using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Demo.NullableReferenceTypes.Project
{
    public class SampleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Boss { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Employees { get; set; }
    }
}

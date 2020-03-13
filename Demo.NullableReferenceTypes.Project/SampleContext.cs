using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Demo.NullableReferenceTypes.Project
{
    // https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types#non-nullable-properties-and-initialization
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base (options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Person Boss { get; set; }
        public Company Company { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Employees { get; set; }
    }
}

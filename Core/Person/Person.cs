using System;

namespace Core.Person
{
    public class Person : EntityBase
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
namespace Core.Person
{
    public class Person : EntityBase
    {
        // The gollowing will be inherited from EntityBase
        // public Guid Id { get; set; }
        // public DateTime CreateDateTime { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
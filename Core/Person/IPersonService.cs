using System.Collections.Generic;

namespace Core.Person
{
    // Interface for PersonService. This allows us to use dependancy injection in the API
    public interface IPersonService
    {
        IEnumerable<Person> FindAll();

        IEnumerable<Person> Find(string term);

        // I like to return a result from Create, make void if you don't
        Person Create(Person person);

        // I like to return a result from Update, make void if you don't
        Person Update(Person person);

        // I like to return a result from Delete, make void if you don't
        bool Delete(Person person);
    }
}
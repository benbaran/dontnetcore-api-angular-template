using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Core.Person
{
    public class PersonService : IPersonService
    {
        private static string _connectionString;
        private static ILogger _logger;

        // Contructor to inject connection string and logger from parent
        public PersonService(string connectionString, ILogger logger) { 
        
                _connectionString = connectionString;
                _logger = logger;
        }

        public Person Create(Person person)
        {

            var sql = @"INSERT INTO PERSON (FirstName, LastName) OUTPUT INSERTED.PersonId VALUES (@FirstName, @LastName)";

            try
            {
                using (var connection = CreateConnection(_connectionString))
                {
                    person.PersonId = connection.QuerySingle<Guid>(sql, person);

                    _logger.LogInformation("{0} -> {1}: Person created with PersonId = {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, person.PersonId);

                    return person;
                }
            }
            catch(Exception exception)
            {
                _logger.LogCritical("{0} -> {1}: {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exception.Message);

                throw;
            }
        }

        public bool Delete(Person person)
        {
            try
            {
                using (var connection = CreateConnection(_connectionString))
                {
                    connection.Query("DELETE FROM Person WHERE PersonId = @PersonId", person);

                    _logger.LogInformation("{0} -> {1}: Person with PersonId = {2} deleted.", this.GetType().Name, MethodBase.GetCurrentMethod().Name, person.PersonId);

                    return true;
                }
            }
            catch (Exception exception)
            {
                _logger.LogCritical("{0} -> {1}: {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exception.Message);

                throw;
            }
        }

        public IEnumerable<Person> FindAll()
        {
            try
            {
                using (var connection = CreateConnection(_connectionString))
                {
                    
                        
                    var result = connection.Query<Person>("SELECT * FROM Person").ToList();

                    _logger.LogInformation("{0} -> {1}: People listed.", this.GetType().Name, MethodBase.GetCurrentMethod().Name, person.PersonId);

                    return result;
                }
            }
            catch (Exception exception)
            {
                _logger.LogCritical("{0} -> {1}: {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exception.Message);

                throw;
            }
        }

        public IEnumerable<Person> Find(string term)
        {
            try
            {
                using (var connection = CreateConnection(_connectionString))
                {
                    var result = connection.Query<Person>("SELECT * FROM Person WHERE LastName LIKE @Term", new { Term = term }).ToList();

                    _logger.LogInformation("{0} -> {1}: People searched with term {2}, {3} results returned.", this.GetType().Name, MethodBase.GetCurrentMethod().Name, person.PersonId);

                    return result;
                }
            }
            catch (Exception exception)
            {
                _logger.LogCritical("{0} -> {1}: {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exception.Message);

                throw;
            }
        }

        public Person Update(Person person)
        {
            try
            {
                using (var connection = CreateConnection(_connectionString))
                {
                    return connection.QuerySingleOrDefault<Person>("UPDATE Person SET FirstName = @FirstName, LastName = @LastName WHERE PersonId = @PersonId", person);
                }
            }
            catch (Exception exception)
            {
                _logger.LogCritical("{0} -> {1}: {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exception.Message);

                throw;
            }
        }

        SqlConnection CreateConnection(string connectionString)
        {

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                                
                _logger.LogCritical("{0} -> {1}: Connection string is null or empty.", GetType().Name, MethodBase.GetCurrentMethod().Name);

                throw new Exception("Connection string is null or empty.");
            }

            var sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
            }
            catch (Exception exception)
            {
                _logger.LogCritical("{0} -> {1}: An error occured while connecting to the database: {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, exception.Message);

                throw new Exception("An error occured while connecting to the database.");
            }
            return sqlConnection;
        }
    }
}
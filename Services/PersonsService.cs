using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        //private field
        private readonly List<Person> _persons;
        private readonly ICountriesService _countriesService;

        //constructor
        public PersonsService()
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();
        }

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            // convert the person object to PersonResponse type
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;
            return personResponse;
        }

        public PersonResponse AddPerson(PersonAddRequest personAddRequest)
        {
            // check if personAddRequest is not null.
            if (personAddRequest == null) 
            { 
                throw new ArgumentNullException(nameof(personAddRequest)); 
            }

            // validate person name
            if (string.IsNullOrEmpty(personAddRequest.PersonName)) 
            {
                throw new ArgumentException("Person Name can't be blank !");
            }

            // convert personAddRequest to Person type
            Person person = personAddRequest.ToPerson();

            // generate PersonID
            person.PersonID = Guid.NewGuid();

            // add person object to persons list
            _persons.Add(person);

            // convert the person object to PersonResponse type
            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            throw new NotImplementedException();
        }
    }
}

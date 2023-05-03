using Entities;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Person Entity
    /// </summary>
    public interface IPersonsService
    {
        /// <summary>
        /// Adds a new person to the list of persons
        /// </summary>
        /// <param name="personAddRequest"></param>
        /// <returns>PersonResponse</returns>
        PersonResponse AddPerson(PersonAddRequest personAddRequest);

        /// <summary>
        /// Returns all persons from the persons list
        /// </summary>
        /// <returns>List<PersonResponse></returns>
        List<PersonResponse> GetAllPersons();
    
    }
}

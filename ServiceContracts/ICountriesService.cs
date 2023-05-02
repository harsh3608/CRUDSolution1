using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// adds a country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest">Country object to add</param>
        /// <returns>CountryResponse</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// Returns all countries from the list
        /// </summary>
        /// <returns>List<CountryResponse></returns>
        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// Returns a Country object based on CountryID 
        /// </summary>
        /// <param name="CountryID"></param>
        /// <returns>CountryResponse</returns>
        CountryResponse? GetCountryByCountryID(Guid CountryID);
        
    }
}
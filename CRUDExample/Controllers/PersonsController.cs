using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace CRUDExample.Controllers
{
    [Route("persons")]
    public class PersonsController : Controller
    {
        // Private Fields
        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;

        // Constructor
        public PersonsController(IPersonsService personsService, ICountriesService countriesService)
        {
            _personsService = personsService;
            _countriesService = countriesService;
        }


        [Route("[action]")]
        [Route("/")]
        public IActionResult Index(string searchBy, string? searchString, 
            string sortBy = nameof(PersonResponse.PersonName), 
            SortOrderOptions sortOrder = SortOrderOptions.ASC  )
        {
            // Searching
            ViewBag.SearchFields = new Dictionary<string, string>() 
            {
                { nameof(PersonResponse.PersonName), "Person Name" },
                { nameof(PersonResponse.Email), "Email" },
                { nameof(PersonResponse.DateOfBirth), "Date of Birth" },
                { nameof(PersonResponse.Age), "Age" },
                { nameof(PersonResponse.Gender), "Gender" },
                { nameof(PersonResponse.Country), "Country" },
                { nameof(PersonResponse.Address), "Address" },
                { nameof(PersonResponse.ReceiveNewsLetters), "Receive News Letters" },
            } ;

            List<PersonResponse> persons = _personsService.GetFilteredPersons(searchBy, searchString);
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            // Sorting
            List<PersonResponse> sortedPersons = 
            _personsService.GetSortedPersons(persons, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();

            return View(sortedPersons); //Views/Persons/Index.cshtml
        }

        // Executes when the user clicks on "Create Person" hyperlink
        // (while opening create view)
        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            List<CountryResponse> countries = _countriesService.GetAllCountries();
            ViewBag.Countries = countries;
            return View();
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(PersonAddRequest personAddRequest)
        {
            if(!ModelState.IsValid)
            {
                List<CountryResponse> countries = _countriesService.GetAllCountries();
                ViewBag.Countries = countries;
                ViewBag.Errors = ModelState.Values.SelectMany(v=>v.Errors).Select(e=> e.ErrorMessage).ToList();
                return View();
            }

            // Call the service method
            PersonResponse personResponse = _personsService.AddPerson(personAddRequest) ;

            // Navigate to Index() action method
            return RedirectToAction("Index", "Persons");
        }


    }
}

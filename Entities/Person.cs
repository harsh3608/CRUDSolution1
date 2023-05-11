using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Person Domain Model Class
    /// </summary>
    public class Person
    {
        [Key]
        public Guid PersonID { get; set; }

        [StringLength(40)]
        public string? PersonName { get; set; }

        [StringLength(40)]
        public string? Email { get; set; }

        //Date
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        //Unique identifier
        public Guid CountryID { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        //bit
        public bool ReceiveNewsLetters { get; set; }

        public string? TIN { get; set; }

        [ForeignKey("CountryID")]
        public virtual Country? Country { get; set; }


        public override string ToString()
        {
            return $"Person ID:{PersonID}, PersonName:{PersonName}, Email:{Email}, Date Of Birth:{DateOfBirth?.ToString("dd-MMM-yyyy")}, Gender:{Gender}, Country ID:{CountryID}, Country:{Country?.CountryName}, Address:{Address}, Receive News Letters:{ReceiveNewsLetters}" ;
        }
    }
}

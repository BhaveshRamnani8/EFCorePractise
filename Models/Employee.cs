using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractise.Models
{
    internal class Employee
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }


        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$", ErrorMessage = "E-Mail is invalid")]
        public string Email { get; set; }//todo validation


        [Column(TypeName = "varchar(1)")]
        [StringLength(1)]
        public string Gender { get; set; }


        [Column(TypeName = "int")]
        [MaxLength(1)]
        public int MaritalStatus { get; set; }

        [RegularExpression(@"^(?:1[01][0-9]|120|1[7-9]|[2-9][0-9])$", ErrorMessage = "Your age is not in specified range")]
        [Column(TypeName = "dateTime")]
        public DateTime BirthDate { get; set; }
        
        
        [Column(TypeName = "varchar(100)")]
        public string Hobbies { get; set; }

        
        [NotMapped]
        public object Image { get; set; }//todo store image

        
        [Column(TypeName = "decimal(10,2)")]
        [Range(5000,100000000000)]
        public decimal Salary { get; set; }

        
        [Column(TypeName = "varchar(500)")]
        public string Address { get; set; }

        
        [ForeignKey(nameof(Country))]
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }


        [ForeignKey(nameof(State))]
        public int? StateId { get; set; }

        public virtual State State { get; set; }


        [ForeignKey(nameof(City))]
        public int? CityId { get; set; }

        public virtual City City { get; set; }


        [Column(TypeName ="varchar(6)")]
        [StringLength(6,MinimumLength = 6)]
        public string ZipCode { get; set; }


        [Column(TypeName ="varchar(50)")]
        [StringLength(16,MinimumLength = 8)]
        public string Password { get; set; } //todo add regex

    }
}

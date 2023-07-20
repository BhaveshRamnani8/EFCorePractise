using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractise.Models
{
    internal class Country
    {
        [Key]
        public int Id { get; set; }        

        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }

    }
}

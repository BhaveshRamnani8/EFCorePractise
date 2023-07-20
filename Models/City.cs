using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractise.Models
{
    internal class City
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(State))]
        public int? StateId { get; set; }

        public virtual State State { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

    }
}

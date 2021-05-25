using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Engine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }

        [Required] public string Type { get; set; }

        [Range(1, int.MaxValue)] 
        [Required] public int Volume { get; set; }

        [Range(1, int.MaxValue)] 
        [Required] public int Power { get; set; }
    }
}

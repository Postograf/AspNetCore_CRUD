using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Model
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }
        [Required] public string Brand { get; set; }
        [Required] public string Manufacturer { get; set; }

        [Required] public int BodyId { get; set; }
        [Required] public int EngineId { get; set; }
    }
}

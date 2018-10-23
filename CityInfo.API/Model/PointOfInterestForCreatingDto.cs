using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Model
{
    public class PointOfInterestForCreatingDto
    {
        [Required(ErrorMessage = "You should enter a name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

       
    }
}

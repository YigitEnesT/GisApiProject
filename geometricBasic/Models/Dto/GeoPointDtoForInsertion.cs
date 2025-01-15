using System.ComponentModel.DataAnnotations;

namespace geometricBasic.Models.Dto
{
    public class GeoPointDtoForInsertion
    {
        public string Name { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
    }
}

using NetTopologySuite.Geometries;

namespace geometricBasic.Models
{
    public class GeoPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Coordinate { get; set; }
    }
}

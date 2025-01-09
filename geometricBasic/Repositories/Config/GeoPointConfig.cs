using geometricBasic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace geometricBasic.Repositories.Config
{
    public class GeoPointConfig : IEntityTypeConfiguration<GeoPoint>
    {
        public void Configure(EntityTypeBuilder<GeoPoint> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Coordinate)
                .HasColumnType("geometry(Point, 4326)")
                .IsRequired();
        }
    }
}

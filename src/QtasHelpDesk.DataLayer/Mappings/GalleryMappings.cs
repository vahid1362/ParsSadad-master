using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.Domain.Media;

namespace QtasHelpDesk.DataLayer.Mappings
{
    public static class GalleryMappings
    {
        public static void AddGalleryMapping(this ModelBuilder model)
        {
            model.Entity<Gallery>().HasMany<GalleryPicture>();
            //model.Entity<Gallery>().HasOne<Picture>();
            model.Entity<GalleryPicture>().HasOne<Picture>();
           

            model.Entity<Gallery>().Property(x => x.Content).HasMaxLength(1500);
            model.Entity<Gallery>().Property(x => x.Title).HasMaxLength(500);
            model.Entity<GalleryPicture>().Property(x => x.Title).HasMaxLength(500);

        }
    }
}
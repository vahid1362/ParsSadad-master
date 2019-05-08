using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.Domain.Content;


namespace QtasHelpDesk.DataLayer.Mappings
{
    public static class ContentMappings
    {
        public static void AddContentMapping(this ModelBuilder model)
        {
            model.Entity<Group>().ToTable("Groups");

            model.Entity<Post>().ToTable("Posts");
            model.Entity<Post>().HasOne(x => x.Group).WithMany(x => x.Posts).HasForeignKey(x => x.GroupId);
            model.Entity<Post>().HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);

            model.Entity<Response>().ToTable("Responses");
            model.Entity<Response>().HasOne(x => x.Post).WithMany(x=>x.Responses).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
           
        }

    }
}

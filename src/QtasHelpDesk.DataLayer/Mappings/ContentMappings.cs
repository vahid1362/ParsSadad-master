using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using QtasHelpDesk.Domain.Content;


namespace QtasHelpDesk.DataLayer.Mappings
{
    public static class ContentMappings
    {
        public static void AddContentMapping(this ModelBuilder model)
        {
            model.Entity<Group>().ToTable("Groups");
            model.Entity<Group>().HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId);
            model.Entity<Group>().HasMany(x => x.UserGroups).WithOne(x => x.Group).HasForeignKey(x => x.GroupId);
            model.Entity<Group>().HasQueryFilter(x => !x.IsPrivate);

            model.Entity<Post>().ToTable("Posts");
            model.Entity<Post>().Property(x => x.Summary).HasMaxLength(400);
            model.Entity<Post>().HasOne(x => x.Group).WithMany(x => x.Posts).HasForeignKey(x => x.GroupId);
            model.Entity<Post>().ToTable("Posts");

            model.Entity<Response>().ToTable("Responses");
            model.Entity<Response>().HasOne(x => x.Post).WithMany(x=>x.Responses).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

            model.Entity<Faq>().ToTable("Faq");
            model.Entity<Faq>().HasOne(x => x.Group).WithMany().HasForeignKey(x => x.GroupId);


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.UserModels;
using BlogApp.BlogModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogArticle> BlogArticles { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new BlogArticleConfiguration());
        }
    }

    //Configuration for Users
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userBuilder)
        {       
            userBuilder.HasAlternateKey(user => user.Login);
            userBuilder.HasMany(user => user.Blogs).WithOne(blog => blog.User).OnDelete(DeleteBehavior.Cascade);
            //userBuilder.HasMany(user => user.Commentaries).WithOne(commentary => commentary.User).OnDelete(DeleteBehavior.Cascade);

            userBuilder.HasData(new User[] { ApplicationData.adminUser });
        }
    }

    //Configuration for Roles
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> roleBuilder)
        {
            roleBuilder.HasAlternateKey(role => role.RoleType);
            roleBuilder.HasMany(role => role.Users).WithOne(user => user.Role).OnDelete(DeleteBehavior.SetNull);

            roleBuilder.HasData(new Role[] { ApplicationData.adminRole, ApplicationData.userRole });
        }
    }

    //Configuration for Blogs
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> blogBuilder)
        {
            blogBuilder.HasMany(blog => blog.Articles).WithOne(blogArticle => blogArticle.Blog).OnDelete(DeleteBehavior.Cascade);
        }
    }

    //Configuration for Blog Articles
    public class BlogArticleConfiguration : IEntityTypeConfiguration<BlogArticle>
    {
        public void Configure(EntityTypeBuilder<BlogArticle> blogArticleBuilder)
        {
            blogArticleBuilder.HasMany(blogArticle => blogArticle.Commentaries).WithOne(commentary => commentary.BlogArticle).OnDelete(DeleteBehavior.Cascade);
            blogArticleBuilder.HasMany(blogArticle => blogArticle.Tags).WithOne(tag => tag.BlogArticle).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

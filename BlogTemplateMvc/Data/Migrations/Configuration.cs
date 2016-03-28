using BlogTemplateMvc.Data.Models;
using System;
using System.Data.Entity.Migrations;

namespace BlogTemplateMvc.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BlogTemplateMvc.Context.BlogMVCDbContext>
    {
        public Configuration()
        {
            //You may have to chanche these to false in release mod
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogTemplateMvc.Context.BlogMVCDbContext context)
        {
            //IMPORTANT Run this method only once to have some post in database, because of the NullRefeneceExeption.
            context.Posts.AddOrUpdate(new Post
            {
                Title = "Some title",
                Subtitle = "This is subtitle",
                Content = "Some textSome textSome textSome textSome textSome textSome textSome textSome textSome textSome textSome text",
                PostedOn = DateTime.Now
            });
        }
    }
}

namespace BlogTemplateMvc.Migrations
{
    using Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogTemplateMvc.Context.BlogMVCDbContext>
    {
        public Configuration()
        {
            //You may have to chanche this to false in release mod
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogTemplateMvc.Context.BlogMVCDbContext context)
        {
            //Use this method if you want to seed some data in Database
        }
    }
}

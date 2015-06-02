namespace UniversityLMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityLMS.DAL.LMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniversityLMS.DAL.LMSContext context)
        {
            //  This method will be called after migrating to the latest version.

              //You can use the DbSet<T>.AddOrUpdate() helper extension method 
              //to avoid creating duplicate seed data. E.g.
            
                context.Users.AddOrUpdate(
                  new User { UserName = "TestUser1", 
                      EmailAddress= "test1@fake-email.com",
                      Password = "123"},
                  new User { UserName = "TestUser2", 
                      EmailAddress = "test2@fake-email.com",
                        Password = "123"},
                  new User { UserName = "TestUser3", 
                      EmailAddress = "test3@fake-email.com" ,
                       Password = "123"}
                );
            
        }
    }
}

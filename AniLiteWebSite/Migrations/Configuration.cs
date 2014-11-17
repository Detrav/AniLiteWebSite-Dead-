namespace AniLiteWebSite.Migrations
{
    using AniLiteWebSite.Core.DataBase.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AniLiteWebSite.Core.DataBase.AniLiteDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AniLiteWebSite.Core.DataBase.AniLiteDBContext context)
        {
            if (context.UserRoles.Count() == 0)
            {
                context.UserRoles.AddOrUpdate(new UserRole { Name = "�����", Level = 0, Added = DateTime.Now, Edited = DateTime.MinValue });
                context.UserRoles.AddOrUpdate(new UserRole { Name = "������������", Level = 100, Added = DateTime.Now, Edited = DateTime.MinValue });
                context.UserRoles.AddOrUpdate(new UserRole { Name = "���������", Level = 200, Added = DateTime.Now, Edited = DateTime.MinValue });
                context.UserRoles.AddOrUpdate(new UserRole { Name = "�������������", Level = 500, Added = DateTime.Now, Edited = DateTime.MinValue });
                context.UserRoles.AddOrUpdate(new UserRole { Name = "����� �������������", Level = 1000, Added = DateTime.Now, Edited = DateTime.MinValue });
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

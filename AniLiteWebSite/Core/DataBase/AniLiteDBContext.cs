using AniLiteWebSite.Core.DataBase.Model;
using AniLiteWebSite.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AniLiteWebSite.Core.DataBase
{
    public class AniLiteDBContext : DbContext
    {
        static AniLiteDBContext()
        {
            Database.SetInitializer<AniLiteDBContext>(new MigrateDatabaseToLatestVersion<AniLiteDBContext, Configuration>());
        }

        public AniLiteDBContext()
            : base("Name=anilitedbContext")
        {
        }

        public AniLiteDBContext(string connectionString) : base(connectionString) { }


        //Основные таблици
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        //Вспомагательные
        //Пользователь
        public DbSet<UserRole> UserRoles { get; set; }
        //Анимэ
        //Пользователь + Анимэ
        public DbSet<ViewedProduct> ProductVieweds { get; set; }
        //История для изменений
        public DbSet<Story> Histrory { get; set; }
    }
}
﻿using System.Data.Entity;
using Entity.Base;

namespace BS.RepositoryDAL
{
    public class DBContext : DbContext
    {
        public DBContext()
            : base("conn")
        {

        }

        public DbSet<News> News { get; set; }

        public DbSet<NewsClass> NewsClass { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Cases> Cases { get; set; }

        public DbSet<Picture> Picture { get; set; }

        public DbSet<User> User { get; set; }
    }
}

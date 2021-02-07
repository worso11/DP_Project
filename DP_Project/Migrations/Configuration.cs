
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DP_Project.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DP_Project.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    } 
}
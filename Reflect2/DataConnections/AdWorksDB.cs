using Reflect2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Reflect2.DataConnections
{
    public class AdWorksDB : DbContext
    {
        //static string connStr = ConfigurationManager.ConnectionStrings["AdWorksExp"].ToString();
        public AdWorksDB() : base(ConfigurationManager.ConnectionStrings["AdWorksExp"].ToString()) { }
        public DbSet<Product> products { get; set; }
    }
}
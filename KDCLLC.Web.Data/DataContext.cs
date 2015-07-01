using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDCLLC.Web.Models.Data;

namespace KDCLLC.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("Customer", "KDC");

        }
        public virtual DbSet<Customer>  Customers { get; set; }
    }
}

﻿using KDCLLC.Web.Models.Data;
using System.Data.Entity.ModelConfiguration;

namespace KDCLLC.Web.Data
{
    public class SalesOrderConfiguration : EntityTypeConfiguration<SalesOrder>
    {
        public SalesOrderConfiguration()
        {
            Property(so => so.CustomerName).HasMaxLength(30).IsRequired();
            Property(so => so.PONumber).HasMaxLength(10).IsOptional();
            Ignore(so => so.ObjectState);
            Property(so => so.RowVersion).IsRowVersion();
        }
    }
}

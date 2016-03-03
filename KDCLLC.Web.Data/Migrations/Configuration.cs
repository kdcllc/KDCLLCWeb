namespace KDCLLC.Web.Data.Migrations
{
    using Models.Data;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            context.SalesOrders.AddOrUpdate(
                so => so.CustomerName,
                new SalesOrder
                {
                    CustomerName = "Adam",
                    PONumber = "9876",
                    SalesOrderItems =
                    {
                        new SalesOrderItem{ProductCode = "ABC", Quantity = 10, UnitPrice = 1.23m },
                        new SalesOrderItem{ProductCode = "XYZ", Quantity = 7, UnitPrice = 14.57m },
                        new SalesOrderItem{ProductCode = "SAMPLE", Quantity = 3, UnitPrice = 15.00m }
                    }
                },
                new SalesOrder { CustomerName = "Michael" },
                new SalesOrder { CustomerName = "David", PONumber = "Acme 9" }
                );
        }
    }
}

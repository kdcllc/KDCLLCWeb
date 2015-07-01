using System.Threading.Tasks;

using KDCLLC.Web.Tests.DataContextTest;
using Shouldly;
using Xunit;

namespace KDCLLC.Web.Tests.RepositoryTest
{
    public class GenericRepositoryTest
    {
        //Shouldly allows for custom messages to be displayed: http://docs.shouldly-lib.net/v2.4.0/docs/overview

        [Fact]
        public void GetWithRawSql_Customer_Test()
        {
            //Arrange
            int RecordId = 1;
            var repository = DataMocks.GetCustomerRepository(3);

            //Act
            var result = repository.GetWithRawSql("selelect * from KDC.Customer where Id= @p0", RecordId);

            //Assert
            Assert.NotNull(result);
            result.Count.ShouldBe(1);


        }

        [Fact]
        public void GetSigle_Customer_Test()
        {
           //Arrange
            int RecordId = 1;
            var repository = DataMocks.GetCustomerRepository(3);

            //Act
            var result = repository.GetSingle(x => x.Id == RecordId);

            //Assert
            Assert.NotNull(result);
            result.Id.ShouldBe(RecordId);


        }

        [Fact]
        public async Task GetSigleAsync_Customer_Test()
        {
            //Arrange
            int RecordId = 1;
            var repository = DataMocks.GetCustomerRepository(3);

            //Act
            var result = await repository.GetSingleAnsync(x => x.Id == RecordId);

            //Assert
            Assert.NotNull(result);
            result.Id.ShouldBe(RecordId);


        }

    }
}

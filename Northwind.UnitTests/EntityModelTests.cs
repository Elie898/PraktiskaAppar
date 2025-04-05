using Northwind.EntityModels;

namespace Northwind.UnitTests
{
    public class EntityModelTests
    {
        [Fact]
        public void DatabaseConnectTest()
        {
            using NorthwindDatabaseContext db = new();
            Assert.True(db.Database.CanConnect());
        }
        [Fact]
        public void CategoryTest()
        {
            using NorthwindDatabaseContext db = new();
            int expected = 8;
            int actual = db.Categories.Count();
            Assert.Equal(expected, actual);
           
        }
        [Fact]
        public void ProductId1IsChaiTest()
        {
            using NorthwindDatabaseContext db = new();
            string expected = "Chai";
            Product? productmedId1dId1 = db.Products.Find(1);
            string actual = productmedId1dId1?.ProductName ?? string.Empty ;
            Assert.Equal(expected, actual);
        }
    }
}

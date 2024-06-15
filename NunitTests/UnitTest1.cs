namespace NunitTesting.NunitTests
{
    public class Tests
    {

        // Test cases for ProductID attribute
        [Test]
        public void ProductID_ShouldBeInRange_WhenInitialized()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 5);

            // Act
            var actual = product.ProductID;

            // Assert
            Assert.That(actual, Is.InRange(1, 1000));
        }

        [Test]
        public void ProductID_ShouldEqualToMinimumValue()
        {
            // Arrange
            var product = new Product(1, "TestProduct", 10.0m, 5);

            // Act
            var actual = product.ProductID;

            // Assert
            Assert.That(actual, Is.EqualTo(1));
        }

        [Test]
        public void ProductID_ShouldEqualToMaximumValue()
        {
            // Arrange
            var product = new Product(1000, "TestProduct", 10.0m, 5);

            // Act
            var actual = product.ProductID;

            // Assert
            Assert.That(actual, Is.EqualTo(1000));
        }

        // Test cases for Price attribute
        [Test]
        public void Price_ShouldBeInRange_WhenInitialized()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 1000.0m, 5);

            // Act
            var actual = product.Price;

            // Assert
            Assert.That(actual, Is.InRange(1.0m, 5000.0m));
        }

        [Test]
        public void Price_ShouldEqualToMinimumValue()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 1.0m, 5);

            // Act
            var actual = product.Price;

            // Assert
            Assert.That(actual, Is.EqualTo(1.0m));
        }

        [Test]
        public void Price_ShouldEqualToMaximumValue()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 5000.0m, 5);

            // Act
            var actual = product.Price;

            // Assert
            Assert.That(actual, Is.EqualTo(5000.0m));
        }

        // Test cases for Stock attribute
        [Test]
        public void Stock_ShouldBeInRange_WhenInitialized()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 500);

            // Act
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.InRange(1, 1000));
        }

        [Test]
        public void Stock_ShouldEqualToMinimumValue()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 1);

            // Act
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(1));
        }

        [Test]
        public void Stock_ShouldEqualToMaximumValue()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 1000);

            // Act
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(1000));
        }

        // Test cases for IncreaseStock method
        [Test]
        public void IncreaseStock_ShouldIncreaseStockByGivenAmount()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 10);
            var increaseAmount = 5;

            // Act
            product.IncreaseStock(increaseAmount);
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(15));
        }

        [Test]
        public void IncreaseStock_ShouldNotChangeStock_WhenAmountIsZero()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 1000);
            var increaseAmount = 0;

            // Act
            product.IncreaseStock(increaseAmount);
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(10));
        }

        [Test]
        public void IncreaseStock_ShouldNotChangeStock_WhenAmountIsNegative()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 10);
            var increaseAmount = -5;

            // Act
            product.IncreaseStock(increaseAmount);
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(10));
        }

        // Test cases for DecreaseStock method
        [Test]
        public void DecreaseStock_ShouldDecreaseStockByGivenAmount()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 10);
            var decreaseAmount = 5;

            // Act
            product.DecreaseStock(decreaseAmount);
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void DecreaseStock_ShouldNotChangeStock_WhenAmountIsZero()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 10);
            var decreaseAmount = 0;

            // Act
            product.DecreaseStock(decreaseAmount);
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(10));
        }

        [Test]
        public void DecreaseStock_ShouldNotDecreaseStock_BelowZero()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 10);
            var decreaseAmount = 15;

            // Act
            product.DecreaseStock(decreaseAmount);
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(10));
        }

        [Test]
        public void Product_ShouldInitialize_WithValidValues()
        {
            // Arrange
            int productId = 100;
            string productName = "ValidProduct";
            decimal price = 100.0m;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductID, Is.EqualTo(productId));
            Assert.That(product.ProductName, Is.EqualTo(productName));
            Assert.That(product.Price, Is.EqualTo(price));
            Assert.That(product.Stock, Is.EqualTo(stock));
        }

        [Test]
        public void DecreaseStock_ShouldSetStockToZero_WhenAmountEqualsStock()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 10);
            var decreaseAmount = 10;

            // Act
            product.DecreaseStock(decreaseAmount);
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void DecreaseStock_ShouldNotChangeStock_WhenAmountIsNegative()
        {
            // Arrange
            var product = new Product(100, "TestProduct", 10.0m, 10);
            var initialStock = product.Stock;
            var decreaseAmount = -5;

            // Act
            product.DecreaseStock(decreaseAmount);
            var actual = product.Stock;

            // Assert
            Assert.That(actual, Is.EqualTo(initialStock));
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethodTemplate.UnitTests
{
    [TestClass]
    public class ProductsControllerTests
    {
        // Method_Scenario_ExpectedBehavior

        [TestMethod]
        public void GetProducts_HugoViewEngine_ShouldReturnsRenderedByRazor()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            var result = controller.GetProducts();

            // Assert
            Assert.AreEqual("View rendered by Hugo", result);

        }
    }
}

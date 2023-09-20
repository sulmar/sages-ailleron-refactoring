using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyPattern.CanDiscountStrategies;
using StrategyPattern.DiscountStrategies;
using System;

namespace StrategyPattern.UnitTests
{
    /*
     * 
    | From | To     | Gender | Percentage | Amount |   When   |
      9:00   15:00     null     0.1          null
      null   null     Female    0.2          null
      null   null     Female    null          10

    */


    /* 
      | Name Parameter | Value | 
          Gender          Female
        Percentage         0.1
     * */

    /*

    | CanDiscountStrategy                                           | DiscountStrategy
    <GenderCanDiscountStrategy>Female</GenderCanDiscountStrategy>   | <PercentageDiscountStrategy>0.1</PercentageDiscountStrategy>
    <GenderCanDiscountStrategy>Male</GenderCanDiscountStrategy>   | <FixedDiscountStrategy>5</FixedDiscountStrategy>

    */

    [TestClass]
public class GenderPercentageOrderCalculatorTests
{
  private OrderCalculator calculator;

  [TestInitialize]
  public void Init()
  {
      ICanDiscountStrategy canDiscountStrategy = new GenderCanDiscountStrategy(Gender.Female);
      IDiscountStrategy discountStrategy = new PercentageDiscountStrategy(0.1m);

      calculator = new OrderCalculator(canDiscountStrategy, discountStrategy);
  }

  [TestMethod]
  public void CalculateDiscount_Female_ShouldDiscount()
  {
      // Arrange
      Order order = new Order(DateTime.MinValue, new Customer { Gender = Gender.Female }, 100);

      // Act
      decimal discount = calculator.CalculateDiscount(order);

      // Assert
      Assert.AreEqual(10, discount);

  }

  [TestMethod]
  public void CalculateDiscount_Male_ShouldNotDiscount()
  {
      // Arrange
      Order order = new Order(DateTime.MinValue, new Customer { Gender = Gender.Male }, 100);

      // Act
      decimal discount = calculator.CalculateDiscount(order);

      // Assert
      Assert.AreEqual(0, discount);

  }

}
}

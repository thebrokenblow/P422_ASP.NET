using FluentValidation.Results;

namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var customer = new Customer
        {
            Surname = null
        };

        //Act
        var validator = new CustomerValidator();
        var result = validator.Validate(customer);

        //Assert
        Assert.Equal("Фамилия должна быть заполнена", result.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Test2()
    {
        var customer = new Customer
        {
            Surname = "123",
            Discount = -100
        };

        var validator = new CustomerValidator();
        var result = validator.Validate(customer);

        Assert.Equal("Скидка не может быть меньше 0", result.Errors.First().ErrorMessage);
    }
}
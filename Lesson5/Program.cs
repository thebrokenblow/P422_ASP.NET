using FluentValidation;
using FluentValidation.Results;

Customer customer = new Customer();
customer.Discount = 100;

CustomerValidator validator = new CustomerValidator();

ValidationResult result = validator.Validate(customer);

foreach (var error in result.Errors)
{
    Console.WriteLine(error);
}

Console.ReadLine();

public class CustomerValidator : AbstractValidator<Customer>
{
    private const int minDiscount = 0;
    private const int maxDiscount = 100;

    public CustomerValidator()
    {
        RuleFor(customer => customer.Surname).NotNull().WithMessage("Фамилия должна быть заполнена");
        RuleFor(customer => customer.Discount).GreaterThanOrEqualTo(minDiscount).WithMessage($"Скидка не может быть меньше {minDiscount}").LessThan(maxDiscount).WithMessage($"Скидка не может быть {maxDiscount}%");
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Forename { get; set; }
    public int Discount { get; set; }
    public string Address { get; set; }
}
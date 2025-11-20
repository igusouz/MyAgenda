using FluentValidation.TestHelper;
using MyAgenda.API.Application.DTOs;
using MyAgenda.API.Application.Validators;

public class CreateContactValidatorTests
{
    private readonly CreateContactValidator _validator;

    public CreateContactValidatorTests()
    {
        _validator = new CreateContactValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var model = new CreateContactDto
        {
            Name = "",
            Email = "valid@email.com",
            Phone = "12345"
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        var model = new CreateContactDto
        {
            Name = "Carlos",
            Email = "invalid-email",
            Phone = "12345"
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Should_Have_Error_When_Phone_Is_Empty()
    {
        var model = new CreateContactDto
        {
            Name = "Carlos",
            Email = "test@test.com",
            Phone = ""
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Phone);
    }

    [Fact]
    public void Should_Not_Have_Errors_When_Model_Is_Valid()
    {
        var model = new CreateContactDto
        {
            Name = "Carlos Silva",
            Email = "carlos@example.com",
            Phone = "11999999999"
        };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}

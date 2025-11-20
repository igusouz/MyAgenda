using FluentValidation.TestHelper;
using MyAgenda.API.Application.DTOs;
using MyAgenda.API.Application.Validators;

public class UpdateContactValidatorTests
{
    private readonly UpdateContactValidator _validator;

    public UpdateContactValidatorTests()
    {
        _validator = new UpdateContactValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var model = new UpdateContactDto
        {
            Name = "",
            Email = "email@test.com",
            Phone = "12345"
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        var model = new UpdateContactDto
        {
            Name = "Carlos",
            Email = "invalid-email",
            Phone = "12345"
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Should_Not_Have_Errors_When_Model_Is_Valid()
    {
        var model = new UpdateContactDto
        {
            Name = "Carlos Silva",
            Email = "carlos@example.com",
            Phone = "11999999999"
        };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}

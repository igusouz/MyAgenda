namespace MyAgenda.API.Application.Validators;

public class CreateContactValidator : AbstractValidator<CreateContactDto>
{
    public CreateContactValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(150);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(30);
    }
}

public class UpdateContactValidator : AbstractValidator<UpdateContactDto>
{
    public UpdateContactValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(150);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(30);
    }
}
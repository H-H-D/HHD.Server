using FluentValidation;
using HHD.Domain.Entities.Users;
using HHD.Service.Commons.Settings;
using Microsoft.Extensions.Options;

namespace HHD.Service.Validators.Users;

public class UserCreadentialsValidator : AbstractValidator<UserCredentials>
{
    public UserCreadentialsValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleFor(credentials => credentials.Password)
            .NotEmpty()
            .Matches(validationSettingsValue.PasswordRegexPattern)
            .WithMessage("Password is not valid");
    }
}

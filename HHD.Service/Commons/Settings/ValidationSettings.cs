namespace HHD.Service.Commons.Settings;

public class ValidationSettings
{
    public string EmailRegexPattern { get; set; } = default!;
    public string PhoneNumberRegexPattern { get; set; } = default!;
    public string PasswordRegexPattern { get; set; } = default!;
}

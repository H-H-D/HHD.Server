using AutoMapper;
using FluentValidation;
using HHD.DAL.IRepositories.Users;
using HHD.Domain.Entities.Users;
using HHD.Service.DTOs.Users;
using HHD.Service.DTOs.Users.Auth.UserCredentials;
using HHD.Service.Interfaces.Users;
using HHD.Service.Validators.Users;
using Microsoft.EntityFrameworkCore;


namespace HHD.Service.Services.Users;
public class UserCreadentialsService(
    IUserCredentialsRepository userCreadentialsRepository,
    UserCreadentialsValidator userCreadentialsValidator,
    IMapper mapper
    ) : IUserCreadentialsService
{
    public async ValueTask<UserCreadentialsForResultDto?> GetByUserIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        )
    {
        return mapper.Map<UserCreadentialsForResultDto>(await userCreadentialsRepository.SelectAll(credential => credential.UserId == userId).SingleOrDefaultAsync());
    }

    public async ValueTask<UserCreadentialsForResultDto> CreateAsync(
        UserCreadentialsForCreationDto userCreadentialsForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var creadentials = mapper.Map<UserCredentials>(userCreadentialsForCreationDto);
        var validationResult = userCreadentialsValidator.Validate(creadentials);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return mapper.Map<UserCreadentialsForResultDto>(await userCreadentialsRepository.InsertAsync(creadentials, saveChanges, cancellationToken));
    }

    public async ValueTask<UserCreadentialsForResultDto> UpdateAsync(
        UserForUpdateDto userForUpdateDto,
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var creadentials = mapper.Map<UserCredentials>(userForUpdateDto);
        creadentials.Id = userId;

        var validationResult = userCreadentialsValidator.Validate(creadentials);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        creadentials.UpdatedAt = DateTime.UtcNow;

        return mapper.Map<UserCreadentialsForResultDto>(await userCreadentialsRepository.UpdateAsync(creadentials, saveChanges, cancellationToken));
    }

    public async ValueTask<UserCreadentialsForResultDto?> DeleteAsync(
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return mapper.Map<UserCreadentialsForResultDto>(await userCreadentialsRepository.DeleteAsync(userId, saveChanges, cancellationToken));
    }
}

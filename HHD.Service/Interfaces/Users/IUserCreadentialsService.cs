using HHD.Domain.Configurations;
using HHD.Service.DTOs.Users;
using HHD.Service.DTOs.Users.Auth.UserCredentials;

namespace HHD.Service.Interfaces.Users;

public interface IUserCreadentialsService
{
    ValueTask<UserCreadentialsForResultDto?> GetByUserIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<UserCreadentialsForResultDto> CreateAsync(
        UserCreadentialsForCreationDto userForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<UserCreadentialsForResultDto> UpdateAsync(
        UserForUpdateDto userForUpdateDto,
        Guid creadentialId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<UserCreadentialsForResultDto?> DeleteAsync(
        Guid creadentialId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}

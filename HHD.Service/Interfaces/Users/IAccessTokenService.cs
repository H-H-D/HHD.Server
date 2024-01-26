using HHD.Service.DTOs.Users.Auth.AccessTokens;

namespace HHD.Service.Interfaces.Users;

public interface IAccessTokenService
{
    ValueTask<AccessTokenForResultDto?> GetByUserIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<AccessTokenForResultDto> CreateAsync(
        AccessTokenForCreationDto accessTokenForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<AccessTokenForResultDto> UpdateAsync(
        AccessTokenForCreationDto accessTokenForCreationDto,
        Guid accessTokenId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<AccessTokenForResultDto?> DeleteAsync(
        Guid accessTokenId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}

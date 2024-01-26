using AutoMapper;
using HHD.DAL.IRepositories.Users;
using HHD.DAL.Repositories.Users;
using HHD.Domain.Entities.Users;
using HHD.Service.DTOs.Users;
using HHD.Service.DTOs.Users.Auth.AccessTokens;
using HHD.Service.DTOs.Users.Auth.UserCredentials;
using HHD.Service.Interfaces.Users;
using HHD.Service.Validators.Users;
using Microsoft.EntityFrameworkCore;

namespace HHD.Service.Services.Users;

public class AccessTokenService(
    AccessTokenRepository accessTokenRepository,
    IMapper mapper
    ) : IAccessTokenService
{
    public async ValueTask<AccessTokenForResultDto?> GetByUserIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return mapper.Map<AccessTokenForResultDto>(await accessTokenRepository.SelectAll(accessToken => accessToken.UserId == userId).SingleOrDefaultAsync());
    }

    public async ValueTask<AccessTokenForResultDto> CreateAsync(
        AccessTokenForCreationDto accessTokenForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var accessToken = mapper.Map<AccessToken>(accessTokenForCreationDto);

        return mapper.Map<AccessTokenForResultDto>(await accessTokenRepository.InsertAsync(accessToken, saveChanges, cancellationToken));
    }

    public async ValueTask<AccessTokenForResultDto> UpdateAsync(
        AccessTokenForCreationDto accessTokenForCreationDto, 
        Guid accessTokenId, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default)
    {
        var accessToken = mapper.Map<AccessToken>(accessTokenForCreationDto);
        accessToken.Id = accessTokenId;

        accessToken.UpdatedAt = DateTime.UtcNow;

        return mapper.Map<AccessTokenForResultDto>(await accessTokenRepository.UpdateAsync(accessToken, saveChanges, cancellationToken));
    }
    
    public async ValueTask<AccessTokenForResultDto?> DeleteAsync(
        Guid accessTokenId, 
        bool saveChanges = true, 
        CancellationToken cancellationToken = default)
    {
        return mapper.Map<AccessTokenForResultDto>(await accessTokenRepository.DeleteAsync(accessTokenId, saveChanges, cancellationToken));
    }
}


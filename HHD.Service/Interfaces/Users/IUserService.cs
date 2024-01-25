using HHD.Domain.Configurations;
using HHD.Domain.Entities.Users;
using HHD.Service.DTOs.Users;
using System.Linq.Expressions;

namespace HHD.Service.Interfaces.Users;

public interface IUserService
{
    ValueTask<IEnumerable<UserForResultDto>> GetAllAsync(
        PaginationParams @params,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<UserForResultDto?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    ValueTask<UserForResultDto> CreateAsync(
        UserForCreationDto userForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<UserForResultDto> UpdateAsync(
        UserForUpdateDto userForUpdateDto,
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);

    ValueTask<UserForResultDto?> DeleteAsync(
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
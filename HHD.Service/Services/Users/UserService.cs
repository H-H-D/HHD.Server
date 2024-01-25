using AutoMapper;
using HHD.DAL.IRepositories.Users;
using HHD.Domain.Entities.Users;
using HHD.Service.DTOs.Users;
using HHD.Service.Interfaces.Users;
using HHD.Service.Validators.Users;
using System.Linq.Expressions;
using FluentValidation;

namespace HHD.Service.Services.Users;

public class UserService(
    IUserRepository userRepository,
    UserValidator userValidate,
    IMapper mapper
    ) : IUserService
{
    public IQueryable<UserForResultDto> Get(
        Expression<Func<UserForResultDto, bool>>? predicate = default,
        bool asNoTracking = false
        )
    {
        var users = userRepository.SelectAll(user => user.DeletedAt == null, asNoTracking);
        return mapper.Map<IQueryable<UserForResultDto>>(users);
    }

    public async ValueTask<UserForResultDto?> GetByIdAsync(
        Guid userId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        )
    {
        return mapper.Map<UserForResultDto>(await userRepository.SelectByIdAsync(userId, asNoTracking, cancellationToken));
    }

    public async ValueTask<UserForResultDto> CreateAsync(
        UserForCreationDto userForCreationDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var user = mapper.Map<User>(userForCreationDto);
        var validationResult = userValidate.Validate(user);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return mapper.Map<UserForResultDto>(await userRepository.InsertAsync(user, saveChanges, cancellationToken));
    }

    public async ValueTask<UserForResultDto> UpdateAsync(
        UserForUpdateDto userForUpdateDto,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var user = mapper.Map<User>(userForUpdateDto);

        var validationResult = userValidate.Validate(user);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        user.UpdatedAt = DateTime.UtcNow;

        return mapper.Map<UserForResultDto>(await userRepository.UpdateAsync(user, saveChanges, cancellationToken));
    }

    public async ValueTask<UserForResultDto?> DeleteAsync(
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        return mapper.Map<UserForResultDto>(await userRepository.DeleteAsync(userId, saveChanges, cancellationToken));
    }
}

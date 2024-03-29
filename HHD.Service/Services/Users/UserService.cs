﻿using AutoMapper;
using HHD.DAL.IRepositories.Users;
using HHD.Domain.Entities.Users;
using HHD.Service.DTOs.Users;
using HHD.Service.Interfaces.Users;
using HHD.Service.Validators.Users;
using System.Linq.Expressions;
using FluentValidation;
using HHD.Domain.Configurations;
using Microsoft.Extensions.Logging;
using HHD.Service.Commons.Extentions;

namespace HHD.Service.Services.Users;

public class UserService(
    IUserRepository userRepository,
    UserValidator userValidator,
    IMapper mapper
    ) : IUserService
{
    public ValueTask<IEnumerable<UserForResultDto>> GetAllAsync(
        PaginationParams @params,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        )
    {
        var users = userRepository.SelectAll(user => user.DeletedAt == null, asNoTracking).Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize);
        //.ToPagedList<User>(@params);
        return new(mapper.Map<IEnumerable<UserForResultDto>>(users));
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
        var validationResult = userValidator.Validate(user);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return mapper.Map<UserForResultDto>(await userRepository.InsertAsync(user, saveChanges, cancellationToken));
    }

    public async ValueTask<UserForResultDto> UpdateAsync(
        UserForUpdateDto userForUpdateDto,
        Guid userId,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
        )
    {
        var user = mapper.Map<User>(userForUpdateDto);
        user.Id = userId;

        var validationResult = userValidator.Validate(user);
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

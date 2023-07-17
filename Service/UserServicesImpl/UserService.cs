﻿using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
namespace Service.UserServicesImpl;

public sealed class UserService : IUserService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
    {
        var users = _repository.User.GetAllUsers(trackChanges);
        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
        return usersDto;
    }

    public UserDto GetUser(Guid id, bool trackChanges)
    {
        var user = _repository.User.GetUser(id, trackChanges);
        if (user is null)
            throw new UserNotFoundException(id);
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    public UserDto CreateUser(UserForCreationDto user)
    {
        var userEntity = _mapper.Map<User>(user);

        _repository.User.CreateUser(userEntity);
        _repository.Save();

        var userToReturn = _mapper.Map<UserDto>(userEntity);
        return userToReturn;
    }

    public void DeleteUser(Guid id, bool trackChanges)
    {
        var user = _repository.User.GetUser(id, trackChanges);
        if (user is null)
            throw new UserNotFoundException(id);

        _repository.User.DeleteUser(user);
        _repository.Save();
    }
}
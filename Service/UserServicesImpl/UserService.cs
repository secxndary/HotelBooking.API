using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;

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


    public async Task<(IEnumerable<UserDto> users, MetaData metaData)> GetAllUsersAsync(UserParameters userParameters)
    {
        var usersWithMetaData = await _repository.User.GetAllUsersAsync(userParameters, trackChanges: false);
        var usersDto = _mapper.Map<IEnumerable<UserDto>>(usersWithMetaData);
        return (users: usersDto, metaData: usersWithMetaData.MetaData);
    }

    public async Task<UserDto> GetUserAsync(Guid id)
    {
        var user = await GetUserAndCheckIfItExists(id, trackChanges: false);
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<UserDto> CreateUserAsync(UserForCreationDto user)
    {
        await CheckIfRoleExists(user.RoleId);

        var userEntity = _mapper.Map<User>(user);
        _repository.User.CreateUser(userEntity);
        await _repository.SaveAsync();

        var userToReturn = _mapper.Map<UserDto>(userEntity);
        return userToReturn;
    }

    public async Task<UserDto> UpdateUserAsync(Guid id, UserForUpdateDto userForUpdate)
    {
        await CheckIfRoleExists(userForUpdate.RoleId);

        var userEntity = await GetUserAndCheckIfItExists(id, trackChanges: true);
        _mapper.Map(userForUpdate, userEntity);
        await _repository.SaveAsync();

        var userToReturn = _mapper.Map<UserDto>(userEntity);
        return userToReturn;
    }

    public async Task<(UserForUpdateDto userToPatch, User userEntity)> GetUserForPatchAsync(Guid id)
    {
        var userEntity = await GetUserAndCheckIfItExists(id, trackChanges: true);
        var userToPatch = _mapper.Map<UserForUpdateDto>(userEntity);
        return (userToPatch, userEntity);
    }

    public async Task<UserDto> SaveChangesForPatchAsync(UserForUpdateDto userToPatch, User userEntity)
    {
        await CheckIfRoleExists(userToPatch.RoleId);

        _mapper.Map(userToPatch, userEntity);
        await _repository.SaveAsync();

        var userToReturn = _mapper.Map<UserDto>(userEntity);
        return userToReturn;
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await GetUserAndCheckIfItExists(id, trackChanges: false);
        _repository.User.DeleteUser(user);
        await _repository.SaveAsync();
    }


    private async Task CheckIfRoleExists(Guid roleId)
    {
        var role = await _repository.Role.GetRoleAsync(roleId, trackChanges: false);
        if (role is null)
            throw new RoleNotFoundException(roleId);
    }

    private async Task<User> GetUserAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var user = await _repository.User.GetUserAsync(id, trackChanges);
        if (user is null)
            throw new UserNotFoundException(id);
        return user;
    }
}
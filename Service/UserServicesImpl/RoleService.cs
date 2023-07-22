﻿using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.UserServicesImpl;

public sealed class RoleService : IRoleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RoleService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _repository.Role.GetAllRolesAsync(trackChanges: false);
        var rolesDto = _mapper.Map<IEnumerable<RoleDto>>(roles);
        return rolesDto;
    }

    public async Task<RoleDto> GetRoleAsync(Guid id)
    {
        var role = await _repository.Role.GetRoleAsync(id, trackChanges: false);
        if (role is null)
            throw new RoleNotFoundException(id);

        var roleDto = _mapper.Map<RoleDto>(role);
        return roleDto;
    }

    public async Task<RoleDto> CreateRoleAsync(RoleForCreationDto role)
    {
        var roleEntity = _mapper.Map<Role>(role);

        _repository.Role.CreateRole(roleEntity);
        await _repository.SaveAsync();

        var roleToReturn = _mapper.Map<RoleDto>(roleEntity);
        return roleToReturn;
    }

    public async Task UpdateRoleAsync(Guid id, RoleForUpdateDto roleForUpdate)
    {
        var roleEntity = await _repository.Role.GetRoleAsync(id, trackChanges: true);
        if (roleEntity is null)
            throw new RoleNotFoundException(id);

        _mapper.Map(roleForUpdate, roleEntity);
        await _repository.SaveAsync();
    }

    public async Task<(RoleForUpdateDto roleToPatch, Role roleEntity)> GetRoleForPatchAsync(Guid id)
    {
        var roleEntity = await _repository.Role.GetRoleAsync(id, trackChanges: true);
        if (roleEntity is null)
            throw new RoleNotFoundException(id);

        var roleToPatch = _mapper.Map<RoleForUpdateDto>(roleEntity);
        return (roleToPatch, roleEntity);
    }

    public async Task SaveChangesForPatchAsync(RoleForUpdateDto roleToPatch, Role roleEntity)
    {
        _mapper.Map(roleToPatch, roleEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteRoleAsync(Guid id)
    {
        var role = await _repository.Role.GetRoleAsync(id, trackChanges: false);
        if (role is null)
            throw new RoleNotFoundException(id);

        _repository.Role.DeleteRole(role);
        await _repository.SaveAsync();
    }
}
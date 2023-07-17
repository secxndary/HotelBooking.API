﻿using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<RoomType> GetAllRoomTypes(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(r => r.Name)
        .ToList();

    public RoomType? GetRoomType(Guid id, bool trackChanges) =>
        FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateRoomType(RoomType roomType) =>
        Create(roomType);

    public void DeleteRoomType(RoomType roomType) =>
        Delete(roomType);
}
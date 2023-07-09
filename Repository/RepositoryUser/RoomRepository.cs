﻿using Contracts.Repository;
using Entities.Models;

namespace Repository.RepositoryUser;

public class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}
﻿using Contracts.Repository;
using Entities.Models;

namespace Repository.RepositoryUser;

public class HotelPhotoRepository : RepositoryBase<HotelPhoto>, IHotelPhotoRepository
{
    public HotelPhotoRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}
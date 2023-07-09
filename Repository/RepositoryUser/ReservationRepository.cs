﻿using Contracts.Repository;
using Entities.Models;

namespace Repository.RepositoryUser;

public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
{
    public ReservationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}
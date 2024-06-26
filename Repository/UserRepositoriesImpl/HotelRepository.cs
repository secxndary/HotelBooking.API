﻿using Contracts.Repositories.UserRepositories;
using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Repository.Extentsions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Repository.UserRepositoriesImpl;

public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
{
    public HotelRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<PagedList<Hotel>> GetAllHotelsAsync(HotelParameters hotelParameters, bool trackChanges)
    {
        var hotels = new List<Hotel>();
        
        if (!string.IsNullOrWhiteSpace(hotelParameters.City))
        {
            hotels = await FindAll(trackChanges)
                .FilterHotelsByStars(hotelParameters.MinStars, hotelParameters.MaxStars)
                .Search(hotelParameters.SearchTerm)
                .Sort(hotelParameters.OrderBy)
                .Where(hotel => hotel.Address.Contains(hotelParameters.City))
                .ToListAsync();
        }
        else
        {
            hotels = await FindAll(trackChanges)
                .FilterHotelsByStars(hotelParameters.MinStars, hotelParameters.MaxStars)
                .Search(hotelParameters.SearchTerm)
                .Sort(hotelParameters.OrderBy)
                .ToListAsync();
        }

        return PagedList<Hotel>.ToPagedList(hotels, hotelParameters.PageNumber, hotelParameters.PageSize);
    }

    public async Task<PagedList<Hotel>> GetHotelsByHotelOwnerAsync(string hotelOwnerId, HotelParameters hotelParameters,
        bool trackChanges)
    {
        var hotels = await FindByCondition(h => h.HotelOwnerId == hotelOwnerId, trackChanges)
            .FilterHotelsByStars(hotelParameters.MinStars, hotelParameters.MaxStars)
            .Search(hotelParameters.SearchTerm)
            .Sort(hotelParameters.OrderBy)
            .ToListAsync();

        return PagedList<Hotel>.ToPagedList(hotels, hotelParameters.PageNumber, hotelParameters.PageSize);
    }
    
    public async Task<IEnumerable<Hotel>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(h => ids.Contains(h.Id), trackChanges)
        .ToListAsync();

    public async Task<Hotel?> GetHotelAsync(Guid id, bool trackChanges) =>
        await FindByCondition(h => h.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateHotel(Hotel hotel) => 
        Create(hotel);

    public void DeleteHotel(Hotel hotel) =>
       Delete(hotel);
}
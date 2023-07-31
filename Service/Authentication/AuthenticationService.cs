using AutoMapper;
using Contracts;
using Service.Contracts.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Entities.Models;
using Shared.DataTransferObjects.AuthenticationDtos;
namespace Service.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<UserIdentity> _userManager;
    private readonly IConfiguration _configuration;

    public AuthenticationService(ILoggerManager logger, IMapper mapper, 
        UserManager<UserIdentity> userManager, IConfiguration configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }


    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        var user = _mapper.Map<UserIdentity>(userForRegistration);
        var result = await _userManager.CreateAsync(user, userForRegistration.Password!);

        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles!);

        return result;
    }
}
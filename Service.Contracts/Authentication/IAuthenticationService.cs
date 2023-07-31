using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.AuthenticationDtos;
namespace Service.Contracts.Authentication;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
}
﻿using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.AuthenticationDtos;
namespace Service.Contracts.Authentication;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
    Task<TokenDto> CreateToken(bool populateExpiration);
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
    Task<UserDto> GetUserByToken(TokenDto tokenDto);
    UserIdentity GetUser();
    Task<IdentityUser> GetUserById(string id);
}
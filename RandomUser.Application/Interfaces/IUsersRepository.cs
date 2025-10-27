﻿using RandomUser.Application.Queries.Users;

namespace RandomUser.Application.Interfaces;

public interface IUsersRepository
{
    Task<List<UserDto>> GetAllUsersAsync();
    Task<List<UserDto>> SearchUsersByNameAsync(string searchTerm);
}
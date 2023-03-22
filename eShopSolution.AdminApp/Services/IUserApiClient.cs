﻿using eShopSolution.ViewModel.Common;
using eShopSolution.ViewModel.System.Users;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserVm>> GetUsersPaging(GetUserPagingRequest request);

    }
}

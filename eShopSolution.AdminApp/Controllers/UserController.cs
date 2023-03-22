﻿using eShopSolution.AdminApp.Services;
using eShopSolution.ViewModel.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
       // private readonly IRoleApiClient _roleApiClient;

        public UserController(IUserApiClient userApiClient,
            IConfiguration configuration)
        { 
            _userApiClient = userApiClient;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize=10)
        {
            var sessions = HttpContext.Session.GetString("Token");
                var request = new GetUserPagingRequest() 
            {
                BearerToken = sessions,
                PageSize = pageSize,
                PageIndex = pageIndex,
                Keyword = keyword
            };
            var data = await _userApiClient.GetUsersPaging(request);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            
                return View(ModelState);
            
            var token = await _userApiClient.Authenticate(request);
            var userPrincipal = this.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            HttpContext.Session.SetString("Token", token);  
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                authProperties);
            return RedirectToAction("Index","Home");
        }
         
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Login", "User");
        }
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;


        }
    }
}

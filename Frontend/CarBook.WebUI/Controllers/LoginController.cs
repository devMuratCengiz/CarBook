﻿using CarBook.DTO.LoginDtos;
using CarBook.DTO.RegisterDto;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CarBook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        
            private readonly IHttpClientFactory _httpClientFactory;

            public LoginController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public IActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Index(LoginDto loginDto)
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7126/api/SignIn", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler= new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();
                    if(tokenModel.Token != null)
                    {
                        claims.Add(new Claim("accessToken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var autProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), autProps);
                        return RedirectToAction("Index", "Default");
                    }
                }
            }
                
                return View();
            }
        
    }
}
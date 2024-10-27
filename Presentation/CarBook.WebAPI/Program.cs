using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Application.Interfaces.PricingInterfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Application.Services;
using CarBook.Application.Tools;
using CarBook.Persistance.Context;
using CarBook.Persistance.Repositories;
using CarBook.Persistance.Repositories.BlogRepositories;
using CarBook.Persistance.Repositories.CarFeatureRepositories;
using CarBook.Persistance.Repositories.CarPricingRepositories;
using CarBook.Persistance.Repositories.CarRepositories;
using CarBook.Persistance.Repositories.CommentRepositories;
using CarBook.Persistance.Repositories.RentACarRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDeafults.ValidAudience,
        ValidIssuer = JwtTokenDeafults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDeafults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddScoped<CarBookContext>();

// Add services to the container.
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAllAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<DeleteAboutCommandHandler>();


builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetAllBannerQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<DeleteBannerCommandHandler>();

builder.Services.AddScoped<GetAllBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<DeleteBrandCommandHandler>();

builder.Services.AddScoped<GetAllCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<DeleteCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();

builder.Services.AddScoped<GetAllCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<DeleteCategoryCommandHandler>();

builder.Services.AddScoped<GetAllContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<DeleteContactCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);


builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository),typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICommentRepository),typeof(CommentRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(IRentACarRepository),typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository),typeof(CarFeatureRepository));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

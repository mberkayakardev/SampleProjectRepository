using AkarBusiness.Abstract;
using AkarBusiness.Concrete;
using AkarBusiness.Concrete.Mapping;
using AkarDataAccess.Abstract;
using AkarDataAccess.Concrete.DataAccess.Context;
using AkarDataAccess.Concrete.DataAccess.UOW;
using AkarDataAccess.Concrete.Repository;
using Autofac.Core;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AkarUI.Services.IOC
{
    public static class MyCostumeIOC 
    {
        public static void CreateDependencyInstance (IServiceCollection service)
        {
            service.AddScoped<DbContext, MyDbContext>();
            service.AddScoped<IUnitOfWork, MyUnitOfWork>();
            service.AddScoped<IUserService, UserManager>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IGroupService, GroupManager>();
            service.AddScoped<IGroupRepository, GroupRepository>();
            service.AddScoped<ITokenService, TokenManager>();
            service.AddScoped<ITokenRepository, TokenRepository>();
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }

        public static void CreateAuthService(IServiceCollection service)
        {
            service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "LoginUser";
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

            });
        }

        public static void AddExtentionService(IServiceCollection service)
        {
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new MyMapProfile());
            });
            var Mapper = configuration.CreateMapper();
            service.AddSingleton(Mapper);
        }



    }
}

using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiAPI.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {

        });

        services.AddSingleton(config.CreateMapper());
    }
}


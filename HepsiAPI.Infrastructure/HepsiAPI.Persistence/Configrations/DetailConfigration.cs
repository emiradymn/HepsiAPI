using System;
using Bogus;
using HepsiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiAPI.Persistence.Configrations;

public class DetailConfigration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        Faker faker = new("tr");

        Detail detail1 = new()
        {
            Id = 1,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(5),
            CategoryId = 1,
            CreateDate = DateTime.Now,
            IsDeleted = false
        };
        Detail detail12 = new()
        {
            Id = 2,
            Title = faker.Lorem.Sentence(2),
            Description = faker.Lorem.Sentence(5),
            CategoryId = 3,
            CreateDate = DateTime.Now,
            IsDeleted = false
        };
        Detail detail3 = new()
        {
            Id = 3,
            Title = faker.Lorem.Sentence(2),
            Description = faker.Lorem.Sentence(5),
            CategoryId = 4,
            CreateDate = DateTime.Now,
            IsDeleted = true
        };

        builder.HasData(detail1, detail12, detail3);

    }
}

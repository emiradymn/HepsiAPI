using System;
using Bogus;
using HepsiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiAPI.Persistence.Configrations;

public class ProductConfigration : IEntityTypeConfiguration<Product>

{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Faker faker = new("tr");

        Product product1 = new()
        {
            Id = 1,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            BrandId = 1,
            Discount = faker.Random.Decimal(0, 10),
            Price = faker.Finance.Amount(10, 100),
            CreateDate = DateTime.Now,
            IsDeleted = false
        };
        Product product2 = new()
        {
            Id = 2,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            BrandId = 2,
            Discount = faker.Random.Decimal(0, 10),
            Price = faker.Finance.Amount(10, 100),
            CreateDate = DateTime.Now,
            IsDeleted = false
        };
        Product product3 = new()
        {
            Id = 3,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            BrandId = 3,
            Discount = faker.Random.Decimal(0, 10),
            Price = faker.Finance.Amount(10, 100),
            CreateDate = DateTime.Now,
            IsDeleted = false
        };

        builder.HasData(product1, product2, product3);


    }
}

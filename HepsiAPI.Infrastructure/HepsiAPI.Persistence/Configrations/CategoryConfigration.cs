using System;
using HepsiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiAPI.Persistence.Configrations;

public class CategoryConfigration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        Category category1 = new()
        {
            Id = 1,
            Name = "Elektronik",
            Priority = 1,
            ParentId = 0,
            IsDeleted = false,
            CreateDate = DateTime.Now,
        };
        Category category2 = new()
        {
            Id = 2,
            Name = "Moda",
            Priority = 2,
            ParentId = 0,
            IsDeleted = false,
            CreateDate = DateTime.Now,
        };
        Category parent1 = new()
        {
            Id = 3,
            Name = "Bilgisayar",
            Priority = 1,
            ParentId = 1,
            IsDeleted = false,
            CreateDate = DateTime.Now,
        };
        Category parent2 = new()
        {
            Id = 4,
            Name = "Erkek",
            Priority = 1,
            ParentId = 2,
            IsDeleted = false,
            CreateDate = DateTime.Now,
        };
        builder.HasData(category1, category2, parent1, parent2);
    }
}

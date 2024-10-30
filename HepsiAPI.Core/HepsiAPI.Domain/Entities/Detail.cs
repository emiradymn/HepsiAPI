using System;
using HepsiAPI.Domain.Common;

namespace HepsiAPI.Domain.Entities;

public class Detail : EntityBase
{
    public Detail()
    {

    }

    public Detail(string title, string description, int categoryId)
    {
        Title = title;
        Description = description;
        CategoryId = categoryId;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }



}

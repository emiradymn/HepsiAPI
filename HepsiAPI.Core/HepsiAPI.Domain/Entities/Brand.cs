using System;
using HepsiAPI.Domain.Common;

namespace HepsiAPI.Domain.Entities;

public class Brand : EntityBase
{
    public Brand()
    {

    }

    public Brand(string name)
    {
        Name = name;
    }
    public required string Name { get; set; }

}

using System;
using System.Net;
using HepsiAPI.Application.UnitOfWorks;
using HepsiAPI.Domain.Entities;
using MediatR;

namespace HepsiAPI.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

        List<GetAllProductsQueryResponse> response = new();

        foreach (var prd in products)

            response.Add(new GetAllProductsQueryResponse
            {
                Title = prd.Title,
                Description = prd.Description,
                Discount = prd.Discount,
                Price = prd.Price - (prd.Price * prd.Discount / 100),
            });

        return response;



    }
}

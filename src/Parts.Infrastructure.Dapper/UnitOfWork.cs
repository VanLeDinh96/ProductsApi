﻿using Parts.Domain.Abstractions.Dappers;
using Parts.Domain.Abstractions.Dappers.Repositories.Product;

namespace Parts.Infrastructure.Dapper;
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IProductRepository productRepository)
    {
        Products = productRepository;
    }

    public IProductRepository Products { get; }
}

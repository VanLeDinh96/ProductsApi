﻿using MediatR;
using Parts.Contract.Shared;

namespace Parts.Contract.Abstractions.Message;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{ }

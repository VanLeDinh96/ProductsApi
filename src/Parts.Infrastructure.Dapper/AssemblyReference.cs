﻿using System.Reflection;

namespace Parts.Infrastructure.Dapper;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

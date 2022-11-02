using Dotnet6MvcLogin.Data.Base;

using Dotnet6MvcLogin.Models;
using Dotnet6MvcLogin.Models.Domain;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Dotnet6MvcLogin.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        public ProductService(DatabaseContext context) : base(context) { }
    }
}

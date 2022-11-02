using Dotnet6MvcLogin.Models;
using Dotnet6MvcLogin.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Dotnet6MvcLogin.Data.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
    }
}
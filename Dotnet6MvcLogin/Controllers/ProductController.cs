using Dotnet6MvcLogin.Data;
using Dotnet6MvcLogin.Data.Services;
using Dotnet6MvcLogin.Data.Static;
using Dotnet6MvcLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Dotnet6MvcLogin.Controllers
{
   // [Authorize(Roles = UserRoles.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService service,IWebHostEnvironment hostEnvironment)
        {
            _service = service;
            this._webHostEnvironment = hostEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        {
            {
            }


            await _service.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }
            else
            {
                return View(model: product);

            }
     

        }

        //Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);

            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        [HttpPost]
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

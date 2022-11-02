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
        public async Task<IActionResult> Create([Bind("ProductName,productCategory,ProductStatus,ImageFile,ImageURL,productDimention,Quantity,Weight,StartingPrice,StartDate,Enddate,ProductDetail")] Product product)
        {

            if (ModelState.IsValid)
            {
                
                //save image
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extention = Path.GetExtension(product.ImageFile.FileName);
                product.ImageURL = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
               
                string path = Path.Combine(wwwRootPath + "/ProductImage", product.ImageURL);
                product.ImageURL = "ProductImage/" + fileName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,productCategory,ProductStatus,ImageFile,ImageURL,productDimention,Quantity,Weight,StartingPrice,StartDate,Enddate,ProductDetail")] Product product)
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

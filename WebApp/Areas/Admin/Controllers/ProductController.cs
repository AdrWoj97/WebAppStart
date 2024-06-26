﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using NT.DataAccess.Repository.IRepository;
using NT.Models;
using NT.Models.ViewModels;
using System.Collections.Generic;
using WebApp.Data;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objCategoryList = _unitOfWork.Products.GetAll().ToList();

            return View(objCategoryList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                CategoryList = _unitOfWork.Kategoria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.KategorieId.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                //create
                return View(productVM);
            }
            else 
            { 
                //update
                productVM.Product = _unitOfWork.Products.Get(u=>u.ProductId == id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Add(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Utworzono produkt";
                return RedirectToAction("Index");
            }
            else 
            {
                obj.CategoryList = _unitOfWork.Kategoria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.KategorieId.ToString()
                });
                return View(obj);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFrmDb = _unitOfWork.Products.Get(u => u.ProductId == id);
            if (productFrmDb == null)
            {
                return NotFound();
            }
            return View(productFrmDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFrmDb = _unitOfWork.Products.Get(u => u.ProductId == id);
            if (ProductFrmDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Remove(ProductFrmDb);
            _unitOfWork.Save();
            TempData["success"] = "Usunięto produkt";
            return RedirectToAction("Index");
        }
    }
}

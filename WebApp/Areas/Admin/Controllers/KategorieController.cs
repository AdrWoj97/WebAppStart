using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NT.DataAccess.Repository.IRepository;
using NT.Models;
using WebApp.Data;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategorieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public KategorieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Kategorie> objCategoryList = _unitOfWork.Kategoria.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kategorie obj)
        {
            if (obj.DisplayOrder <= 0)
            {
                ModelState.AddModelError("DisplayOrder", "Kolejośc wyświetlania musi być między 1 - 100");
                return View();
            }
            else if (ModelState.IsValid)
            {
                _unitOfWork.Kategoria.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Utworzono kategorię";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Kategorie? kategoriaFrmDb = _unitOfWork.Kategoria.Get(u => u.KategorieId == id);
            if (kategoriaFrmDb == null)
                return NotFound();

            return View(kategoriaFrmDb);
        }
        [HttpPost]
        public IActionResult Edit(Kategorie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Kategoria.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Zapisano zmiany w kategorii";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kategorie? kategoriaFrmDb = _unitOfWork.Kategoria.Get(u => u.KategorieId == id);
            if (kategoriaFrmDb == null)
            {
                return NotFound();
            }
            return View(kategoriaFrmDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kategorie? kategoriaFrmDb = _unitOfWork.Kategoria.Get(u => u.KategorieId == id);
            if (kategoriaFrmDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Kategoria.Remove(kategoriaFrmDb);
            _unitOfWork.Save();
            TempData["success"] = "Usunięto kategorię";
            return RedirectToAction("Index");
        }
    }
}

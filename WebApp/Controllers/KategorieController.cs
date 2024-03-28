using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NT.Models;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class KategorieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public KategorieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Kategorie> objCategoryList = _db.Kategorie.ToList();
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
                _db.Kategorie.Add(obj);
                _db.SaveChanges();
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
            Kategorie? kategoriaFrmDb = _db.Kategorie.Find(id);
            if (kategoriaFrmDb == null)
                return NotFound();

            return View(kategoriaFrmDb);
        }
        [HttpPost]
        public IActionResult Edit(Kategorie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Kategorie.Update(obj);
                _db.SaveChanges();
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
            Kategorie? kategoriaFrmDb = _db.Kategorie.Find(id);
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
            Kategorie? kategoriaFrmDb = _db.Kategorie.Find(id);
            if (kategoriaFrmDb == null)
            {
                return NotFound();
            }
            _db.Kategorie.Remove(kategoriaFrmDb);
            _db.SaveChanges();
            TempData["success"] = "Usunięto kategorię";
            return RedirectToAction("Index");
        }
    }
}

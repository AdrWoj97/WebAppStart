using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApp.Data;
using WebApp.Models;

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
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

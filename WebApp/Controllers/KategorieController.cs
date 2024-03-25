using Microsoft.AspNetCore.Mvc;
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
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testWebMVCApp.Data;
using testWebMVCApp.Models;

namespace testWebMVCApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        private ICrypto _cryptoService;

        public CategoryController(ApplicationDbContext db, ICrypto cryptoService)
        {
            _db = db;
            _cryptoService = cryptoService;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoriesList = _db.Categories.OrderBy(c => c.DisplayOrder);
            return View(categoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            var s = _cryptoService.EncryptString("scooby doo");

            if (category.Name.ToLower() == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot match the name!");
            }

            //cryptoServices.EncryptString("scooby doo");

            if (ModelState.IsValid)
            {
                var newName = category.Name;
                var match = _db.Categories.ToList().Where(c => string.Compare(c.Name, newName, StringComparison.InvariantCultureIgnoreCase) == 0);
                if (match.Any())
                {
                    ModelState.AddModelError("name", "Category name already exists!");
                }
                else
                {
                    category.LastChangedBy = "scott";
                    category.LastChangedTime = DateTime.Now;
                    category.CreatedDateTime = DateTime.Now;
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    TempData["success"] = "Movie added successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }

        public IActionResult Edit(int ?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name.ToLower() == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot match the name!");
            }

            if (ModelState.IsValid)
            {
                var newName = category.Name;
                var match = _db.Categories.AsNoTracking().ToList().Where(c => string.Compare(c.Name, newName, StringComparison.InvariantCultureIgnoreCase) == 0 && c.Id != category.Id);
                if (match.Any())
                {
                    ModelState.AddModelError("name", "Category name already exists in another record (name should be unique in the table). Please retry.");
                }
                else
                {
                    category.LastChangedBy = "scott";
                    category.LastChangedTime = DateTime.Now;
                   // category.CreatedDateTime = DateTime.Now;
                    _db.Categories.Update(category);
                    _db.SaveChanges();
                    TempData["success"] = "Movie updated successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            TempData["success"] = "Movie removed from list successfully";
            _db.SaveChanges();
            return RedirectToAction("Index");

            //try {
            //    // category.CreatedDateTime = DateTime.Now;
            //    _db.Categories.Remove(category);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");

            //}
            //catch (Exception ex) 
            //{
            //    ModelState.AddModelError("name", $"Error with deleting record. {ex.Message}");
            //    return View(category);
            //}
        }

    }
}

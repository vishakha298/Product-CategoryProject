using CrudApplication1.Data;
using CrudApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext context;

        public   ProductController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Products.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var pro = new Product()
                {
                    PName = model.PName,
                    Id1 = model.Id1,
                    CName = model.CName
                };
                context.Products.Add(pro);
                context.SaveChanges();
                TempData["error"] = "record saved";
                return RedirectToAction("Index");
                
            }
            else
            {
                TempData["error"] = "empty field cant submit";

                return View(model);
            }
        }
        public IActionResult Delete(int id)
            {
            var pro = context.Products.SingleOrDefault(p => p.Id == id);
            context.Products.Remove(pro);
            context.SaveChanges();
            TempData["error"] = "record deleted";
            return RedirectToAction("Index");
        }
         public IActionResult Edit(int id)
        {
            var pro= context.Products.SingleOrDefault(p => p.Id == id);
            var result = new Product()
            {
                PName = pro.PName,
                Id1 = pro.Id1,
                CName = pro.CName


            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var pro = new Product()
            {
                Id=model.Id,
                PName = model.PName,
                Id1 = model.Id1,
                CName = model.CName

            };
            context.Products.Update(pro);
            context.SaveChanges();
            TempData["error"] = "record updated";
            return RedirectToAction("Index");
        }
    }
}

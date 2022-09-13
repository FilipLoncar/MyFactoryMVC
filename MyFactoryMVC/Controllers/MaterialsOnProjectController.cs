using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFactoryMVC.Data;
using MyFactoryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFactoryMVC.Controllers
{
    [Authorize]
    [Authorize(Roles = "SUPERADMIN, Radnik")]
    public class MaterialsOnProjectController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MaterialsOnProjectController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var product = _applicationDbContext.Products.Include(x => x.Materials).ToList();  
            var productsVM = product.Select(x => x.MapToVM()).ToList();           
            
            return View(productsVM);
        }

        public IActionResult AssignMaterialToProject()
        {
            var model = new ProductionViewModel
            {
                Products = _applicationDbContext.Products.Include(x => x.Materials).Select(y => y.MapToVM()).ToList(),
                Materials = _applicationDbContext.Materials.Select(x => x.MapToVM()).ToList()
            };
           
            return View(model);
        }


        [HttpPost]
        public JsonResult Insert(int[] emp, int proj)
        {
            try
            {
                var project = _applicationDbContext.Products.Where(x => x.Id == proj).FirstOrDefault();
                var materials = _applicationDbContext.Materials.Where(x => emp.Contains(x.Id)).ToList();
                project.Materials = materials;

                _applicationDbContext.Products.Update(project);
                _applicationDbContext.SaveChanges();
            
                return new JsonResult("ok");
            }
            catch (Exception e)
            {
                return new JsonResult("failed");
            }
        }

    }

}

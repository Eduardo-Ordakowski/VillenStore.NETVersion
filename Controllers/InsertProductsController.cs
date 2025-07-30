using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VillenStore._NET_Version.Data;
using VillenStore._NET_Version.Models;

namespace VillenStore._NET_Version.Controllers
{
    public class InsertProductsController : Controller
    {
        readonly ApplicationDbContext _db;
        
        public InsertProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var ViewModel = new InsertProductViewModel
            {
                ProductList = _db.Products.ToList(),

                NewProduct = new ProductModel()
            };

                return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(InsertProductViewModel ViewModel)
        {
            var ProductToCreate = ViewModel.NewProduct;
            if(ModelState.IsValid)
            {
                if(ProductToCreate.ImageFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    { 
                        await ProductToCreate.ImageFile.CopyToAsync(memoryStream);
                        byte[] fileBytes = memoryStream.ToArray();

                        string base64String = Convert.ToBase64String(fileBytes);

                        ProductToCreate.ImgUrl = $"data:{ProductToCreate.ImageFile.ContentType};base64,{base64String}";
                    }
                }
                _db.Products.Add(ProductToCreate);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewModel.ProductList = _db.Products.ToList();

            return View("Index", ViewModel);
        }
    }
}

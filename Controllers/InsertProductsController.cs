using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create(InsertProductViewModel ViewModel)
        {
            var ProductToCreate = ViewModel.NewProduct;
            if (ModelState.IsValid)
            {
                if (ProductToCreate.ImageFile != null)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {

            var ProductToDelete = _db.Products.Find(Id);

            if (ProductToDelete == null)
            {
                return NotFound();
            }

            _db.Products.Remove(ProductToDelete);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var ProductToEdit = _db.Products.Find(Id);

            if (ProductToEdit == null)
            {
                return NotFound();
            }

            return Json(ProductToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Update(InsertProductViewModel ViewModel)
        {   
            if(ModelState.IsValid)
            {
                var ProductToUpdate = _db.Products.Find(ViewModel.NewProduct.Id);

                if(ProductToUpdate == null)
                {
                    return NotFound();
                }

                ProductToUpdate.Name = ViewModel.NewProduct.Name;
                ProductToUpdate.Price = ViewModel.NewProduct.Price;
                ProductToUpdate.Type = ViewModel.NewProduct.Type;

                if (ViewModel.NewProduct.ImageFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await ViewModel.NewProduct.ImageFile.CopyToAsync(memoryStream);
                        byte[] fileBytes = memoryStream.ToArray();

                        string base64String = Convert.ToBase64String(fileBytes);

                        ProductToUpdate.ImgUrl = $"data:{ViewModel.NewProduct.ImageFile.ContentType};base64,{base64String}";
                    }
                }

                _db.Products.Update(ProductToUpdate);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewModel.ProductList = _db.Products.ToList();

            return RedirectToAction("Index");
        }
    }
}

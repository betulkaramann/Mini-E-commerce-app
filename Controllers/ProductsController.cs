using Microsoft.AspNetCore.Mvc;
using Model_Binding.Helpers;
using Model_Binding.Models;

namespace Model_Binding.Controllers
{
    public class ProductsController : Controller

        
    {

        private AppDbContext _context;
        private IHelper _helper;
        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context , IHelper helper) { 

            _productRepository = new ProductRepository();
            _helper = helper;
            _context = context;
           
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            var text = "Asp.Net";
            var upperText = _helper.Upper(text);
            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //Product u parametre olarak direkt almak tip güvenli olarak çalışmamızı sağlar
        public IActionResult Add(Product newProduct)
        {

            //ürünleri veritabanına çeken kod
            //bunun parametreden yollanışı şekinde de yapılabilir.
           // var name = HttpContext.Request.Form["Name"].ToString();
           // var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
           // var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
           // var color = HttpContext.Request.Form["Color"].ToString();

           //Product newProduct = new Product() { Name = name, Price= price, Stock= stock, Color=color };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            //HttpPostların sayfası olmaz o yüzden bu classtaki Index fonksiyonuna yönlendirdik
            return RedirectToAction("Index");
        }
        
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);

        }

        [HttpPost]
        public IActionResult Update(Product selectedProduct) {
            _context.Products.Update(selectedProduct);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentStoreManagementSystemWebApp.BLL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.Controllers
{
    public class ProductController : Controller
    {
        BrandManager myBrandManager = new BrandManager();
        SupplierManager mySupplierManager = new SupplierManager();
        AddProductManager myAddProductManager = new AddProductManager();
       LogInManager myLogInManager = new LogInManager();

        //
        // GET: /Product/
        [HttpGet]
        public ActionResult Brand()
        {
            ViewBag.list = myBrandManager.GetAllBrand();
            return View();
        }
        [HttpPost]
        public ActionResult Brand(Brand brand)
        {
            ViewBag.message = myBrandManager.SaveBrand(brand);
            ViewBag.list = myBrandManager.GetAllBrand();
            return View();
        }
        [HttpGet]
        public ActionResult Supplier()
        {
            ViewBag.list = mySupplierManager.GetAllSupplier();
            return View();
        }
        [HttpPost]
        public ActionResult Supplier(Supplier brand)
        {
            ViewBag.message = mySupplierManager.Save(brand);
            ViewBag.list = mySupplierManager.GetAllSupplier();
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            int nu = myAddProductManager.GetNewCode();
            ViewBag.num = nu;
            ViewBag.list = myBrandManager.GetAllBrand();
            ViewBag.list2 = mySupplierManager.GetAllSupplier();
            ViewBag.list3 = myLogInManager.GetAllLogIn();
            

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(AddProduct addProduct)
        {
            ViewBag.message = myAddProductManager.SaveAddProduct(addProduct);
            ViewBag.list = myBrandManager.GetAllBrand();
            ViewBag.list2 = mySupplierManager.GetAllSupplier();
            ViewBag.list3 = myLogInManager.GetAllLogIn();
            ViewBag.num = myAddProductManager.GetNewCode();
            return View();
        }

        [HttpGet]
        public ActionResult UpdateProduct()
        {
            ViewBag.list = myBrandManager.GetAllBrand();
            ViewBag.list2 = mySupplierManager.GetAllSupplier();
            ViewBag.list3 = myLogInManager.GetAllLogIn();
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProduct(AddProduct addProduct)
        {
            ViewBag.list = myBrandManager.GetAllBrand();
            ViewBag.list2 = mySupplierManager.GetAllSupplier();
            ViewBag.list3 = myLogInManager.GetAllLogIn();
            ViewBag.message = myAddProductManager.UpdateSalesMan(addProduct);
            return View();
        }
        public JsonResult GetAllData(int code)
        {
            List<AddProduct> listData = myAddProductManager.GetAddProduct(code);
            return Json(listData);
        }
        [HttpGet]
        public ActionResult DeleteProduct()
        {
            ViewBag.list = myBrandManager.GetAllBrand();
            ViewBag.newList = myAddProductManager.GetProduct();
            
            return View();
        }
        [HttpPost]
        public ActionResult DeleteProduct(AddProduct addProduct)
        {
            ViewBag.list = myBrandManager.GetAllBrand();
            ViewBag.message = myAddProductManager.DeleteProduct(addProduct);
            ViewBag.newList = myAddProductManager.GetProduct();

            return View();
        }
        public JsonResult GetAllName(string code)
        {
            List<AddProduct> listName = myAddProductManager.GetAddProductByBrand(code);
            return Json(listName);
        }
        public JsonResult GetAllWeight(string num)
        {
            List<AddProduct> listWeight = myAddProductManager.GetWeightByName(num);
            return Json(listWeight);
        }
        [HttpGet]
        public ActionResult ProductByBrand()
        {
            ViewBag.brand = myBrandManager.GetAllBrand();
            return View();
        }
        [HttpPost]
        public ActionResult ProductByBrand(AddProduct addProduct)
        {
            ViewBag.brand = myBrandManager.GetAllBrand();
            ViewBag.products = myAddProductManager.GetProductByBrandView(addProduct.Brand);
            return View();
        }
        [HttpGet]
        public ActionResult StockIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StockIn(AddProduct add, int stockIn)
        {
            ViewBag.message = myAddProductManager.StockIn(add, stockIn);
            return View();
        }
        public JsonResult GetAllProductForStockIn(string codeNo)
        {
            List<AddProduct> listName = myAddProductManager.GetAddProductByBrand(codeNo);
            return Json(listName);
        }

	}
}
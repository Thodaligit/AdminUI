﻿using AdminUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static AdminUI.MvcApplication;
using OfficeOpenXml;

namespace AdminUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductCategories
        public async Task<ActionResult> Index()
        {
            List<ProductBL> ProductInfo = new List<ProductBL>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/Product/");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ProductInfo = JsonConvert.DeserializeObject<List<ProductBL>>(ProResponse);
                }
                //returning the employee list to view
                return View(ProductInfo);
            }
        }


        public async Task<ActionResult> Create()
        {

            ProductBL product = new ProductBL();
            List<ProductSubcategoryBL> productsubcategories = new List<ProductSubcategoryBL>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/ProductSubCategories/");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    productsubcategories = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
            }
            ViewBag.ProductSubCategoryId = new SelectList(productsubcategories, "ProductSubCategoryId", "ProductSubCategoryName");

            return View(product);
        }

            [HttpPost]
        public async Task<ActionResult> Create(ProductBL product)
        {
            product.IsNeedsToDelete = false;

            ProductBLVM objProductBLVM = new ProductBLVM();
            objProductBLVM.ObjProductBLList.Add(product);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objProductBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("https://localhost:44390/api/Product/", content);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //ProductInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return RedirectToAction("Index");
            }
        }


        public async Task<ActionResult> Edit(int ProductId)
        {
            try
            {
                ProductBL product = new ProductBL();
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/Product/" + ProductId);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        product = JsonConvert.DeserializeObject<ProductBL>(ProResponse);
                    }

                }

                return View(product);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductBL product)
        {
            product.IsNeedsToDelete = false;

            ProductBLVM objProductBLVM = new ProductBLVM();
            objProductBLVM.ObjProductBLList.Add(product);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objProductBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("https://localhost:44390/api/Product/", content);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //ProductInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return RedirectToAction("Index");
            }

        }

        public async Task<ActionResult> Details(int ProductId)
        {
            ProductBL product = new ProductBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/Product/" + ProductId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    product = JsonConvert.DeserializeObject<ProductBL>(ProResponse);
                }
            }
            return View(product);
        }

        public async Task<ActionResult> Delete(int ProductId)
        {
            ProductBL product = new ProductBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/Product/" + ProductId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    product = JsonConvert.DeserializeObject<ProductBL>(ProResponse);
                }

            }
            return View(product);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(ProductBL product)
        {
            product.IsNeedsToDelete = true;

            ProductBLVM objProductBLVM = new ProductBLVM();
            objProductBLVM.ObjProductBLList.Add(product);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                JsonContent content = JsonContent.Create(objProductBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("https://localhost:44390/api/Product/", content);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //ProductInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
                //returning the employee list to view
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> UploadAsync(FormCollection formCollection)
        {
            ProductBLVM objProductBLVM = new ProductBLVM();

            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 1].Value != null)
                            {
                                var productBL = new ProductBL();
                                productBL.ProductId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                productBL.ProductSubCategoryId = Convert.ToInt32(workSheet.Cells[rowIterator, 2].Value);
                                productBL.ProductName = workSheet.Cells[rowIterator, 3].Value.ToString();
                                productBL.ProductPrice = Convert.ToDecimal(workSheet.Cells[rowIterator, 4].Value);
                                productBL.ProductDescription = workSheet.Cells[rowIterator, 5].Value.ToString();
                                productBL.Property1 = workSheet.Cells[rowIterator, 6].Value.ToString();
                                productBL.Property2 = workSheet.Cells[rowIterator, 7].Value.ToString();
                                productBL.Property3 = workSheet.Cells[rowIterator, 8].Value.ToString();
                                productBL.Property4 = workSheet.Cells[rowIterator, 9].Value.ToString();
                                productBL.Property5 = workSheet.Cells[rowIterator, 10].Value.ToString();
                                productBL.IsActive = Convert.ToBoolean(workSheet.Cells[rowIterator, 11].Value);
                                productBL.CreatedDate = Convert.ToDateTime(workSheet.Cells[rowIterator, 12].Value);


                                //productBL.ProductCategoryId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                //productBL.ProductCategoryName = workSheet.Cells[rowIterator, 2].Value.ToString();
                                objProductBLVM.ObjProductBLList.Add(productBL);
                            }
                        }
                    }
                }
            }

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JsonContent content = JsonContent.Create(objProductBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("https://localhost:44390/api/Product/", content);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    //var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //ProductInfo = JsonConvert.DeserializeObject<List<ProductSubcategoryBL>>(ProResponse);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
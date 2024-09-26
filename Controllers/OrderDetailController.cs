using AdminUI.Models;
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
    public class OrderDetailController : Controller
    {
        // GET: OrderDetails
        public async Task<ActionResult> Index()
        {
            List<OrderDetailBL> OrderDetailInfo = new List<OrderDetailBL>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/OrderDetail/");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    OrderDetailInfo = JsonConvert.DeserializeObject<List<OrderDetailBL>>(ProResponse);
                }
                //returning the employee list to view
                return View(OrderDetailInfo);
            }
        }


        public async Task<ActionResult> Create()

        {
            OrderDetailBL orderdetail = new OrderDetailBL();

            //Order Id List Drop : 1

            List<OrderBL> orders = new List<OrderBL>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/Order/");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    orders = JsonConvert.DeserializeObject<List<OrderBL>>(ProResponse);
                }
            }
            ViewBag.OrderId = new SelectList(orders.ToList(), "OrderId", "FirstName");

            //Product Id List Drop : 2

            List<ProductBL> products = new List<ProductBL>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/Product/");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    products = JsonConvert.DeserializeObject<List<ProductBL>>(ProResponse);
                }
            }
            ViewBag.ProductId = new SelectList(products.ToList(), "ProductId", "ProductName");
            return View(orderdetail);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderDetailBL orderdetail)
        {
            orderdetail.IsNeedsToDelete = false;

            OrderDetailBLVM objOrderDetailBLVM = new OrderDetailBLVM();
            objOrderDetailBLVM.ObjOrderDetailBLList.Add(orderdetail);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objOrderDetailBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("https://localhost:44390/api/OrderDetail/", content);
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


        public async Task<ActionResult> Edit(int OrderDetailId)
        {
            try
            {
                OrderDetailBL orderdetail = new OrderDetailBL();
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(GlobalValues.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/OrderDetail/" + OrderDetailId);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ProResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        orderdetail = JsonConvert.DeserializeObject<OrderDetailBL>(ProResponse);
                    }

                }

                return View(orderdetail);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(OrderDetailBL orderdetail)
        {
            orderdetail.IsNeedsToDelete = false;

            OrderDetailBLVM objOrderDetailBLVM = new OrderDetailBLVM();
            objOrderDetailBLVM.ObjOrderDetailBLList.Add(orderdetail);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonContent content = JsonContent.Create(objOrderDetailBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("https://localhost:44390/api/OrderDetail/", content);
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


        public async Task<ActionResult> Details(int OrderDetailId)
        {
            OrderDetailBL orderdetail = new OrderDetailBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/OrderDetail/" + OrderDetailId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    orderdetail = JsonConvert.DeserializeObject<OrderDetailBL>(ProResponse);
                }
            }
            return View(orderdetail);
        }

        public async Task<ActionResult> Delete(int OrderDetailId)
        {
            OrderDetailBL orderdetail = new OrderDetailBL();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44390/api/OrderDetail/" + OrderDetailId);
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    orderdetail = JsonConvert.DeserializeObject<OrderDetailBL>(ProResponse);
                }

            }
            return View(orderdetail);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(OrderDetailBL orderdetail)
        {
            orderdetail.IsNeedsToDelete = true;

            OrderDetailBLVM objOrderDetailBLVM = new OrderDetailBLVM();
            objOrderDetailBLVM.ObjOrderDetailBLList.Add(orderdetail);
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(GlobalValues.Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                JsonContent content = JsonContent.Create(objOrderDetailBLVM);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("https://localhost:44390/api/OrderDetail/", content);
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
            OrderDetailBLVM objOrderDetailBLVM = new OrderDetailBLVM();

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
                                var orderdetailBL = new OrderDetailBL();
                                orderdetailBL.OrderDetailId = Convert.ToInt32(workSheet.Cells[rowIterator, 1].Value);
                                orderdetailBL.OrderId = Convert.ToInt32(workSheet.Cells[rowIterator, 2].Value);
                                orderdetailBL.ProductId = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value);
                                orderdetailBL.Quantity = Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value);
                                orderdetailBL.UnitPrice = Convert.ToDecimal(workSheet.Cells[rowIterator, 5].Value);
                                orderdetailBL.IsActive = Convert.ToBoolean(workSheet.Cells[rowIterator, 6].Value);
                                orderdetailBL.CreatedDate = Convert.ToDateTime(workSheet.Cells[rowIterator, 7].Value);

                                objOrderDetailBLVM.ObjOrderDetailBLList.Add(orderdetailBL);
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

                JsonContent content = JsonContent.Create(objOrderDetailBLVM);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsync("https://localhost:44390/api/OrderDetail/", content);
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
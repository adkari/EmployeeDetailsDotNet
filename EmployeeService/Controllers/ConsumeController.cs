using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmployeeService.Controllers
{
    public class ConsumeController : Controller
    {
        // GET: Consume
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<SW_TBL_EMPLOYEE> list=new List<SW_TBL_EMPLOYEE>();
            client.BaseAddress = new Uri("https://localhost:44361/api/NewApi");
            var response = client.GetAsync("NewApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<SW_TBL_EMPLOYEE>>();
                display.Wait();
                list = display.Result;
            }
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SW_TBL_EMPLOYEE emp)
        {
            client.BaseAddress = new Uri("https://localhost:44361/api/NewApi");
            var response = client.PostAsJsonAsync<SW_TBL_EMPLOYEE>("NewApi", emp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        
        public ActionResult Edit(int id)
        {
            SW_TBL_EMPLOYEE e = null;
            client.BaseAddress = new Uri("https://localhost:44361/api/NewApi");
            var response = client.GetAsync("NewApi?id="+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<SW_TBL_EMPLOYEE>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(SW_TBL_EMPLOYEE e)
        {
            client.BaseAddress = new Uri("https://localhost:44361/api/NewApi");
            var response = client.PutAsJsonAsync<SW_TBL_EMPLOYEE>("NewApi", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
    }
}
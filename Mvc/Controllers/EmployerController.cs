using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class EmployerController : Controller
    {
        // GET: Employer
        public ActionResult Index()
        {
            IEnumerable<MvcEmployerModel> listEmployers;
            HttpResponseMessage response = GlobaleVariable.webApiClient.GetAsync("Employers").Result;
            listEmployers = response.Content.ReadAsAsync<IEnumerable<MvcEmployerModel>>().Result;
            return View(listEmployers);
        }
        public ActionResult AddOrEdit(int id=0)
        {
            if (id==0)
            {
            return View(new MvcEmployerModel());
            }
            else
            {
                MvcEmployerModel emp = new MvcEmployerModel();
                HttpResponseMessage response = GlobaleVariable.webApiClient.GetAsync("Employers/"+id.ToString()).Result;
                emp = response.Content.ReadAsAsync<MvcEmployerModel>().Result;
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcEmployerModel emp)
        {
            if (emp.EmployerId==0) 
            { 
                HttpResponseMessage response = GlobaleVariable.webApiClient.PostAsJsonAsync("Employers", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
                return RedirectToAction("index");
            }
            else
            {
                HttpResponseMessage response = GlobaleVariable.webApiClient.PutAsJsonAsync("Employers/"+ emp.EmployerId, emp).Result;
                TempData["SuccessMessage"] = "Your item has been update Successfully";

                return RedirectToAction("index");
            }
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobaleVariable.webApiClient.DeleteAsync("Employers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("index");
        }
    }
}
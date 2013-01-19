using MVC4_Using_NHB.Models;
using System.Web.Mvc;

namespace MVC4_Using_NHB.Controllers
{
    public class EmployeeInfoController : Controller
    {

        EmployeeInfoDAL objDs;

        public EmployeeInfoController()
        {
            objDs = new EmployeeInfoDAL(); 
        }

        //
        // GET: /EmployeeInfo/

        public ActionResult Index()
        {
            var Employees = objDs.GetEmployees();
            return View(Employees);
        }

        //
        // GET: /EmployeeInfo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /EmployeeInfo/Create

        public ActionResult Create()
        {
            var Emp = new EmployeeInfo();
            return View(Emp);
        }

        //
        // POST: /EmployeeInfo/Create

        [HttpPost]
        public ActionResult Create(EmployeeInfo Emp)
        {
            try
            {
                objDs.CreateEmployee(Emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EmployeeInfo/Edit/5

        public ActionResult Edit(int id)
        {
            var Emp = objDs.GetEmployeeById(id);
            return View(Emp);
        }

        //
        // POST: /EmployeeInfo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EmployeeInfo Emp)
        {
            try
            {
                objDs.UpdateEmployee(Emp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EmployeeInfo/Delete/5

        public ActionResult Delete(int id)
        {
            var Emp = objDs.GetEmployeeById(id);
            return View(Emp);
        }

        //
        // POST: /EmployeeInfo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            try
            {
                var Emp = objDs.GetEmployeeById(id);
                objDs.DeleteEmployee(Emp);   
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using Employee_Dept_Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Dept_Crud.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IConfiguration configuration;
        private DeptCrud crud;

        public DepartmentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new DeptCrud(this.configuration);
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var model = crud.GetDepartments();
            return View(model);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var result = crud.GetDepartmentById(id);
            return View(result);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dept)
        {
            try
            {
                int result = crud.AddDepartment(dept);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = crud.GetDepartmentById(id);
            return View(result);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dept)
        {
            try
            {
                int result = crud.UpdateDepartment(dept);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();

            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = crud.GetDepartmentById(id);
            return View(result);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteDepartment(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}

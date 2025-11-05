using HR_System.BLL.Interfaces;
using HR_System.BLL.Repositories;
using HR_System.DAL.Data.Contexts;
using HR_System.DAL.Models;
using HR_System.PL.Dtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var department = _departmentRepository.GetAll();

            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDepartmentDto model) {

            if (ModelState.IsValid) {
                var department = new Department() {
                    Name = model.Name,
                    Code = model.Code,
                    CreateAt = model.CreateAt
                };
                var count = _departmentRepository.Add(department);
                if (count > 0) {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult Details(int? id) {

            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound();

            return View(department);

        }
        [HttpGet]
        public IActionResult Edit(int? id) {

            if (id is null) return BadRequest();
             var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id ,EditDepartmentDto model )
        {
            if (ModelState.IsValid) {
                var department = new Department()
                {
                    Id = id,
                    Name = model.Name,
                    Code = model.Code,
                    CreateAt = model.CreateAt

                };
                var count = _departmentRepository.Update(department);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);

        }

        [HttpGet]

        public IActionResult Delete(int? id ) {
            if (id is null )return BadRequest();
            var department = _departmentRepository.Get(id.Value);
            if (department is null) return NotFound();

            return View(department);
        }

        [HttpPost]
        public IActionResult Delete([FromRoute]int id , Department model ) { 
        
         _departmentRepository.Delete(model);
            return RedirectToAction("Index");

        }
        }
}

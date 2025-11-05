using HR_System.BLL.Interfaces;
using HR_System.DAL.Data.Contexts;
using HR_System.DAL.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HrDbContext _context;

        public DepartmentRepository(HrDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
           return _context.Departments.ToList();
        }
        public Department? Get(int id)
        {
           return _context.Departments.Find(id);
        }
        public int Add(Department model)
        {
            _context.Add(model);
           return _context.SaveChanges();
        }

       

        public int Update(Department model)
        {
            _context.Update(model);
            return _context.SaveChanges();
        }
        public int Delete(Department model)
        {
            _context.Departments.Remove(model);
            return _context.SaveChanges();  
        }

    }
}

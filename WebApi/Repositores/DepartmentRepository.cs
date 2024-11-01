using WebApi.Models;

namespace WebApi.Repositores
{
    public class DepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        public Department? GetbyId(int id) 
        {
            return _context.Departments.FirstOrDefault(x =>x.Id==id);
        }
        public Department? GetbyName(string name)
        {
            return _context.Departments.FirstOrDefault(x => x.Name == name);
        }
        public void DeleteById(int id) 
        {
             Department? dept = _context.Departments.Find(id);
            _context.Departments.Remove(dept);
            _context.SaveChanges();
        }
        public void Creat_Department(Department dept) 
        {
             _context.Departments.Add(dept);
            _context.SaveChanges();
        }
        public void Update(Department dept)
        {
            _context.Update(dept);  
            _context.SaveChanges();
        }
    }
}

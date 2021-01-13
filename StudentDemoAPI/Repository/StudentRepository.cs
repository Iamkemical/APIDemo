using StudentDemoAPI.DataAccess;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateStudent(StudentModel studentModel)
        {
            _dbContext.Student.Add(studentModel);
            return Save();
        }

        public bool DeleteStudent(StudentModel studentModel)
        {
            _dbContext.Student.Remove(studentModel);
            return Save();
        }

        public IEnumerable<StudentModel> GetAllStudent()
        {
            return _dbContext.Student.OrderBy(a => a.StudentID).ToList();
        }

        public StudentModel GetStudentById(int id)
        {
            return _dbContext.Student.FirstOrDefault(a => a.StudentID == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public bool StudentExist(int id)
        {
            bool value = _dbContext.Student.Any(a => a.StudentID == id);
            return value;
        }

        public bool UpdateStudent(StudentModel studentModel)
        {
            _dbContext.Student.Update(studentModel);
            return Save();
        }
    }
}

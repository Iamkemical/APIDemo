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

        /// <summary>
        /// This initialises the ApplicationDbContext from the DI Container
        /// </summary>
        /// <param name="dbContext"></param>
        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates student by adding the studentModel parameter to the Student EFCore instance.
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        public bool CreateStudent(StudentModel studentModel)
        {
            _dbContext.Student.Add(studentModel);
            return Save();
        }

        /// <summary>
        /// Deletes student by removing the studentModel parameter from the Student EFCore instance.
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>

        public bool DeleteStudent(StudentModel studentModel)
        {
            _dbContext.Student.Remove(studentModel);
            return Save();
        }

        /// <summary>
        /// Gets all the student from the database using EFCore.
        /// </summary>
        /// <returns></returns>

        public IEnumerable<StudentModel> GetAllStudent()
        {
            return _dbContext.Student.OrderBy(a => a.StudentID).ToList();
        }

        /// <summary>
        /// Gets a student entity based on the id passed using EFCore.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public StudentModel GetStudentById(int id)
        {
            return _dbContext.Student.FirstOrDefault(a => a.StudentID == id);
        }

        /// <summary>
        /// Saves all the changes based on actions such as the create, update
        /// and delete actions on the database using EFCore.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        /// <summary>
        /// returns a boolean if the student exist based on the id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool StudentExist(int id)
        {
            bool value = _dbContext.Student.Any(a => a.StudentID == id);
            return value;
        }

        /// <summary>
        /// updates the student entity passed into the studentModel parameter.
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        public bool UpdateStudent(StudentModel studentModel)
        {
            _dbContext.Student.Update(studentModel);
            return Save();
        }
    }
}

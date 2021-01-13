using StudentDemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repository.IRepository
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> GetAllStudent();
        StudentModel GetStudentById(int id);
        bool StudentExist(int id);
        bool CreateStudent(StudentModel studentModel);
        bool DeleteStudent(StudentModel studentModel);
        bool UpdateStudent(StudentModel studentModel);
        bool Save();
    }
}

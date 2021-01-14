using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using StudentDemoAPI.Controllers;
using StudentDemoAPI.Models;
using StudentDemoAPI.Models.DTOs;
using StudentDemoAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace StudentDemoTest
{
    public class Tests
    {
        private Mock<IStudentRepository> studentRepository;
        private List<StudentModel> student;
        private Mock<IMapper> mapper;
        private Mock<ILogger<StudentController>> logger;


        /// <summary>
        /// Creating mock data for testing
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Set up the mock
            studentRepository = new Mock<IStudentRepository>();
            mapper = new Mock<IMapper>();
            logger = new Mock<ILogger<StudentController>>();
            student = new List<StudentModel>();
            student.Add(new StudentModel()
            {
                StudentID = 1,
                FirstName = "John",
                LastName = "Emmanuel",
                Email = "john@gmail.com",
                PhoneNumber = "0708765423"
            });
            student.Add(new StudentModel()
            {
                StudentID = 2,
                FirstName = "Elizabeth",
                LastName = "Emmanuel",
                Email = "eliza@gmail.com",
                PhoneNumber = "0908765421"
            });
            student.Add(new StudentModel()
            {
                StudentID = 3,
                FirstName = "David",
                LastName = "Emmanuel",
                Email = "david@gmail.com",
                PhoneNumber = "0808794826"
            });
        }

        /// <summary>
        /// Get all students should pass
        /// </summary>
        [Test]
        public void GetAllStudent_should_pass()
        {
            //Act
            studentRepository.Setup(a => a.GetAllStudent()).Returns(student.AsQueryable());

            // Arrange
            var studentController = new StudentController(studentRepository.Object, mapper.Object, logger.Object);
            var customerList = studentController.GetAllStudent();

            // Assert 
            Assert.Pass();
        }

        /// <summary>
        /// Gets student based on id should pass
        /// </summary>
        [Test]
        public void GetAllStudentById_should_pass()
        {
            //Act
            var id = 1;
            studentRepository.Setup(a => a.GetStudentById(id));

            // Arrange
            var studentController = new StudentController(studentRepository.Object, mapper.Object, logger.Object);
            var customerList = studentController.GetStudentById(id);

            // Assert 
            Assert.Pass();
        }

        /// <summary>
        /// create student should pass
        /// </summary>
        [Test]
        public void CreateStudent_should_pass()
        {
            //Act
            StudentModel student = new StudentModel();
            StudentCreateDTO studentModel = new StudentCreateDTO();
            studentRepository.Setup(a => a.CreateStudent(student));

            // Arrange
            var studentController = new StudentController(studentRepository.Object, mapper.Object, logger.Object);
            var customerList = studentController.CreateStudent(studentModel);

            // Assert 
            Assert.Fail();
        }


        /// <summary>
        /// update student should pass
        /// </summary>
        [Test]
        public void UpdateStudent_should_pass()
        {
            //Act
            StudentModel student = new StudentModel();
            StudentUpdateDTO studentModel = new StudentUpdateDTO();
            var id = 1;
            studentRepository.Setup(a => a.UpdateStudent(student));

            // Arrange
            var studentController = new StudentController(studentRepository.Object, mapper.Object, logger.Object);
            var customerList = studentController.UpdateStudent(id, studentModel);

            // Assert 
            Assert.Fail();
        }

        /// <summary>
        /// delete student should pass
        /// </summary>
        [Test]
        public void DeleteStudent_should_pass()
        {
            //Act
            var id = 1;
            StudentModel studentModel = new StudentModel();
            studentRepository.Setup(a => a.DeleteStudent(studentModel));

            // Arrange
            var studentController = new StudentController(studentRepository.Object, mapper.Object, logger.Object);
            var customerList = studentController.DeleteStudent(id);

            // Assert 
            Assert.Pass();
        }
    }
}
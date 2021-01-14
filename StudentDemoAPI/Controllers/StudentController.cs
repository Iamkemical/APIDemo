using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentDemoAPI.Models;
using StudentDemoAPI.Models.DTOs;
using StudentDemoAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.Controllers
{
    [Route("api/v{version:apiVersion}/student")]
    //[Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(400)]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepo,
            IMapper mapper, ILogger<StudentController> logger)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into StudentController");
        }

        /// <summary>
        /// Gets all the student in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<StudentDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllStudent()
        {
            var objList = _studentRepo.GetAllStudent();

            var objDto = new List<StudentDTO>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<StudentDTO>(obj));
            }

            return Ok(objDto);
        }
        /// <summary>
        /// Get individual student in database based on id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("{studentId:int}", Name = "GetStudentById")]
        [ProducesResponseType(200, Type = typeof(List<StudentDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetStudentById(int studentId)
        {
            var obj = _studentRepo.GetStudentById(studentId);

            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<StudentDTO>(obj);

            return Ok(objDto);
        }

        /// <summary>
        /// Create new student
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(List<StudentDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateStudent([FromBody] StudentCreateDTO studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentObj = _mapper.Map<StudentModel>(studentDto);

            if (!_studentRepo.CreateStudent(studentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {studentObj.FirstName}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetStudentById", new
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                studentId = studentObj.StudentID
            }, studentObj);
        }

        /// <summary>
        /// Updates any part of the student particulars
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPut("{studentId:int}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateStudent(int studentId, [FromBody] StudentUpdateDTO studentDto)
        {
            if (studentDto == null || studentId != studentDto.StudentID)
            {
                return BadRequest(ModelState);
            }

            var studentObj = _mapper.Map<StudentModel>(studentDto);

            if (!_studentRepo.UpdateStudent(studentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {studentObj.FirstName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Partially Update student particulars
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{studentId:int}", Name = "PartialUpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PartialUpdateStudent(int studentId, JsonPatchDocument<StudentUpdateDTO> patchDoc)
        {
            var student = _studentRepo.GetStudentById(studentId);
            if (student == null)
            {
                return NotFound();
            }
            var studentPatchDto = _mapper.Map<StudentUpdateDTO>(student);

            patchDoc.ApplyTo(studentPatchDto, ModelState);

            if (!TryValidateModel(studentPatchDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentPatchDto, student);

            _studentRepo.UpdateStudent(student);

            _studentRepo.Save();

            return NoContent();
        }

        /// <summary>
        /// Delete Student from the database
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpDelete("{studentId:int}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteStudent(int studentId)
        {
            if (!_studentRepo.StudentExist(studentId))
            {
                return NotFound();
            }

            var studentObj = _studentRepo.GetStudentById(studentId);

            if (!_studentRepo.DeleteStudent(studentObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {studentObj.FirstName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}

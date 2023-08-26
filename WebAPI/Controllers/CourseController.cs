using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _courseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _courseService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Course entity)
        {
            var result = _courseService.AddCourse(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Course entity)
        {
            var result = _courseService.UpdateCourse(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _courseService.DeleteCourse(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllCoursesDetails")]
        public IActionResult GetAllCoursesDetails()
        {
            var result = _courseService.GetAllCoursesDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllCoursesDetailsByTeacherId")]
        public IActionResult GetAllCoursesDetailsByTeacherId(int userId)
        {
            var result = _courseService.GetAllCoursesDetailsByTeacherId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAllEnrolledCoursesDetailsByStudentId")]
        public IActionResult GetAllEnrolledCoursesDetailsByStudentId(int userId)
        {
            var result = _courseService.GetAllEnrolledCoursesDetailsByStudentId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //GetAllCoursesDetails
        // GetAllCoursesDetailsByTeacherId
        // GetAllEnrolledCoursesDetailsByStudentId
    }
}

using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("registerStudent")]
        public IActionResult RegisterStudent(StudentRegisterDto studentRegisterDto)
        {
            var userexists = _authService.UserExists(studentRegisterDto.Email);
            if (!userexists.Success)
            {
                return BadRequest(userexists.Message);
            }

            var registerResult = _authService.RegisterStudent(studentRegisterDto, studentRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("registerTeacher")]
        public IActionResult RegisterTeacher(TeacherRegisterDto teacherRegisterDto)
        {
            var userexists = _authService.UserExists(teacherRegisterDto.Email);
            if (!userexists.Success)
            {
                return BadRequest(userexists.Message);
            }

            var registerResult = _authService.RegisterTeacher(teacherRegisterDto, teacherRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getstudentdetailbyuserıd")]
        public IActionResult GetStudentDetailByUserId(int userId)
        {
            var result = _userService.GetStudentDetailByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getteacherdetailbyuserıd")]
        public IActionResult GetTeacherDetailByUserId(int userId)
        {
            var result = _userService.GetTeacherDetailByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}

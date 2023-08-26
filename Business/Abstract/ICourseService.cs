using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<List<Course>> GetAll();
        public IDataResult<Course> GetById(int id);
        public IDataResult<Course> AddCourse(Course entity);
        public IResult UpdateCourse(Course entity);
        public IResult DeleteCourse(int id);
        IDataResult<List<CourseDetailDto>> GetAllCoursesDetails();
        IDataResult<List<CourseDetailDto>>GetAllCoursesDetailsByTeacherId(int userId);

        IDataResult<List<CourseDetailDto>> GetAllEnrolledCoursesDetailsByStudentId(int userId);
    }
}

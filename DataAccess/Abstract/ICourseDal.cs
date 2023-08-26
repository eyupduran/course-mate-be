using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>
    {
        List<CourseDetailDto> GetAllCoursesDetails();
        List<CourseDetailDto> GetAllCoursesDetailsByTeacherId(int userId);
        List<CourseDetailDto> GetAllEnrolledCoursesDetailsByStudentId(int userId);


    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseTeacherService
    {
        IDataResult<List<CourseTeacher>> GetAll();
        public IDataResult<CourseTeacher> GetById(int id);
        public IDataResult<CourseTeacher> AddCourseTeacher(CourseTeacher entity);
        public IResult UpdateCourseTeacher(CourseTeacher entity);
        public IResult DeleteCourseTeacher(CourseTeacher entity);
        public IResult DeleteById(int id);

    }
}

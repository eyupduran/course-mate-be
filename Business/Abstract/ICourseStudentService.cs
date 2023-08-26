using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseStudentService
    {
        IDataResult<List<CourseStudent>> GetAll();
        public IDataResult<CourseStudent> GetById(int id);
        public IResult AddCourseStudent(CourseStudent entity);
        public IResult UpdateCourseStudent(CourseStudent entity);
        public IResult DeleteCourseStudent(CourseStudent entity);
        public IResult DeleteCourseById(int id);

    }
}


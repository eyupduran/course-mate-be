using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IDataResult<List<Student>> GetAll();
        public IDataResult<Student> GetById(int id);
        public IResult UpdateStudent(Student entity);
        public IResult DeleteStudent(Student entity);
        IDataResult< List<StudentOfCourseDetails>> GetAllStudentsOfCourseDetailByTeacherId(int userId, int courseId);

        public IResult DeleteById(int id);



    }
}


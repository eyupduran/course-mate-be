using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentManager:IStudentService
    {
        public IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public IDataResult<List<Student>> GetAll()
        {
            if (_studentDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Student>>(_studentDal.GetAll(), Messages.CompanyListed);
            }

            return new ErrorDataResult<List<Student>>(Messages.NotFoundCompany);
        }

        public IDataResult<Student> GetById(int id)
        {
            return new SuccessDataResult<Student>(_studentDal.Get(h => h.Id == id));
        }


        public IResult UpdateStudent(Student entity)
        {
            _studentDal.Update(entity);
            return new SuccessResult(Messages.CompanyUpdated);
        }

        public IResult DeleteStudent(Student entity)
        {
            _studentDal.Delete(entity);
            return new SuccessResult(Messages.CompanyDeleted);
        }

        public IDataResult< List<StudentOfCourseDetails>> GetAllStudentsOfCourseDetailByTeacherId(int userId, int courseId)
        {
            return new SuccessDataResult<List<StudentOfCourseDetails>>(_studentDal.GetAllStudentsOfCourseDetailByTeacherId(userId, courseId));
        }

        public IResult DeleteById(int id)
        {
            _studentDal.DeleteById(id);
            return new SuccessResult("successfully deleted");
        }
    }
}

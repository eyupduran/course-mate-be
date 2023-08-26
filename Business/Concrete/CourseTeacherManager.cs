using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseTeacherManager : ICourseTeacherService
    {
        public ICourseTeacherDal _courseTeacherDal;
        public CourseTeacherManager(ICourseTeacherDal courseTeacherDal)
        {

            _courseTeacherDal = courseTeacherDal;
        }
        public IDataResult<List<CourseTeacher>> GetAll()
        {
            if (_courseTeacherDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<CourseTeacher>>(_courseTeacherDal.GetAll(), Messages.CompanyListed);
            }

            return new ErrorDataResult<List<CourseTeacher>>(Messages.NotFoundCompany);
        }

        public IDataResult<CourseTeacher> GetById(int id)
        {
            return new SuccessDataResult<CourseTeacher>(_courseTeacherDal.Get(h => h.Id == id));
        }
        public IDataResult<CourseTeacher> AddCourseTeacher(CourseTeacher entity)
        {
            _courseTeacherDal.Add(entity);
            return new SuccessDataResult<CourseTeacher>(entity);
        }

        public IResult UpdateCourseTeacher(CourseTeacher entity)
        {
            _courseTeacherDal.Update(entity);
            return new SuccessResult(Messages.CompanyUpdated);
        }

        public IResult DeleteCourseTeacher(CourseTeacher entity)
        {
            _courseTeacherDal.Delete(entity);
            return new SuccessResult(Messages.CompanyDeleted);
        }
        public IResult DeleteById(int id)
        {
            _courseTeacherDal.DeleteById(id);
            return new SuccessResult("Successfully deleted");

        }
    }
}

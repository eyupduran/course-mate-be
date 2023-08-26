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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business.Concrete
{
    public class CourseManager:ICourseService
    {
        public ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal) {
            _courseDal = courseDal;
        }
        public IDataResult<List<Course>> GetAll()
        {
            if (_courseDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Course>>(_courseDal.GetAll(), Messages.CompanyListed);
            }

            return new ErrorDataResult<List<Course>>(Messages.NotFoundCompany);
        }

        public IDataResult<Course> GetById(int id)
        {
            return new SuccessDataResult<Course>(_courseDal.Get(h => h.Id == id));
        }
        public IDataResult<Course> AddCourse(Course entity)
        {
            _courseDal.Add(entity);
            return new SuccessDataResult<Course>(entity);
        }

        public IResult UpdateCourse(Course entity)
        {
            _courseDal.Update(entity);
            return new SuccessResult(Messages.CompanyUpdated);
        }

        public IResult DeleteCourse(int id)
        {
            _courseDal.DeleteById(id);
            return new SuccessResult("deleted successfully");
        }

        public IDataResult<List<CourseDetailDto>> GetAllCoursesDetails()
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetAllCoursesDetails());
        }

        public IDataResult<List<CourseDetailDto>> GetAllCoursesDetailsByTeacherId(int userId)
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetAllCoursesDetailsByTeacherId(userId));

        }

        public IDataResult<List<CourseDetailDto>> GetAllEnrolledCoursesDetailsByStudentId(int userId)
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetAllEnrolledCoursesDetailsByStudentId(userId));
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseStudentManager:ICourseStudentService
    {
        public ICourseStudentDal _courseStudentDal;
        public ICourseDal _courseDal;
        public CourseStudentManager(ICourseStudentDal courseStudentDal, ICourseDal courseDal)
        {
            _courseStudentDal = courseStudentDal;
            _courseDal = courseDal;
        }
        public IDataResult<List<CourseStudent>> GetAll()
        {
            if (_courseStudentDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<CourseStudent>>(_courseStudentDal.GetAll(), Messages.CompanyListed);
            }

            return new ErrorDataResult<List<CourseStudent>>(Messages.NotFoundCompany);
        }

        public IDataResult<CourseStudent> GetById(int id)
        {
            return new SuccessDataResult<CourseStudent>(_courseStudentDal.Get(h => h.Id == id));
        }
        public IResult AddCourseStudent(CourseStudent entity)
        {
            var element = _courseStudentDal.ControlRecord(entity.StudentId, entity.CourseId);
            var courseToUpdate = _courseDal.Get(e => e.Id == entity.CourseId);


            if (element != null)
            {
                return new ErrorResult("Bu kursu zaten aldınız.");
            }
            else if (courseToUpdate.Quota > 0)
            {
                _courseStudentDal.Add(entity);
                courseToUpdate.Quota -= 1;
                _courseDal.Update(courseToUpdate);
                return new SuccessDataResult<CourseStudent>(entity);
            }
            else
            {
            return new ErrorResult("Kurs kapasitesi bitmiştir.");
                
            }

        }




        public IResult UpdateCourseStudent(CourseStudent entity)
        {
            _courseStudentDal.Update(entity);
            return new SuccessResult(Messages.CompanyUpdated);
        }

        public IResult DeleteCourseStudent(CourseStudent entity)
        {
            _courseStudentDal.Delete(entity);
            var courseToUpdate = _courseDal.Get(e => e.Id == entity.CourseId);
            courseToUpdate.Quota += 1;
            _courseDal.Update(courseToUpdate);
            return new SuccessResult(Messages.CompanyDeleted);
        }

        public IResult DeleteCourseById(int id)
        {
            _courseStudentDal.DeleteById(id);
            return new SuccessResult("Successfully deleted");

        }
    }
}

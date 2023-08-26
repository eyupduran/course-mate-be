using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TeacherManager:ITeacherService
    {
        public ITeacherDal _teacherDal;
        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }
        public IDataResult<List<Teacher>> GetAll()
        {
            if (_teacherDal.GetAll().Count > 0)
            {
                return new SuccessDataResult<List<Teacher>>(_teacherDal.GetAll(), Messages.CompanyListed);
            }

            return new ErrorDataResult<List<Teacher>>(Messages.NotFoundCompany);
        }

        public IDataResult<Teacher> GetById(int id)
        {
            return new SuccessDataResult<Teacher>(_teacherDal.Get(h => h.Id == id));
        }


        public IResult UpdateStudent(Teacher entity)
        {
            _teacherDal.Update(entity);
            return new SuccessResult(Messages.CompanyUpdated);
        }

        public IResult DeleteStudent(Teacher entity)
        {
            _teacherDal.Delete(entity);
            return new SuccessResult(Messages.CompanyDeleted);
        }

  

        public IResult DeleteById(int id)
        {
            _teacherDal.DeleteById(id);
            return new SuccessResult("successfully deleted");
        }
    }
}


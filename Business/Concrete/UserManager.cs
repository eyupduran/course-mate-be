    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Business.Abstract;
    using Business.Constants;
    using Business.Services.ImageService.Abstracts;
    using Core.Entities.Concrete;
    using Core.Utilities.Business;
    using Core.Utilities.Results;
    using Core.Utilities.Security.Hashing;
    using DataAccess.Abstract;
    using Entities.Concrete;
    using Entities.DTOs;
    using Microsoft.AspNetCore.Http;

    namespace Business.Concrete
    {
        public class UserManager : IUserService
        {
            IUserDal _userDal;

            public UserManager(IUserDal userDal)
            {
                _userDal = userDal;
            }

            public List< OperationClaim> GetClaims(User user)
            {
                return _userDal.GetClaims(user.Id);
            }

            public void Add(User user)
            {
                _userDal.Add(user);
            }

            public User GetByMail(string email)
            {
                return _userDal.Get(u => u.Email == email);
            }

         

            public DataResult<StudentDetailDto> GetStudentDetailByUserId(int userId)
            {
            return new SuccessDataResult<StudentDetailDto>(this._userDal.GetStudentDetailByUserId(userId));
            }

            public DataResult<TeacherDetailDto> GetTeacherDetailByUserId(int userId)
            {
                return new SuccessDataResult<TeacherDetailDto>(this._userDal.GetTeacherDetailByUserId(userId));
            }

        public DataResult<List<StudentDetailDto>> GetAllStudents()
        {
            return new SuccessDataResult<List<StudentDetailDto>>(this._userDal.GetAllStudents());
        }

        public DataResult<List<TeacherDetailDto>> GetAllTeachers()
        {
            return new SuccessDataResult<List<TeacherDetailDto>>(this._userDal.GetAllTeachers());

        }
    }
    }

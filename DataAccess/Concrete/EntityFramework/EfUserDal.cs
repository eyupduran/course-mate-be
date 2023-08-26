using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,CeswaContext>,IUserDal
    {
        public List<StudentDetailDto> GetAllStudents()
        {
            using (var context = new CeswaContext())
            {
                var result = from u in context.Users
                             join s in context.Students on u.Id equals s.Id
                             select new StudentDetailDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = "student",
                                 StudentDetail = s.StudentDetail,
                                 GraduationStatus = s.GraduationStatus
                             };

                return result.ToList();
            }
        }

        public List<TeacherDetailDto> GetAllTeachers()
        {
            using (var context = new CeswaContext())
            {
                var result = from u in context.Users
                             join t in context.Teachers on u.Id equals t.Id
                             select new TeacherDetailDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = "teacher",
                                 Education = t.Education,
                                 Profession = t.Profession
                             };

                return result.ToList();
            }
        }

        public List<OperationClaim> GetClaims(int userId)
        {
            using (var context = new CeswaContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == userId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }

   
        public StudentDetailDto GetStudentDetailByUserId(int userId)
        {
            using (var context = new CeswaContext())
            {
                var result = from u in context.Users
                             join s in context.Students on u.Id equals s.Id
                             join uo in context.UserOperationClaims on u.Id equals uo.UserId
                             join op in context.OperationClaims on uo.OperationClaimId equals op.Id
                             where u.Id == userId
                             select new StudentDetailDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = GetClaims(userId)[0].Name,
                                 StudentDetail = s.StudentDetail,
                                 GraduationStatus =s.GraduationStatus
                             };

                return result.SingleOrDefault();
            }
        }

        public TeacherDetailDto GetTeacherDetailByUserId(int userId)
        {
            using (var context = new CeswaContext())
            {
                var result = from u in context.Users
                             join t in context.Teachers on u.Id equals t.Id
                             join uo in context.UserOperationClaims on u.Id equals uo.UserId
                             join op in context.OperationClaims on uo.OperationClaimId equals op.Id
                             where u.Id == userId
                             select new TeacherDetailDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 ClaimName = GetClaims(userId)[0].Name,
                                 Education = t.Education,
                                 Profession = t.Profession
                              };

                return result.SingleOrDefault();
            }
        }
    }
}

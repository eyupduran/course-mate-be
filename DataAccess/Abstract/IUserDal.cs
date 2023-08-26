using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(int userId);
        StudentDetailDto GetStudentDetailByUserId(int userId);
        TeacherDetailDto GetTeacherDetailByUserId(int userId);

        List<StudentDetailDto> GetAllStudents();
        List<TeacherDetailDto> GetAllTeachers();


    }
}

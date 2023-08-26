using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        DataResult<StudentDetailDto> GetStudentDetailByUserId(int userId);
        DataResult<TeacherDetailDto> GetTeacherDetailByUserId(int userId);
        DataResult<List<StudentDetailDto>> GetAllStudents();
        DataResult<List<TeacherDetailDto>> GetAllTeachers();

    }
}

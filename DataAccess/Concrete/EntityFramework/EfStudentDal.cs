using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, CeswaContext>, IStudentDal
    {
        public List<StudentOfCourseDetails> GetAllStudentsOfCourseDetailByTeacherId(int userId, int courseId)
        {
            using (var context = new CeswaContext())
            {
                var result = from u in context.Users
                             join s in context.Students on u.Id equals s.Id
                             join cs in context.CourseStudent on s.Id equals cs.StudentId
                             join c in context.Courses on cs.CourseId equals c.Id
                             join ct in context.CourseTeacher on c.Id equals ct.CourseId
                             where ct.TeacherId == userId && c.Id == courseId
                             select new StudentOfCourseDetails
                             {
                                  Email = u.Email,
                                  FullName=u.FirstName + " " + u.LastName,
                                  StudentOfCourseId = cs.Id,
                                  CourseId = c.Id,
                                  StudentDetail = s.StudentDetail,
                                  GraduationStatus =s.GraduationStatus,
                                  StudentId = u.Id,
                                  TeacherId = ct.TeacherId,
                                  PhoneNumber = u.PhoneNumber,
                             };

                return result.ToList();
            }
        }
    }
}

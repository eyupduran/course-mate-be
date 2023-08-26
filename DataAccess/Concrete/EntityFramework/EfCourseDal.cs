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
    public class EfCourseDal : EfEntityRepositoryBase<Course, CeswaContext>, ICourseDal
    {
        public List<CourseDetailDto> GetAllCoursesDetails()
        {
            using (var context = new CeswaContext())
            {
                var result = from u in context.Users
                             join t in context.Teachers on u.Id equals t.Id
                             join ct in context.CourseTeacher on t.Id equals ct.TeacherId
                             join c in context.Courses on ct.CourseId equals c.Id
                                           //where u.Id == userId
                             select new CourseDetailDto
                             {
                                 UserId = u.Id,
                                CourseId = c.Id,
                                CourseDetail = c.CourseDetail,
                                CourseName=c.CourseName,
                                CourseFee=c.Fees,
                                TeacherInfo = t.FirstName +" " + t.LastName,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                Quota = c.Quota,

                             };

                return result.ToList();
            }
        }

        public List<CourseDetailDto> GetAllCoursesDetailsByTeacherId(int userId)
        {
            using (var context = new CeswaContext())
            {
                var result = from u in context.Users
                             join t in context.Teachers on u.Id equals t.Id
                             join ct in context.CourseTeacher on t.Id equals ct.TeacherId
                             join c in context.Courses on ct.CourseId equals c.Id
                             where u.Id == userId
                             select new CourseDetailDto
                             {
                                 UserId = u.Id,
                                 CourseId = c.Id,
                                 CourseDetail = c.CourseDetail,
                                 CourseName = c.CourseName,
                                 CourseFee = c.Fees,
                                 TeacherInfo = t.FirstName + " " + t.LastName,
                                 StartDate = c.StartDate,
                                 EndDate = c.EndDate,
                                 Quota = c.Quota,

                             };

                return result.ToList();
            }
        }

        public List<CourseDetailDto> GetAllEnrolledCoursesDetailsByStudentId(int userId)
        {
            using (var context = new CeswaContext())
            {
                var result = from u in context.Users
                             join t in context.Teachers on u.Id equals t.Id
                             join ct in context.CourseTeacher on t.Id equals ct.TeacherId
                             join c in context.Courses on ct.CourseId equals c.Id
                             join cs in context.CourseStudent on c.Id equals cs.CourseId
                             join s in context.Students on cs.StudentId equals s.Id
                             where s.Id == userId
                             select new CourseDetailDto
                             {
                                 UserId = u.Id,
                                 CourseId = c.Id,
                                 CourseDetail = c.CourseDetail,
                                 CourseName = c.CourseName,
                                 CourseFee = c.Fees,
                                 TeacherInfo = t.FirstName + " " + t.LastName,
                                 StartDate = c.StartDate,
                                 EndDate = c.EndDate,
                                 Quota = c.Quota,
                             };

                return result.ToList();
            }
        }
    }
}

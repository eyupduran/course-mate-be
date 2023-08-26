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
    public class EfCourseStudentDal : EfEntityRepositoryBase<CourseStudent, CeswaContext>, ICourseStudentDal
    {
        public CourseStudent ControlRecord(int studentId, int courseId)
        {
            using (var context = new CeswaContext())
            {
                var result = from cs in context.CourseStudent
                             
                             where cs.CourseId == courseId && cs.StudentId == studentId
                             select new CourseStudent
                             {
                               Id=cs.Id,
                               CourseId= courseId,
                               StudentId= studentId
                               
                             };

                return result.SingleOrDefault();
            }
        }
    }
}

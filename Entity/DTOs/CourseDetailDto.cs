using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CourseDetailDto:IDto
    {
        public int UserId { get; set; }
        public int CourseId{ get; set; }
        public string TeacherInfo{ get; set; }
        public string CourseName { get; set; }
        public int CourseFee { get; set; }
        public string CourseDetail { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Quota { get; set; }


    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class StudentOfCourseDetails:IDto
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int StudentOfCourseId { get; set; }
        public int CourseId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string StudentDetail{ get; set; }
        public string GraduationStatus { get; set; }

        public string PhoneNumber{ get; set; }

    }
}

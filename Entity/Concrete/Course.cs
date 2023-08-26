using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Course:IEntity
    {
        public int Id { get; set; }
        public string CourseDetail { get; set; }
        public string CourseName { get; set; }
        public int Fees { get; set; }
        public string StartDate { get; set;}
        public string EndDate { get; set;}
        public int Quota { get; set; }


    }
}

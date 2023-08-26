using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Student:User
    {
        public string StudentDetail { get; set; }
        public string GraduationStatus { get; set; }
    }
}

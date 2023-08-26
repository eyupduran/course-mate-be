using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class StudentRegisterDto: UserForRegisterDto
    {
        public string StudentDetail { get; set; }
        public string GraduationStatus { get; set; }

    }
}

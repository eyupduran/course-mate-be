using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TeacherDetailDto:UserDetailDto
    {
        public string Education { get; set; }
        public string Profession { get; set; }

    }
}

using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Teacher:User
    {
        public string Education{ get; set; }
        public string Profession { get; set; }

        
    }
}

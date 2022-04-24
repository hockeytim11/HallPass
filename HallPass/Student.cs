using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallPass
{
    class Student
    {
        public string studentNumber { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string grade { get; set; }
        public string homeroomTeacher { get; set; }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}

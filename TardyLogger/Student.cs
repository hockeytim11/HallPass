using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardyLogger
{
    class Student
    {
        public string studentNumber { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string grade { get; set; }
        public string homeroomTeacher { get; set; }

        public object[] toRow() { 
            return new object[] {studentNumber, lastName, firstName, grade, homeroomTeacher};
        }

        public override string ToString()
        {
            return studentNumber + " : " + grade + " : " + lastName + ", " + firstName + " : " + homeroomTeacher;
        }
    }
}

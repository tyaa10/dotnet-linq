using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo.model
{
    class Student
    {
        //Primary key
        public int id;
        public string name;
        public int age;
        public double avgScore;
        //Foreign key
        public int groupId;
    }
}

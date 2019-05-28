using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo.model
{
    class GroupDetails
    {
        //Primary key
        public int id;
        public string name;
        public double totalAvgScore;

        public override string ToString()
        {
            return $"GroupDetails: id = {id}, name = {name}, totalAvgScore = {totalAvgScore}";
        }
    }
}

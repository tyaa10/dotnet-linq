using LinqDemo.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list =
                new List<string>() { "Demo", "Test", "Data", "1" };
            /* var list2 = 
                list.OrderBy((s) => s); */
            /* var list2 =
                list.OrderBy((s) => s).ToList(); */
            /* var list2 =
                list.OrderBy((s) => s);
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(list2.GetType()); */

            /* var list2 =
                list.OrderBy((s) => s).Where((s) => { return s.Length > 1; }); */

            /* var list2 =
                list.OrderBy((s) => s).Where((s) => { return s.Length > 1; });

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            } */

            List<Group> groups = new List<Group>()
            {
                new Group(){id = 1, name = "First"},
                new Group(){id = 2, name = "Second"}
            };

            List<Student> users = new List<Student>()
            {
                new Student(){id = 1, name = "N", age = 20, avgScore = 8.5, groupId = 1},
                new Student(){id = 2, name = "N2", age = 21, avgScore = 9.5, groupId = 1},
                new Student(){id = 3, name = "N3", age = 19, avgScore = 8.0, groupId = 2},
                new Student(){id = 4, name = "S0", age = 21, avgScore = 10, groupId = 1},
                new Student(){id = 5, name = "S1", age = 22, avgScore = 9, groupId = 2},
                new Student(){id = 6, name = "S2", age = 20, avgScore = 10, groupId = 3}
            };

            /* var users2 =
                users.Select((st) => new { st.name, st.groupId }); */
            /* var users2 =
                users.Select((st) => new { Name = st.name, GroupId = st.groupId }); */

            /* var users2 =
               users.Select((st) => new { Name = st.name, GroupId = groups.Where((gr) => gr.id == st.groupId).SingleOrDefault().name }); */

            /* var users2 =
                users.Select((st) => new {
                    Name = st.name,
                    GroupId = groups.Where((gr) => gr.id == st.groupId).SingleOrDefault()?.name
                }); */

            /*foreach (var item in users2)
            {
                Console.WriteLine(item);
            }*/

            /*var groups2 =
                groups.Aggregate(
                        new { Name =  },
                        (result, group) => { return result; }
                    );*/

            /*var totalAvgScore =
                users.Aggregate(
                        0d,
                        (result, st) => { return result += st.avgScore; },
                        (result) => { return result / users.Count; }
                    );
            Console.WriteLine(totalAvgScore);*/

            // new { GroupName = "asd", totalAvgScore = 0d }

            // GroupDetails groupDetails = new GroupDetails();

            var groups2 =
                groups.Select((gr) => users.Where((st) => st.groupId == gr.id).Aggregate(
                        new GroupDetails() { id = gr.id, name = gr.name, totalAvgScore = 0 },
                        (currentGroupDetails, st) =>
                        {
                            currentGroupDetails.totalAvgScore += st.avgScore;
                            return currentGroupDetails;
                        },
                        (currentGroupDetails) => {
                            currentGroupDetails.totalAvgScore =
                                currentGroupDetails.totalAvgScore / users.Where((st) => st.groupId == gr.id).Count();
                            return currentGroupDetails;
                        }
                    ));

            users =
                users.OrderByDescending((st) => st.name).Skip(2).Take(2).ToList();

            foreach (var item in users)
            {
                Console.WriteLine(item.name);
            }
        }
    }
}

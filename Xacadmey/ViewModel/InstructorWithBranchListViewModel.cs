using System.Collections.Generic;

namespace Xacadmey.ViewModel
{
    public class InstructorWithBranchListViewModel
    {
        public string InsName{ get; set; }
        public string InsImage { get; set; }
        public List<string>branches { get; set; }
        public string Msg { get; set; }
        public int temp { get; set; }
        public string color {  get; set; }
        public string DeptManagerName { get; set; }
    }
}

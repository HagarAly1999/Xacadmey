using System.ComponentModel.DataAnnotations;

namespace Xacadmey.ViewModel
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }

    }
}

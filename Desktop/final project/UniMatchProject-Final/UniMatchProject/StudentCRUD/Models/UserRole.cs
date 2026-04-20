using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Updated_Date { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Update_Date { get; set; }

    }
}

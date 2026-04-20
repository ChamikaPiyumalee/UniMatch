using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; }
        public string Batch { get; set; }
        public string Faculty { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Update_Date { get; set; }
    }
}

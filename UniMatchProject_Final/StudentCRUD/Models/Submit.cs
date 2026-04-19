using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class Submit
    {
        [Key]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime SubmittedTime { get; set; }
        public int SupervisorId { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Update_Date { get; set; }

    }
}




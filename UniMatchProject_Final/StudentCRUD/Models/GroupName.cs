using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class GroupName
    {
        [Key]
        public int Id { get; set; }
        public string G_Name { get; set; }
        public int NumOfMembers { get; set; }
        public string ModuleId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Updated_Date { get; set; }
       
    }
}

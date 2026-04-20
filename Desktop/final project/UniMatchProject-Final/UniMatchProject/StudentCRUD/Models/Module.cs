using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Updated_Date { get; set; }
}
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace StudentCRUD.Models
{
    public class GroupMembers
    {
        [Key]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public bool IsLeader  { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Updated_Date { get; set; }
    }
}

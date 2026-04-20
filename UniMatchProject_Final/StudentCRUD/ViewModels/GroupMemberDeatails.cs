namespace StudentCRUD.ViewModels
{
    public class GroupMemberDeatails
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public bool IsLeader { get; set; }
        public string GroupName { get; set; }
        public string ProjectName { get; set; }
        public string StudentName { get; set; }


    }
}

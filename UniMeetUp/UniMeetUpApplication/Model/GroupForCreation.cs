namespace UniMeetUpApplication.Model
{
    public class GroupForCreation
    {
        public GroupForCreation(string groupname)
        {
            GroupName = groupname;
        }

        public int GroupId;
        public string GroupName { set; get; }
        public string EmailAddress { get; set; }
    }
}

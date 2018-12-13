namespace CommonLib.Models
{
    public class UserGroup 
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string EmailAddress { get; set; }
        public User User { get; set; }
    }
}

namespace CommonLib.Models
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public string DisplayName { get; set; }
    }
}

using System.Threading.Tasks;

namespace UniMeetUpApplication.Model.Interfaces
{
    public interface ILoginModel
    {
        Task<bool> Validate_Email_and_Password(UserForLogin userForLogin);
        User getAllUserData(string email);
    }
}

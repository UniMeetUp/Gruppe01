using System.Threading.Tasks;

namespace UniMeetUpApplication.Model.Interfaces
{
    public interface ICreateAccountModel
    {
        bool Validate_Email(string email);
        Task<bool> Create_Account(UserForCreateAccount userForCreateAccount);
    }
}

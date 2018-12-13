using System.Threading.Tasks;

namespace UniMeetUpApplication.Model.Interfaces
{
    public interface IAccountSettingsModel
    {
        Task<bool> Delete_account(User user);
    }
}
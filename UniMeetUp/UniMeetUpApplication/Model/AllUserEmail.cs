using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniMeetUpApplication.Annotations;

namespace UniMeetUpApplication.Model
{
    public class AllUserEmail : INotifyPropertyChanged
    {
        public string EmailAddress { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

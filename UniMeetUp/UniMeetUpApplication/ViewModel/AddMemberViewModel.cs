using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonLib.Models;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.Services;


namespace UniMeetUpApplication.ViewModel
{
    public class AddMemberViewModel : ViewModelBase
    {
        private AddMemberModel _addMemberModel = new AddMemberModel(new ServerAccessLayer.ServerAccessLayer());
        public AllUserEmails EmailCollectionAllUserEmails { get; set; } = new AllUserEmails();
        NotificationService _notificationService = new NotificationService();

        private string _currentEmailSelected;

        public string CurrentEmailSelected
        {
            get { return _currentEmailSelected; }
            set
            {
                _currentEmailSelected = value; 
                OnPropertyChanged("CurrentEmailSelected");
            }
        }

        private int _currentIndex;
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                _currentIndex = value;
                OnPropertyChanged(CurrentIndex.ToString());
            }
        }


        public AddMemberViewModel()
        {
            InitializeEmails();
        }

        private async void InitializeEmails()
        {
            List<string> emailList = await _addMemberModel.AllMemberEmails();

            foreach (var email in emailList)
            {
                EmailCollectionAllUserEmails.Add(new AllUserEmail(){EmailAddress = email});
            }
        }

       

        ICommand _addMemberToGruopCommand;
        public ICommand AddMemberToGruopCommand
        {
            get
            {
                return _addMemberToGruopCommand ?? 
                       (_addMemberToGruopCommand = new RelayCommand<object>(AddMemberToGroupExe));
            }
        }

        private async void AddMemberToGroupExe(object parameter)
        {
            string email = EmailCollectionAllUserEmails[CurrentIndex].EmailAddress;

            AddMemberGroup grp = new AddMemberGroup(email, ((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup.GroupId);

            var response = await _addMemberModel.AddMemberToGroup(grp);

            //((MasterViewModel)App.Current.MainWindow.DataContext).User._groups.CurrentGroup.MemberList.Add();

            if (response.StatusCode == HttpStatusCode.Created)
            {
                _notificationService.Show_Message_Member_was_added_to_group(email);
            }
            else
            {
                _notificationService.Show_Message_Something_went_wrong();
            }
            
        }





    }
}

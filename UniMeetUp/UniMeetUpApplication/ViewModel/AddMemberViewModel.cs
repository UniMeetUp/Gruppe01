using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;


namespace UniMeetUpApplication.ViewModel
{
    public class AddMemberViewModel : ViewModelBase
    {
        private AddMemberModel _addMemberModel = new AddMemberModel(new ServerAccessLayer.ServerAccessLayer());
        public AllUserEmails EmailCollectionAllUserEmails { get; set; } = new AllUserEmails();

        public string CurrrentEmailSelected { get; set; }
    

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
                return _addMemberToGruopCommand ?? (_addMemberToGruopCommand = new RelayCommand(AddMemberToGroupExe));
            }
        }



        private void AddMemberToGroupExe()
        {

        }





    }
}

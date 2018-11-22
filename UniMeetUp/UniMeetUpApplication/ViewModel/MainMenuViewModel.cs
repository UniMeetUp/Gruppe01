using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.Services;
using UniMeetUpApplication.Services.ServiceInterfaces;
using UniMeetUpApplication.View;

namespace UniMeetUpApplication.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {

        // Commands
        
        private INavigationService _nav => new NavigationService();

        private IMainMenuModel _mainManuModel = new MainMenuModel(new ServerAccessLayer.ServerAccessLayer());

        public UserControl _currentPage = new MapsView();

        public UserControl CurrentPage
        {
            get { return _currentPage;}
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }



        public MainMenuViewModel()
        {

        }


        #region Commands

        ICommand _logOutCommand;
        public ICommand LogOutCommand
        {
            get
            {
                return _logOutCommand ??
                       (_logOutCommand = new RelayCommand(() =>
                       {
                           var viewModel = (MasterViewModel)App.Current.MainWindow.DataContext;
                           viewModel.LoginPageCommand.Execute(null);

                       }));
            }
        }

        ICommand _addGroupPageShowCommand;
        public ICommand AddGroupPageShowCommand
        {
            get
            {
                return _addGroupPageShowCommand ??
                       (_addGroupPageShowCommand = new RelayCommand(() =>
                       {
                           //CurrentPage = new CreateAccountView();

                           //Lav en lille dialogboks

                       }));
            }
        }

        private ICommand _chatCommand;
        public ICommand ChatCommand
        {
            get
            {
                return _chatCommand ??
                       (_chatCommand = new RelayCommand(() =>
                       {
                           CurrentPage = new ChatView();
                       }));
            }
        }

        private ICommand _mapCommand;
        public ICommand MapCommand
        {
            get
            {
                return _mapCommand ??
                       (_mapCommand = new RelayCommand(() =>
                       {
                           CurrentPage = new MapsView();

                       }));
            }
        }


        
        private ICommand _fileRepoCommand;
        public ICommand FileRepoCommand
        {
            get
            {
                return _fileRepoCommand ??
                       (_fileRepoCommand = new RelayCommand(() =>
                       {

                           CurrentPage = new FileRepoView();
                           _mainManuModel.GetAllFilenameAndIdForGroup(8);

                       }));
            }
        }

        
        private ICommand _accountSettingsCommand;
        public ICommand AccountSettingsCommand
        {
            get
            {
                return _accountSettingsCommand ??
                       (_accountSettingsCommand = new RelayCommand(() =>
                       {
                           CurrentPage = new AccountSettingsView();

                       }));
            }
        }



        #endregion
    }
}

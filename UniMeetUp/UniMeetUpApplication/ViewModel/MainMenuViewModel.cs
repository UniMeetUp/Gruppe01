﻿using System.Net;
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
        private INotificationService _notificationService => new NotificationService();
        private int selectedIndex = 0;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                //ChatCommand.Execute(null);
            }
        }

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

        ICommand _addGroupCommand;
        public ICommand AddGroupCommand
        {
            get
            {
                return _addGroupCommand ??
                       (_addGroupCommand = new RelayCommand<object>(addGroup));
            }
        }

        public async void addGroup(object parameter)
        {
            var response = await _mainManuModel.CreateGroup(parameter.ToString());
            
            if (response.StatusCode == HttpStatusCode.Created)
            {
                _notificationService.Show_Message_Group_Created();
                
            }
            else
            {
                _notificationService.Show_Message_Something_went_wrong();
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

        private ICommand _disabledViewCommand;

        public ICommand DisabledViewCommand
        {
            get
            {
                return _disabledViewCommand ??
                       (_disabledViewCommand =
                           new RelayCommand(() =>
                           {
                               CurrentPage = new FunctionalityDisabledView();
                           }));
            }
        }



        private ICommand _addMemberToGroupCommand;
        public ICommand AddMemberToGroupCommand
        {
            get
            {
                return _addMemberToGroupCommand ??
                       (_addMemberToGroupCommand = new RelayCommand(() =>
                       {
                           CurrentPage = new AddMemberView();

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
                           ((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup.ListOfFilesInGroup 
                               = _mainManuModel.GetAllFilenameAndIdForGroup(((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup.GroupId);

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

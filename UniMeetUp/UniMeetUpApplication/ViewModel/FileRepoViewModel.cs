using System.IO;
using System.Windows.Input;
using Microsoft.Win32;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.Model.Interfaces;

namespace UniMeetUpApplication.ViewModel
{
    public class FileRepoViewModel : ViewModelBase
    {
        private IFileRepoModel _fileRepoModel = new FileRepoModel(new ServerAccessLayer.ServerAccessLayer());

        ICommand _downloadFileCommand;
        public ICommand DownloadFileCommand
        {
            get
            {
                return _downloadFileCommand ?? (_downloadFileCommand = new RelayCommand<object>(DownloadFile));
            }
        }

        void DownloadFile(object parameter)
        {
            int fileId = (int)parameter;
            
            FileMessageForDownload fileObj = _fileRepoModel.DownloadFile(fileId);
            string fileName = fileObj.FileHeaders;

            SaveFileDialog dialog = new SaveFileDialog()
            {
                FileName = fileName
            };

            if (dialog.ShowDialog() == true)
            {
                FileStream fs = File.Create(dialog.FileName);
                fs.Write(fileObj.FileBinary, 0, fileObj.FileBinary.Length);
                fs.Close();
            }
        }
    }
}

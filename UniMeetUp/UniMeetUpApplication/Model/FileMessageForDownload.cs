using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class FileMessageForDownload
    {
        //public FileMessageForDownload(byte[] fileBinary, string fileHeaders)
        //{
        //    FileBinary = fileBinary;
        //    FileHeaders = fileHeaders;
        //}
        public byte[] FileBinary { get; set; }
        public string FileHeaders { get; set; }
    }
}

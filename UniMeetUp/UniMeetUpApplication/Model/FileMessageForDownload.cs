using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class FileMessageForDownload
    {
        //public FileMessageForDownload(int fileMessageId, string fileHeaders)
        //{
        //    FileMessageId = fileMessageId;
        //    FileHeaders = fileHeaders;
        //}
        public int FileMessageId { get; set; }

        public string FileHeaders { get; set; }
    }
}

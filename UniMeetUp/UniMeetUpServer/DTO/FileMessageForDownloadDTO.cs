using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniMeetUpServer.DTO
{
    public class FileMessageForDownloadDTO
    {
        public FileMessageForDownloadDTO(int fileMessageId, string fileHeaders)
        {
            FileMessageId = fileMessageId;
            FileHeaders = fileHeaders;
        }
        public int FileMessageId { get; set; }

        public string FileHeaders { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model.Interfaces
{
    public interface IFileRepoModel
    {
        FileMessageForDownload DownloadFile(int fileId);
    }
}

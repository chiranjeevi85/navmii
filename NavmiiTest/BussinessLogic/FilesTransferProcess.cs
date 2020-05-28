using NavmiiTest.FactoryClass;
using NavmiiTest.Interface;
using NavmiiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavmiiTest.BussinessLogic
{
    public class FilesTransferProcess
    {
        private IFilesTransfer filetransfer;
        public FilesTransferProcess()
        {
            this.filetransfer = new FilesTransfer();
        }

        public FileTransfer FileTransferLogic(FileTransfer vModel)
        {
            if (vModel.Copy == true)
            {
                vModel.NumberOfFilesTransfer = filetransfer.Copy();
            }
            else if(vModel.Move == true)
            {
                vModel.NumberOfFilesTransfer = filetransfer.Move();
            }
            return vModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavmiiTest.Models
{
    public class FileTransfer
    {
        public bool Copy { get; set; }
        public bool Move { get; set; }

        public int NumberOfFilesTransfer { get; set; }
    }
}
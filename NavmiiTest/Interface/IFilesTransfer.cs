using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavmiiTest.Interface
{
    public interface IFilesTransfer
    {
        int Copy();
        int Move();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityInterfaces;

namespace ServiceInterfaces
{
    public interface ISongService
    {
        ISong MakeSongFromTitle(string title);
    }
}

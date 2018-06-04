using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityInterfaces
{
    public interface ISong
    {
        string Title { get; }
        IEnumerable<string> Tags { get; }
    }
}

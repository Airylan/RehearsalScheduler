using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces;
using EntityInterfaces;
using Microsoft.Practices.Unity;

namespace Services
{
    public class RepertoireService : IRepertoireService
    {
        private IRepertoire _Repertoire { get; }

        public RepertoireService([Dependency] IRepertoire repertoire)
        {
            _Repertoire = repertoire;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityInterfaces;

namespace ServiceInterfaces
{
    public interface IRepertoireService
    {
        int SongCount { get; }

        void AddSong(ISong song);
        void AddSong(string title);
        void RemoveSong(string title);
        ISong RetrieveByTitle(string v);
        IEnumerable<ISong> RetrieveByTag(string v);
    }
}

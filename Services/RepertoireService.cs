using System;
using System.Collections.Generic;
using System.Linq;
using ServiceInterfaces;
using EntityInterfaces;
using Unity.Attributes;

namespace Services
{
    public class RepertoireService : IRepertoireService
    {
        private IRepertoire _Repertoire { get; }
        private ISongService _SongService { get; }

        public int SongCount => _Repertoire.Songs.Count;

        public RepertoireService([Dependency] ISongService songService, [Dependency] IRepertoire repertoire)
        {
            _Repertoire = repertoire;
            _SongService = songService;
        }

        public void AddSong(ISong song)
        {
            if (_Repertoire.Songs.Any(x => x.Title == song.Title))
            {
                throw new ArgumentException("Cannot add a duplicate song title", nameof(song));
            }
            _Repertoire.Songs.Add(song);
        }

        public void AddSong(string title) => AddSong(_SongService.MakeSongFromTitle(title));

        public void RemoveSong(string title) => _Repertoire.Songs.RemoveAll(song => song.Title == title);

        public ISong RetrieveByTitle(string title) => _Repertoire.Songs.FirstOrDefault(song => song.Title == title);

        public IEnumerable<ISong> RetrieveByTag(string v) => _Repertoire.Songs.Where(song => song.Tags.Contains(v));
    }
}

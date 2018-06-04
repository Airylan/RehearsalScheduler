using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityInterfaces;
using ServiceInterfaces;
using Moq;

namespace ServicesTests
{
    [TestClass()]
    public class RepertoireServiceTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var rep = new Moq.Mock<IRepertoire>();
            var songList = new List<ISong>();
            rep.Setup(x => x.Songs).Returns(songList);
            Repertoire = rep.Object;

            var songService = new Moq.Mock<ISongService>();
            songService.Setup(x => x.MakeSongFromTitle(It.IsAny<string>()))
                       .Returns((string s) =>
                        {
                            var song = new Mock<ISong>();
                            song.Setup(x => x.Title).Returns(s);
                            return song.Object;
                        });

            RepertoireService = new RepertoireService(songService.Object, Repertoire);
        }
        
        private IRepertoire Repertoire { get; set; }
        private IRepertoireService RepertoireService { get; set; }

        [TestMethod]
        public void ItShouldReportHowManySongsThereAreEmpty()
        {
            var songCount = RepertoireService.SongCount;
            var expectedSongCount = 0;
            Assert.AreEqual(expectedSongCount, songCount);
        }

        [TestMethod]
        public void ItShouldReportHowManySongsThereAreWhenPopulated()
        {
            // Set up the repertoire with a bunch of songs
            var titles = new[] { "Test song 1", "Test song 2", "Test song 3", "Test song 4" };

            AddSongList(titles);

            var expectedCount = titles.Count();
            var actualCount = RepertoireService.SongCount;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod()]
        public void ItShouldAddASongAndReportNewCount()
        {
            var song = new Moq.Mock<ISong>();
            RepertoireService.AddSong(song.Object);
            var expectedSongCount = 1;
            Assert.AreEqual(expectedSongCount, RepertoireService.SongCount);
        }

        [TestMethod()]
        public void ItShouldAddASongByNameAndReportNewCount()
        {
            RepertoireService.AddSong("My Test Song");
            var expectedSongCount = 1;
            Assert.AreEqual(expectedSongCount, RepertoireService.SongCount);
        }

        [TestMethod]
        public void ItShouldRemoveASongByName()
        {
            // Set up the repertoire with a bunch of songs
            var titles = new[] { "Test song 1", "Test song 2", "Test song 3", "Test song 4" };

            AddSongList(titles);

            // There should be 4 songs here
            Assert.AreEqual(titles.Count(), RepertoireService.SongCount);

            RepertoireService.RemoveSong("Test song 3");

            // There should be 3 songs here
            Assert.AreEqual(titles.Count() - 1, RepertoireService.SongCount);
        }

        private void AddSongList(string[] titles)
        {
            var i = 0;
            foreach (var title in titles)
            {
                ++i;
                var mock = new Mock<ISong>();
                mock.Setup(x => x.Title).Returns(title);
                mock.Setup(x => x.Tags).Returns(new[] { $"tag {(i % 2 == 0? "1" : "0")}" });
                Repertoire.Songs.Add(mock.Object);
            }
        }

        [TestMethod]
        public void ItShouldRetrieveASongByName()
        {
            // Set up the repertoire with a bunch of songs
            var titles = new[] { "Test song 1", "Test song 2", "Test song 3", "Test song 4" };

            AddSongList(titles);

            var song = RepertoireService.RetrieveByTitle("Test song 3");

            Assert.AreEqual("Test song 3", song.Title);
        }

        [TestMethod]
        public void ItShouldRetrieveASongListByTag()
        {
            // Set up the repertoire with a bunch of songs
            var titles = new[] { "Test song 1", "Test song 2", "Test song 3", "Test song 4" };

            AddSongList(titles);

            var songs = RepertoireService.RetrieveByTag("tag 1");

            Assert.AreEqual(2, songs.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldNotLetYouAddADuplicateSongTitle()
        {
            // Set up the repertoire with a bunch of songs
            var titles = new[] { "Test song 1", "Test song 2", "Test song 3", "Test song 4" };

            AddSongList(titles);
            
            RepertoireService.AddSong("Test song 1");
        }
    }
}
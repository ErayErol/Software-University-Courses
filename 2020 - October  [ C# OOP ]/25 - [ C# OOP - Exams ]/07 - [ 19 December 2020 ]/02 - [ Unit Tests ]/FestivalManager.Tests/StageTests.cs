// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(this.stage.Performers.Count, 0);
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<ArgumentNullException>(() =>
            this.stage.AddPerformer(null));
        }

        [Test]
        public void Test3()
        {
            var performer = new Performer("First", "Last", 10);
            Assert.Throws<ArgumentException>(() =>
                this.stage.AddPerformer(performer));
        }

        [Test]
        public void Test4()
        {
            var performer = new Performer("First", "Last", 20);
            var performer2 = new Performer("First2", "Last2", 40);
            this.stage.AddPerformer(performer);
            this.stage.AddPerformer(performer2);

            Assert.AreEqual(this.stage.Performers.Count, 2);
        }

        [Test]
        public void Test5()
        {
            List<Performer> performers = new List<Performer>();

            Assert.AreEqual(this.stage.Performers, performers);
        }

        [Test]
        public void Test6()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this.stage.AddSong(null));
        }

        [Test]
        public void Test7()
        {
            TimeSpan interval = new TimeSpan(0, 0, 18);
            var song = new Song("Song", interval);
            Assert.Throws<ArgumentException>(() =>
                this.stage.AddSong(song));
        }

        [Test]
        public void Test8()
        {
            TimeSpan interval = new TimeSpan(0, 2, 18);
            var song = new Song("Song", interval);
            this.stage.AddSong(song);
        }

        [Test]
        public void Test9()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this.stage.AddSongToPerformer(null, "asd"));
        }

        [Test]
        public void Test10()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this.stage.AddSongToPerformer("ASD", null));
        }

        [Test]
        public void Test11()
        {
            var performer = new Performer("First", "Last", 20);
            var performer2 = new Performer("First2", "Last2", 40);
            this.stage.AddPerformer(performer);
            this.stage.AddPerformer(performer2);

            Assert.Throws<ArgumentException>(() =>
                this.stage.AddSongToPerformer("ASD", "null222"));
        }

        [Test]
        public void Test12()
        {
            var performer = new Performer("First", "Last", 20);
            var performer2 = new Performer("First2", "Last2", 40);
            this.stage.AddPerformer(performer);
            this.stage.AddPerformer(performer2);

            TimeSpan interval = new TimeSpan(0, 2, 18);
            var song = new Song("Song", interval);
            this.stage.AddSong(song);

            Assert.Throws<ArgumentException>(() =>
                this.stage.AddSongToPerformer("Song2", "First Last"));
        }

        [Test]
        public void Test13()
        {
            var performer = new Performer("First", "Last", 20);
            var performer2 = new Performer("First2", "Last2", 40);
            this.stage.AddPerformer(performer);
            this.stage.AddPerformer(performer2);

            TimeSpan interval = new TimeSpan(0, 2, 18);
            var song = new Song("Song", interval);
            this.stage.AddSong(song);

            Assert.AreEqual(this.stage.AddSongToPerformer("Song", "First Last"), $"{song} will be performed by {performer}");
        }

        [Test]
        public void Test14()
        {
            TimeSpan interval = new TimeSpan(0, 2, 18);
            var song = new Song("Song", interval);
            this.stage.AddSong(song);

            var performer = new Performer("First", "Last", 20);
            this.stage.AddPerformer(performer);
            this.stage.AddSongToPerformer("Song", "First Last");

            Assert.AreEqual(performer.SongList.Count, 1);
        }

        [Test]
        public void Test15()
        {
            var performer = new Performer("First", "Last", 20);
            this.stage.AddPerformer(performer);

            Assert.AreEqual(performer.SongList.Count, 0);
        }

        [Test]
        public void Test16()
        {
            var performer = new Performer("First", "Last", 20);
            this.stage.AddPerformer(performer);

            var songList = new List<Song>();

            Assert.AreEqual(performer.SongList, songList);
        }

        [Test]
        public void Test17()
        {
            TimeSpan interval = new TimeSpan(0, 2, 18);
            var song = new Song("Song", interval);
            this.stage.AddSong(song);

            var performer = new Performer("First", "Last", 20);
            this.stage.AddPerformer(performer);
            this.stage.AddSongToPerformer("Song", "First Last");
            var songsCount = this.stage.Performers.Sum(p => p.SongList.Count());

            Assert.AreEqual(this.stage.Play(), $"{this.stage.Performers.Count} performers played {songsCount} songs");
        }

        [Test]
        public void Test18()
        {
            Assert.AreEqual(this.stage.Play(), $"{this.stage.Performers.Count} performers played {0} songs");
        }
    }
}
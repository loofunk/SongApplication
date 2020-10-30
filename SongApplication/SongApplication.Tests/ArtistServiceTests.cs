using Moq;
using NUnit.Framework;
using SongApplication.Interfaces;
using SongApplication.Models;
using SongApplication.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongApplication.Tests
{
    public class ArtistServiceTests
    {
        [SetUp]
        public void Setup()
        {   
        }        

        [Test]
        public void GivenAnEmptyArtistShouldThrowException()
        {
            // ARRANGE
            var mockMusicBrainzClient = new Mock<IMusicBrainzClient>();
            var mockArtistTrackService = new Mock<IArtistTracksService>();

            var artistService = new ArtistService(mockMusicBrainzClient.Object, mockArtistTrackService.Object);

            // ASSERT
            Assert.ThrowsAsync<Exception>(async () => await artistService.GetAverageWordsSongByArtist(string.Empty));
        }

        [Test]
        public void GivenAnInvalidCharactersForArtistShouldThrowException()
        {
            // ARRANGE
            var mockMusicBrainzClient = new Mock<IMusicBrainzClient>();
            var mockArtistTrackService = new Mock<IArtistTracksService>();

            var artistService = new ArtistService(mockMusicBrainzClient.Object, mockArtistTrackService.Object);

            // ASSERT
            Assert.ThrowsAsync<Exception>(async () => await artistService.GetAverageWordsSongByArtist("(*&^%$£"));
        }

        [Test]
        public void GivenAFakeArtistShouldThrowException()
        {
            // ARRANGE
            var mockMusicBrainzClient = new Mock<IMusicBrainzClient>();
            var mockArtistTrackService = new Mock<IArtistTracksService>();
            mockMusicBrainzClient.Setup(x => x.SearchByArtist(It.IsAny<string>())).ReturnsAsync(() => null);

            var artistService = new ArtistService(mockMusicBrainzClient.Object, mockArtistTrackService.Object);

            // ASSERT
            Assert.ThrowsAsync<Exception>(async () => await artistService.GetAverageWordsSongByArtist(string.Empty));
        }

        private static Artists MockArtists()
        {
            return new Artists()
            {
                Releases = new List<Release>()
                {
                    new Release(){ Title = "Album 1"},
                    new Release(){ Title = "Album 2"},
                    new Release(){ Title = "Album 3"},
                    new Release(){ Title = "Album 4"},
                }
                .ToArray()
            };
        }
    }
}
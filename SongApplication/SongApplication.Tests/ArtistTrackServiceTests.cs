using Moq;
using NUnit.Framework;
using SongApplication.Interfaces;
using SongApplication.Models;
using SongApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SongApplication.Tests
{
    public class ArtistTrackServiceTests
    {
        [Test]
        public async Task GivenLyricsAndCountShouldReturnCorrectAverage()
        {
            // ARRANGE
            var mockLyricsClient = new Mock<ILyricsClient>();
                        
            mockLyricsClient.Setup(x => x.GetSongLyrics(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new Song() { Lyrics = "Just a cast away and island lost at sea a many loneley" });

            var mockArtistTrackService = new ArtistTracksService(mockLyricsClient.Object);

            var mockedTracks = new List<string>()
            {
                "Message in a bottle" ,
                "Roxanne" ,
                "Every Breath you take"
            };

            // ACT
            var result = await mockArtistTrackService.GetAverageLyricsCount(It.IsAny<string>(), mockedTracks);

            // ASSERT
            Assert.AreEqual(12, result);
        }

        [Test]
        public void GivenAnArtistWithTracksShouldCalculateAverageLyricsCount()
        {
            // ARRANGE
            var mockLyricsClient = new Mock<ILyricsClient>();
            var mockArtistTrackService = new ArtistTracksService(mockLyricsClient.Object);

            // ACT
            var result = mockArtistTrackService.CalculateAverageLyricsCount(200, 20400);

            // ASSERT
            Assert.AreEqual(102, result);
        }        
    }
}

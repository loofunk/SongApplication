using SongApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongApplication.Services
{
    public class ArtistTracksService : IArtistTracksService
    {
        private readonly ILyricsClient _lyricsClient;

        public ArtistTracksService(ILyricsClient lyricsClient)
        {
            _lyricsClient = lyricsClient;
        }

        public async Task<int> GetAverageLyricsCount(string artist, List<string> tracks)
        {
            var lyricsCount = 0;
            var tracksCount = tracks.Count();

            foreach (var track in tracks)
            {
                var song = await _lyricsClient.GetSongLyrics(artist, track);

                if (song != null )
                {
                    if (!string.IsNullOrEmpty(song.Lyrics))
                    {
                        var lyricsInSong = song.Lyrics.Split(" ");
                        lyricsCount += lyricsInSong.Count();
                    }
                }
            }

            return CalculateAverageLyricsCount(tracksCount, lyricsCount);
        }   

        public int CalculateAverageLyricsCount(int numberOfTracks, int lyricsCount)
        {
            return lyricsCount / numberOfTracks;
        }     
    }
}

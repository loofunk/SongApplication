using SongApplication.Clients;
using SongApplication.Interfaces;
using SongApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SongApplication.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IMusicBrainzClient _musicBrainzClient;        
        private readonly IArtistTracksService _artistTracksService;

        public ArtistService(IMusicBrainzClient musicBrainzClient,             
            IArtistTracksService artistTracksService)
        {
            _musicBrainzClient = musicBrainzClient;            
            _artistTracksService = artistTracksService;
        }

        public async Task<int> GetAverageWordsSongByArtist(string artist)
        {           
            if (string.IsNullOrEmpty(artist))            
                throw new Exception("Error - please enter an artist");

            var rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            var isAlphaNumeric = rg.IsMatch(artist);

            if (!isAlphaNumeric)
                throw new Exception("Error - must be alpha numeric characters only");

            var artistInfo = await _musicBrainzClient.SearchByArtist(artist);

            if (artistInfo == null)            
                throw new Exception("Error - no artist found");
            
            var tracks = await GetAllTracksByArtist(artistInfo);

            if (tracks == null || tracks.Count() == 0)
                throw new Exception("Error - no tracks found");

            return await _artistTracksService.GetAverageLyricsCount(artist, tracks);
        }

        private async Task<List<string>> GetAllTracksByArtist(Artists artists)
        {
            var tracks = new List<string>();

            foreach (var officialReleasesByArtist in artists.Releases.Where(x=>x.Status == Enums.Status.Official))
            {
                var releases = await _musicBrainzClient.GetReleases(officialReleasesByArtist.Id.ToString());

                if (releases == null)
                    break;

                if (releases.Media == null)
                    break;

                foreach (var mediaItem in releases.Media)
                {
                    foreach (var track in mediaItem.Tracks)
                    {
                        tracks.Add(track.Title);
                    }
                }
            }

            return tracks;
        }
    }
}

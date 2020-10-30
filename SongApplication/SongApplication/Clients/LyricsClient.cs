using SongApplication.Extensions;
using SongApplication.Interfaces;
using SongApplication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SongApplication.Clients
{
    public class LyricsClient : ILyricsClient
    {
        private readonly HttpClient _httpClient;

        public LyricsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Song> GetSongLyrics(string artist, string songName)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"/{artist}/{songName}")
              .ConfigureAwait(false);

            return await response.Content.ReadAsAsync<Song>();
        }
    }
}

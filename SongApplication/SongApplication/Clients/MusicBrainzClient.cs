using SongApplication.Extensions;
using SongApplication.Interfaces;
using SongApplication.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SongApplication.Services
{
    public class MusicBrainzClient : IMusicBrainzClient
    {
        private readonly HttpClient _httpClient;

        public MusicBrainzClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Artists> SearchByArtist(string artistName)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"?query=artist:{artistName}&fmt=json")
              .ConfigureAwait(false);            

            return await response.Content.ReadAsAsync<Artists>();
        }

        public async Task<Releases> GetReleases(string releaseId)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"{releaseId}?inc=recordings&fmt=json")
              .ConfigureAwait(false);

            return await response.Content.ReadAsAsync<Releases>();
        }
    }
}

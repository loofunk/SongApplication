using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongApplication.Services
{
    public interface IArtistTracksService
    {
        Task<int> GetAverageLyricsCount(string artist, List<string> tracks);
        int CalculateAverageLyricsCount(int numberOfTracks, int lyricsCount);
    }
}
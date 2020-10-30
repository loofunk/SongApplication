using System.Threading.Tasks;

namespace SongApplication.Interfaces
{
    public interface IArtistService
    {
        Task<int> GetAverageWordsSongByArtist(string artist);
    }
}
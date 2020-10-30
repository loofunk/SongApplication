using SongApplication.Models;
using System.Threading.Tasks;

namespace SongApplication.Interfaces
{
    public interface IMusicBrainzClient
    {
        Task<Artists> SearchByArtist(string artistName);
        Task<Releases> GetReleases(string releaseId);
    }
}
using SongApplication.Models;
using System.Threading.Tasks;

namespace SongApplication.Interfaces
{
    public interface ILyricsClient
    {
        Task<Song> GetSongLyrics(string artist, string songName);
    }
}
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SongApplication.Clients;
using SongApplication.Interfaces;
using SongApplication.Services;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SongApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = StartUp();           

            Console.WriteLine("Welcome to the Artist Song Application");
            Console.WriteLine("");
            Console.WriteLine("Simply enter your favourite artist's name (i.e. Prince) in the console " +
                "window to find the average number of words in their songs:" );
            Console.WriteLine("");
            Console.Write("Favourite Artist's name:");

            var artistName = Console.ReadLine();

            var artistSongService = services.GetService<IArtistService>();
            var averageWordsByArtist = await artistSongService.GetAverageWordsSongByArtist(artistName);

            Console.WriteLine($"Average amount of words in a song: {averageWordsByArtist} by Artist: {artistName}" );
            Console.ReadLine();
        }


        private static ServiceProvider StartUp()
        {
            var musicBrainzHttpClient = BuildMuzicBrainzClient();
            var otherhttpClient = BuildLyricsClient();

            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<IMusicBrainzClient>(x => new MusicBrainzClient(musicBrainzHttpClient))
                .AddTransient<ILyricsClient>(x => new LyricsClient(otherhttpClient))
                .AddTransient<IArtistService, ArtistService>()
                .AddTransient<IArtistTracksService, ArtistTracksService>()
                .BuildServiceProvider();

            return serviceProvider;
        }

        private static HttpClient BuildLyricsClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri("https://private-anon-adac4b5c4c-lyricsovh.apiary-proxy.com/v1/")
            };
        }

        private static HttpClient BuildMuzicBrainzClient()
        {
            var musicBrainzHttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://musicbrainz.org/ws/2/release/")
            };

            musicBrainzHttpClient.DefaultRequestHeaders.Add("User-Agent", "Hqub.MusicBrainz/3.0-beta");
            return musicBrainzHttpClient;
        }
    }
}
